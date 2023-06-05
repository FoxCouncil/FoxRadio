using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxRadio;

internal class ServiceData
{
    public string Name { get; set; } = string.Empty;

    public string AlbumArtPort { get; set; } = string.Empty;

    public string StationLogoPort { get; set; } = string.Empty;

    public override string ToString()
    {
        return string.IsNullOrWhiteSpace(Name) ? "Empty" : $"{Name} - {AlbumArtPort} - {StationLogoPort}";
    }
}
