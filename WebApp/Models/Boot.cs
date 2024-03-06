namespace WebApp.Models;

public class Boot
{
    public int Bid { get; set; }
    public string Name { get; set; }
    public double Laenge { get; set; }
    public int? Motorleistung { get; set; }
    public bool Segelboot { get; set; }
    public double Tiefgang { get; set; }
    public string Baujahr { get; set; }

    public Boot()
    {
        
    }
    public Boot(int bid, string name, double laenge, int? motorleistung, bool segelboot, double tiefgang, string baujahr)
    {
        Bid = bid;
        Name = name;
        Laenge = laenge;
        Motorleistung = motorleistung;
        Segelboot = segelboot;
        Tiefgang = tiefgang;
        Baujahr = baujahr;
    }
}