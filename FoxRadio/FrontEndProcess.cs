using System.Diagnostics;
using System.Net;

namespace FoxRadio;

internal class FrontEndProcess
{
    public bool IsLoading { get; private set; }

    public bool IsLocked { get; private set; }

    public bool IsRunning => IsLoading || IsLocked;

    // Metadata
    public string AudioBitrate { get; private set; } = string.Empty;

    public string Artist { get; private set; } = string.Empty;

    public string Title { get; private set; } = string.Empty;

    public string Album { get; private set; } = string.Empty;

    public string Genre { get; private set; } = string.Empty;

    public string Slogan { get; private set; } = string.Empty;

    public string Message { get; private set; } = string.Empty;

    public string StationLocation { get; private set; } = string.Empty;

    public string Country { get; private set; } = string.Empty;

    public string ImageIndex { get; private set; } = string.Empty;

    public string ImageAlbum { get; private set; } = string.Empty;

    public string ImageLogo { get; private set; } = string.Empty;

    public uint FccFacilityId { get; private set; }
    // End Metadata

    public float ErrorRate { get; private set; }

    public float SignalStrength { get; private set; }

    public float Frequency => _currentFrequency;

    private int _readingSigService;

    List<LotFile> _lotFiles { get; } = new();

    Dictionary<int, ServiceData> _serviceAudio { get; } = new();

    ServiceData _currentServiceAudioData => _serviceAudio[_currentChannel];

    float _currentFrequency;

    int _currentChannel;

    Process? _process;

    public async Task Start(IPAddress ip, float frequency, int channel)
    {
        if (_process != null)
        {
            return;
        }

        _currentFrequency = frequency;
        _currentChannel = channel;

        var tempDirectory = new DirectoryInfo("tmp");

        if (!tempDirectory.Exists)
        {
            tempDirectory.Create();
        }
        //else
        //{
        //    foreach (FileInfo file in tempDirectory.GetFiles())
        //    {
        //        file.Delete();
        //    }
        //}

        _lotFiles.Clear();
        _serviceAudio.Clear();

        IsLoading = true;

        IsLocked = false;

        _process = new Process
        {
            StartInfo = new()
            {
                FileName = "nrsc5.exe",
                Arguments = $"--dump-aas-files .\\tmp\\ -H {ip} {_currentFrequency} {_currentChannel}",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            },
            EnableRaisingEvents = true,
        };

        _process.ErrorDataReceived += ErrorDataReceived;

        _process.Start();
        // _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();
    }

    public async Task Stop()
    {
        if (_process == null)
        {
            return;
        }

        await _process.StandardInput.WriteLineAsync("q");

        _process.CancelErrorRead();

        _process.Kill();

        _process = null;

        IsLoading = false;

        IsLocked = false;

        ErrorRate = 0;

        SignalStrength = 0;

        AudioBitrate = string.Empty;

        Artist = string.Empty;

        Title = string.Empty;

        Album = string.Empty;

        Genre = string.Empty;

        Slogan = string.Empty;

        Message = string.Empty;

        StationLocation = string.Empty;

        Country = string.Empty;

        ImageAlbum = string.Empty;

        ImageLogo = string.Empty;

        FccFacilityId = 0;
    }

    private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        ParseNrsc5DataLine(e.Data);
    }

    private void ParseNrsc5DataLine(string? line)
    {
        if (line == null)
        {
            return;
        }

        var parts = line.Split(' ', 2);

        if (parts.Length != 2)
        {
            return;
        }

        var rawData = parts[1];


        switch (rawData[0])
        {
            case 'A':
            {
                const string ARTIST = "Artist: ";
                const string ALBUM = "Album: ";
                const string AUDIO_BITRATE = "Audio bit rate: ";

                if (rawData.StartsWith(ARTIST))
                {
                    Artist = rawData.Replace(ARTIST, string.Empty);
                }
                else if (rawData.StartsWith(ALBUM))
                {
                    Album = rawData.Replace(ALBUM, string.Empty);
                }
                else if (rawData.StartsWith(AUDIO_BITRATE))
                {
                    AudioBitrate = rawData.Replace(AUDIO_BITRATE, string.Empty);
                }
            }
            break;

            case 'B':
            {
                const string BER = "BER: ";

                if (rawData.StartsWith(BER))
                {
                    var errorRateData = rawData.Replace(BER, string.Empty).Split(", ");
                    ErrorRate = (float)(Convert.ToDouble(errorRateData[0]) * 100);
                }
            }
            break;

            case 'C':
            {
                const string COUNTRY = "Country: ";

                if (rawData.StartsWith(COUNTRY))
                {
                    var countryFccData = rawData.Replace(COUNTRY, string.Empty);

                    Country = countryFccData[..2];

                    FccFacilityId = Convert.ToUInt32(countryFccData[21..]);
                }
            }
            break;

            case 'G':
            {
                const string GENRE = "Genre: ";

                if (rawData.StartsWith(GENRE))
                {
                    Genre = rawData.Replace(GENRE, string.Empty);
                }
            }
            break;

            case 'L':
            {
                const string LOT_FILE = "LOT file: ";

                if (rawData.StartsWith(LOT_FILE))
                {
                    var lotData = rawData.Replace(LOT_FILE, string.Empty).Split(' ', 5);

                    var lotFile = new LotFile(lotData);

                    _lotFiles.Add(lotFile);
                }
            }
            break;

            case 'M':
            {
                const string MESSAGE = "Message: ";
                const string MER = "MER: ";

                if (rawData.StartsWith(MESSAGE))
                {
                    Message = rawData.Replace(MESSAGE, string.Empty);
                }
                else if (rawData.StartsWith(MER))
                {
                    var merData = rawData.Replace(MER, string.Empty).Replace(" dB (lower),", string.Empty).Replace(" dB (upper)", string.Empty).Split(' ', 2);
                    var merLb = Convert.ToDouble(merData[0]);
                    var merUb = Convert.ToDouble(merData[1]);

                    // Convert MER values from dB to linear scale (ratio)
                    var mer_lb = Math.Pow(10, merLb / 10);
                    var mer_ub = Math.Pow(10, merUb / 10);

                    // Calculate the total MER
                    var total_mer = mer_lb + mer_ub;

                    // Convert the total MER back to dB
                    var total_mer_db = 10 * Math.Log10(total_mer);

                    // Calculate the signal strength percentage
                    var signal_strength_percentage = 100 - total_mer_db;

                    SignalStrength = (int)Math.Floor(signal_strength_percentage);
                }
            }
            break;

            case 'T':
            {
                const string TITLE = "Title: ";

                if (rawData.StartsWith(TITLE))
                {
                    Title = rawData.Replace(TITLE, string.Empty);
                }
            }
            break;

            case 'S':
            {
                const string SLOGAN = "Slogan: ";
                const string STATION_LOCATION = "Station location: ";
                const string SIG_SERVICE = "SIG Service: ";

                if (rawData.StartsWith(SLOGAN))
                {
                    Slogan = rawData.Replace(SLOGAN, string.Empty);
                }
                else if (rawData.StartsWith(STATION_LOCATION))
                {
                    StationLocation = rawData.Replace(STATION_LOCATION, string.Empty);
                }
                else if (rawData.StartsWith(SIG_SERVICE))
                {
                    const string TYPE_AUDIO = "type=audio ";

                    var sigData = rawData.Replace(SIG_SERVICE, string.Empty);

                    if (sigData.StartsWith(TYPE_AUDIO))
                    {
                        sigData = sigData.Replace(TYPE_AUDIO, string.Empty);

                        var sigDetails = sigData.Split(' ', 2);

                        var number = _readingSigService = int.Parse(sigDetails[0][7..]) - 1;
                        var name = sigDetails[1][5..];

                        if (!_serviceAudio.ContainsKey(number))
                        {
                            _serviceAudio.Add(number, new ServiceData { Name = name });
                        }
                    }
                }
                else if (rawData == "Synchronized")
                {
                    IsLoading = false;
                    IsLocked = true;
                }
            }
            break;

            case 'X':
            {
                const string XHDR = "XHDR: ";

                if (rawData.StartsWith(XHDR))
                {
                    var xhdrData = rawData.Replace(XHDR, string.Empty).Split(' ', 3);
                    ImageIndex = xhdrData[0];
                    var lotNumber = xhdrData[2];

                    var lotFile = _lotFiles.FirstOrDefault(x => x.Lot == lotNumber);

                    if (lotFile != null)
                    {
                        if (lotFile.Port == _currentServiceAudioData.AlbumArtPort)
                        {
                            ImageAlbum = $"tmp\\{lotFile.Lot}_{lotFile.Name}";
                        }
                    }

                    var logoLotFile = _lotFiles.FirstOrDefault(x => x.Port == _currentServiceAudioData.StationLogoPort);

                    if (logoLotFile != null)
                    {
                        ImageLogo = $"tmp\\{logoLotFile.Lot}_{logoLotFile.Name}";
                    }
                }
            }
            break;

            case ' ':
            {
                if (!rawData.StartsWith("  "))
                {
                    _readingSigService = -1;

                    return;
                }
                else if (_readingSigService == -1)
                {
                    throw new Exception();
                }

                rawData = rawData[2..];

                const string DATA_COMPONENT = "Data component: ";

                if (rawData.StartsWith(DATA_COMPONENT))
                {
                    var dataComponentData = rawData.Replace(DATA_COMPONENT, string.Empty)[10..].Split(' ', 4);
                    var port = dataComponentData[0];
                    var mimetype = (MIMEType)Convert.ToUInt32($"0x{dataComponentData[3][5..]}", 16);

                    if (mimetype == MIMEType.PRIMARY_IMAGE)
                    {
                        _serviceAudio[_readingSigService].AlbumArtPort = port;
                    }
                    else if (mimetype == MIMEType.STATION_LOGO)
                    {
                        _serviceAudio[_readingSigService].StationLogoPort = port;
                    }
                }
            }
            break;

            default:
            {
                _readingSigService = -1;
                // Debugger.Break();
            }
            break;
        }
    }

    public enum MIMEType : uint
    {
        PRIMARY_IMAGE = 0xBE4B7536,
        STATION_LOGO = 0xD9C72536,
        NAVTEQ = 0x2D42AC3E,
        HERE_TPEG = 0x82F03DFC,
        HERE_IMAGE = 0xB7F03DFC,
        HD_TMC = 0xEECB55B6,
        HDC = 0x4DC66C5A,
        TEXT = 0xBB492AAC,
        JPEG = 0x1E653E9C,
        PNG = 0x4F328CA0,
        TTN_TPEG_1 = 0xB39EBEB2,
        TTN_TPEG_2 = 0x4EB03469,
        TTN_TPEG_3 = 0x52103469,
        TTN_STM_TRAFFIC = 0xFF8422D7,
        TTN_STM_WEATHER = 0xEF042E96
    }

}
