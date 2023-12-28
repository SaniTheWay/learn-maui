using System.Text.Json.Serialization;

namespace MonkeyFinder.Model;

public class Monkey
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Detail { get; set; }
    public string Image { get; set; }
    public string Population { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}
