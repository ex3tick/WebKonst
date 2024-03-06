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
}