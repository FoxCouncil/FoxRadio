namespace RtlTcp;

public class RingBuffer
{
    private byte[] buffer;
    private int start, end;

    public RingBuffer(int size)
    {
        buffer = new byte[size];
        start = 0;
        end = 0;
    }

    public void Write(ReadOnlySpan<byte> data)
    {
        foreach (var item in data)
        {
            buffer[end] = item;
            end = (end + 1) % buffer.Length;
        }
    }

    public Span<byte> Read(int length)
    {
        Span<byte> data = new byte[length];

        for (int i = 0; i < length; i++)
        {
            data[i] = buffer[start];
            start = (start + 1) % buffer.Length;
        }

        return data;
    }
}
