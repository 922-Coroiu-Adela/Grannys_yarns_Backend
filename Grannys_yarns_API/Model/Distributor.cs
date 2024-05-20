namespace Grannys_yarns_API.Model;

public class Distributor
{
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public List<Yarn> yarns { get; set; }
}

public class DistributorDataTransferObject
{
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
}
