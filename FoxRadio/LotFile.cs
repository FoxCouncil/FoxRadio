namespace FoxRadio;

internal class LotFile
{
    public LotFile(string[] data)
    {
        Port = data[0][5..];
        Lot = data[1][4..];
        Name = data[2][5..];
    }

    public string Port { get; set; } = string.Empty;

    public string Lot { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Size { get; set;} = string.Empty;

    public string Mime { get; set; } = string.Empty;
}
