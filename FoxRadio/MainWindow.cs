using System.Net;

namespace FoxRadio
{
    public partial class MainWindow : Form
    {
        const string WINDOW_TITLE = "FoxRadio";

        const string WINDOW_TITLE_GITHUB = "github.com/FoxCouncil/FoxRadio";

        FrontEndProcess _frontEnd = new();

        Dictionary<string, Tuple<float, int>> _stations = new()
        {
            { " 88.5-1 - KNKX - Jazz, Blues, and NPR News", new Tuple<float, int>(88.5f, 0) },
            { " 88.5-2 - KNKX - World Class Jazz", new Tuple<float, int>(88.5f, 1) },

            { " 92.5-1 - KQMV - All the Hits!", new Tuple<float, int>(92.5f, 0) },

            { " 93.3-1 -  KJR - Seattle's Hits & Hip Hop", new Tuple<float, int>(93.3f, 0) },

            { " 93.3-2 -  KJR - Pride Radio", new Tuple<float, int>(93.3f, 1) },

            { " 94.1-1 - KSWD - Seattle Relaxing Favorites", new Tuple<float, int>(94.1f, 0) },
            { " 94.1-2 - KSWD - The Delta", new Tuple<float, int>(94.1f, 1) },

            { " 95.7-1 - KJEB - SEATTLE’s Variety from the '70s, '80s and More", new Tuple<float, int>(95.7f, 0) },
            { " 95.7-2 - KJEB - Seattle's Local Sports Station", new Tuple<float, int>(95.7f, 1) },
            { " 95.7-3 - KJEB - Relaxing Favorites", new Tuple<float, int>(95.7f, 2) },

            { " 96.5-1 - KJAQ - Playing What We Want", new Tuple<float, int>(96.5f, 0) },
            { " 96.5-2 - KJAQ - Music for the Generation that Changed the World", new Tuple<float, int>(96.5f, 1) },
            { " 96.5-3 - KJAQ - Seattle's newest sports station!", new Tuple<float, int>(96.5f, 2) },

            { " 97.3-1 - KIRO - Seattle's News. Seattle's Talk.", new Tuple<float, int>(97.3f, 0) },
            { " 97.3-2 - KIRO - Sport's home for the Northwest!", new Tuple<float, int>(97.3f, 1) },
            { " 97.3-3 - KIRO - Conservative Talk Radio", new Tuple<float, int>(97.3f, 2) },

            { " 98.1-1 - KING - Listener supported Classical Music", new Tuple<float, int>(98.1f, 0) },
            { " 98.1-2 - KING - Evergreen Channel", new Tuple<float, int>(98.1f, 1) },

            { " 98.9-1 - KNUC - 989 The Bull", new Tuple<float, int>(98.9f, 0) },
            { " 98.9-2 - KNUC - ?", new Tuple<float, int>(98.9f, 1) },
            { " 98.9-3 - KNUC - Alternative Talk", new Tuple<float, int>(98.9f, 2) },

            { " 99.9-1 - KISW - We are the Rock of Seattle", new Tuple<float, int>(99.9f, 0) },
            { " 99.9-2 - KISW - The Metal Channel", new Tuple<float, int>(99.9f, 1) },

            { "100.7-1 - KKWF - Keep you Howlin' - Today's Country", new Tuple<float, int>(100.7f, 0) },
            { "100.7-2 - KKWF - Delta Blues", new Tuple<float, int>(100.7f, 1) },

            { "102.5-1 - KZOK - Seattle's ONLY Classic Rock Station", new Tuple<float, int>(102.5f, 0) },
            { "102.5-2 - KZOK - Deep Classic Rock", new Tuple<float, int>(102.5f, 1) },

            { "103.7-1 - KHTP - 100% Throwbacks!", new Tuple<float, int>(103.7f, 0) },
            { "103.7-2 - KHTP - A Mountain of Classics", new Tuple<float, int>(103.7f, 1) },
            { "103.7-3 - KHTP - ??", new Tuple<float, int>(103.7f, 2) },

            { "105.3-1 - KCMS - Seattle's Family Friendly Station", new Tuple<float, int>(105.3f, 0) },
            { "105.3-2 - KCMS - Faith Meets Rock", new Tuple<float, int>(105.3f, 1) },
            { "105.3-3 - KCMS - Keeping You Inspired for Life.", new Tuple<float, int>(105.3f, 2) },

            { "106.1-1 - KBKS - Seattle's New Home of The Jubal Show", new Tuple<float, int>(106.1f, 0) },
            { "106.1-2 - KBKS - KISS HD2 Club Phusion", new Tuple<float, int>(106.1f, 1) },

            { "106.9-1 - KRWM - Today's Soft Favorites", new Tuple<float, int>(106.9f, 0) },
            { "106.9-2 - KRWM - Christmas Music", new Tuple<float, int>(106.9f, 1) },
            { "106.9-3 - KRWM - KIXI 880 Music as cool now as it was then!", new Tuple<float, int>(106.9f, 2) },

            { "107.7-1 - KNDD - Where the Seattle Sound started...and continues.", new Tuple<float, int>(107.7f, 0) },
            { "107.7-2 - KNDD - Channel Q", new Tuple<float, int>(107.7f, 1) },
        };

        public MainWindow()
        {
            InitializeComponent();

            Application.ApplicationExit += async (s, e) => await _frontEnd.Stop();
            FormClosing += async (s, e) => await _frontEnd.Stop();

            stationsComboBox.Items.AddRange(_stations.Keys.ToArray());
            stationsComboBox.SelectedIndex = 0;
            stationsComboBox.SelectedIndexChanged += StationsComboBoxIndexChanged;

            var timer = new System.Windows.Forms.Timer
            {
                Interval = 250
            };

            timer.Tick += Tick;

            timer.Start();
        }

        private async void StationsComboBoxIndexChanged(object? sender, EventArgs e)
        {
            if (_frontEnd.IsRunning)
            {
                await _frontEnd.Stop();

                startBtn_Click(sender ?? this, e);
            }
        }

        private void Tick(object? sender, EventArgs e)
        {
            startBtn.Enabled = !_frontEnd.IsRunning;
            stopBtn.Enabled = _frontEnd.IsRunning;

            if (!_frontEnd.IsRunning)
            {
                connectionLabel.Text = "Idle";

                Text = $"{WINDOW_TITLE} | {WINDOW_TITLE_GITHUB}";
            }
            else
            {
                connectionLabel.Text = _frontEnd.IsLoading ?
                    $"Searching @ {_frontEnd.Frequency}Mhz" :
                    $"Locked on @ {_frontEnd.Frequency}Mhz";

                if (_frontEnd.IsLocked)
                {
                    if (!string.IsNullOrWhiteSpace(_frontEnd.Title) && !string.IsNullOrWhiteSpace(_frontEnd.Artist))
                    {
                        Text = $"{_frontEnd.Title} - {_frontEnd.Artist} | {WINDOW_TITLE}";
                    }
                    else if (!string.IsNullOrWhiteSpace(_frontEnd.Title))
                    {
                        Text = $"{_frontEnd.Title} | {WINDOW_TITLE}";
                    }
                }
                else
                {
                    Text = $"{WINDOW_TITLE} | {WINDOW_TITLE_GITHUB}";
                }
            }

            if (_frontEnd.ImageIndex == "0" && !string.IsNullOrWhiteSpace(_frontEnd.ImageAlbum))
            {
                pictureBox.ImageLocation = Path.Combine(Directory.GetCurrentDirectory(), _frontEnd.ImageAlbum);
            }
            else if (_frontEnd.ImageIndex == "1" && !string.IsNullOrWhiteSpace(_frontEnd.ImageLogo))
            {
                pictureBox.ImageLocation = Path.Combine(Directory.GetCurrentDirectory(), _frontEnd.ImageLogo);
            }
            else
            {
                pictureBox.ImageLocation = string.Empty;
            }

            titleLinkLabel.Text = _frontEnd.Title;
            artistLinkLabel.Text = _frontEnd.Artist;
            albumLinkLabel.Text = _frontEnd.Album;
            genreLinkLabel.Text = _frontEnd.Genre;

            var errorRate = (int)Math.Abs(Math.Floor(_frontEnd.ErrorRate));
            errorRateValueLabel.Text = $"{errorRate}%";
            errorRateProgressBar.Value = errorRate;

            var signalStrength = (int)Math.Abs(Math.Floor(_frontEnd.SignalStrength));
            signalValueLabel.Text = $"{signalStrength}%";
            signalProgressBar.Value = signalStrength;

            messageToolStripStatusLabel.Text = !string.IsNullOrWhiteSpace(_frontEnd.Message) ? _frontEnd.Message.Trim() + "  |" : string.Empty;

            if (_frontEnd.Message != _frontEnd.Slogan)
            {
                sloganToolStripStatusLabel.Text = !string.IsNullOrWhiteSpace(_frontEnd.Slogan) ? _frontEnd.Slogan.Trim() + "  |" : string.Empty;
            }
            else
            {
                sloganToolStripStatusLabel.Text = string.Empty;
            }

            audioBitrateToolStripStatusLabel.Text = _frontEnd.AudioBitrate;
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {
            if (stationsComboBox == null || stationsComboBox.SelectedItem == null)
            {
                return;
            }

            var selectedStationKey = stationsComboBox.SelectedItem.ToString();

            if (!_stations.ContainsKey(selectedStationKey))
            {
                return;
            }

            var details = _stations[selectedStationKey];

            await _frontEnd.Start(IPAddress.Parse("192.168.1.112"), details.Item1, details.Item2);
        }

        private async void stopBtn_Click(object sender, EventArgs e)
        {
            await _frontEnd.Stop();
        }
    }
}