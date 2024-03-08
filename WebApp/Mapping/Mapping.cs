using Microsoft.Data.Sqlite;
using WebApp.Models;

namespace WebApp;

public class Mapping
{
    public static Boot MappingBoot(SqliteDataReader reader)
    {
        return new Boot
        {
            Bid = reader.GetInt32(0),
            Name = reader.GetString(1),
            Laenge = reader.GetDouble(2),
            Motorleistung = reader.GetInt32(3),
            Segelboot = reader.GetBoolean(4),
            Tiefgang = reader.GetDouble(5),
            Baujahr = reader.GetString(6)
        };
    }
    public static DtoInsert DataToDtoInsert(string name, double laenge, int? motorleistung, bool segelboot, double tiefgang, string baujahr)
    {
        return new DtoInsert
        {
            Name = name,
            Laenge = laenge,
            Motorleistung = motorleistung,
            Segelboot = segelboot,
            Tiefgang = tiefgang,
            Baujahr = baujahr
        };
    }
    public static Boot MappingEditBoot(int bid, string name, double laenge, int? motorleistung, bool segelboot, double tiefgang, string baujahr)
    {
        return new Boot
        {
            Bid = bid,
            Name = name,
            Laenge = laenge,
            Motorleistung = motorleistung,
            Segelboot = segelboot,
            Tiefgang = tiefgang,
            Baujahr = baujahr
        };
    }
    
}