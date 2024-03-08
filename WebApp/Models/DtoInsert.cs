namespace WebApp.Models;

public class DtoInsert
{
   
    public string Name { get; set; }
    public double Laenge { get; set; }
    public int? Motorleistung { get; set; }
    public bool Segelboot { get; set; }
    public double Tiefgang { get; set; }
    public string Baujahr { get; set; }
}