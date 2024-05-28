using System.Text.Json.Serialization;

namespace Grannys_yarns_API.Model;

public class Yarn
{
    public int id { get; set; } = 0;
    public int did { get; set; }
    [JsonIgnore]
    public Distributor distributor { get; set; }
    public string name { get; set; }
    public string color { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public int size { get; set; }
}

public class YarnDataTransferObject
{
    public int yid { get; set; }
    public int did { get; set; }
    public string name { get; set; }
    public string color { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public int size { get; set; }
}

