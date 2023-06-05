using System.Net;
using System.Net.Sockets;

namespace RtlTcp;

public class RtlTcp
{
    const int DONGLE_INFO_PACKET_SIZE = 12;

    const int BUFFER_SIZE = 32768;

    readonly IPEndPoint _endpoint;

    Socket? _socket;

    bool _isRunning;

    double _sampleRate;

    // Rtl Stuff
    RtlSdrTunerType _tunerType;

    int _frequencyCorrection;

    bool _useRtlAutoGainControl;

    bool _useTunerAutoGainControl;

    uint _tunerGainIndex;

    uint _tunerGainCount;

    public event EventHandler<ReadOnlyMemory<byte>>? DataReceived;

    public RtlTcp(string host = "127.0.0.1", int port = 1234)
    {
        var ipAddress = IPAddress.Parse(host);

        _endpoint = new IPEndPoint(ipAddress, port);
    }

    public async Task StartAsync()
    {
        if (_isRunning || _socket != null)
        {
            throw new Exception();
        }
        
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
            NoDelay = true
        };

        await _socket.ConnectAsync(_endpoint);

        _isRunning = true;

        _ = ReceiveAsync(); // Fire and forget
    }

    public void Stop()
    {
        _isRunning = false;

        if (_socket == null)
        {
            return;
        }

        _socket.Close();
        _socket.Dispose();

        _socket = null;
    }

    async Task ReceiveAsync()
    {
        if (_socket == null)
        {
            return;
        }

        var buffer = new byte[BUFFER_SIZE];

        while (_isRunning)
        {
            var read = await _socket.ReceiveAsync(buffer, SocketFlags.None);

            if (read > 0)
            {
                DataReceived?.Invoke(this, new ReadOnlyMemory<byte>(buffer, 0, read));
            }
        }
    }

    async Task SendAsync(byte[] data)
    {
        if (_socket == null)
        {
            return;
        }

        await _socket.SendAsync(data, SocketFlags.None);
    }
}