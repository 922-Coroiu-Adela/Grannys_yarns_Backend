namespace Grannys_yarns_API.Model;

public class Distributor
{
    public int did { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public List<Yarn> yarns { get; set; }
}

public class DistributorDataTransferObject
{
    public int did { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public string username { get; set; }
    public string password { get; set; }
}

public class DistributorLoginDataTransferObject
{
    public string username { get; set; }
    public string password { get; set; }
}
