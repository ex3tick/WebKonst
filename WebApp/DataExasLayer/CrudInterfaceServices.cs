using Microsoft.Data.Sqlite;
using WebApp.Models;

namespace WebApp.Services;

public class CrudInterfaceServices : CRUDInterface
{
    public List<Boot> GetAllBoats()
    {
        List<Boot> Boote = new List<Boot>();
        string connectionString = ConnectionString();

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand("SELECT * FROM Hafen", connection);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Boot boot = Mapping.MappingBoot(reader);

                Boote.Add(boot);
            }
        }

        return Boote;
    }

    public Boot GetBoatById(int id)
    {
        Boot boot = new Boot();
        string connectionString = ConnectionString();
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand($"SELECT * FROM Hafen WHERE bid = {id}", connection);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                boot = Mapping.MappingBoot(reader);
            }
        }

        return boot;
    }

    public bool DeleteBoat(int id)
    {
        string connectionString = ConnectionString();

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Hafen WHERE bid = @BoatId";
            using (SqliteCommand command = new SqliteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@BoatId", id);
                command.ExecuteNonQuery();
            }
        }

        return true;
    }

    public bool UpdateBoat(Boot boot)
    {
        string connectionString = ConnectionString();

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            string query =
                "UPDATE Hafen SET Name = @Name, Laenge = @Laenge, Motorleistung = @Motorleistung, Segelboot = @Segelboot, Tiefgang = @Tiefgang, Baujahr = @Baujahr WHERE bid = @Bid";

            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", boot.Name);
                command.Parameters.AddWithValue("@Laenge", boot.Laenge);
                command.Parameters.AddWithValue("@Motorleistung", boot.Motorleistung);
                command.Parameters.AddWithValue("@Segelboot", boot.Segelboot);
                command.Parameters.AddWithValue("@Tiefgang", boot.Tiefgang);
                command.Parameters.AddWithValue("@Baujahr", boot.Baujahr);
                command.Parameters.AddWithValue("@Bid", boot.Bid);

                command.ExecuteNonQuery();
            }
        }

        return true;
    }

    public int InsertBoat(Boot boot)
    {
        string connectionString = ConnectionString();
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string query =
                "INSERT INTO Hafen (name, laenge,  motoleistung, ist_segel, tiefgang, baujahr) VALUES (@Name, @Laenge, @Motorleistung, @Segelboot, @Tiefgang, @Baujahr)";
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", boot.Name);
                command.Parameters.AddWithValue("@Laenge", boot.Laenge);
                command.Parameters.AddWithValue("@Motorleistung", boot.Motorleistung);
                command.Parameters.AddWithValue("@Segelboot", boot.Segelboot);
                command.Parameters.AddWithValue("@Tiefgang", boot.Tiefgang);
                command.Parameters.AddWithValue("@Baujahr", boot.Baujahr);
                command.ExecuteNonQuery();
            }
        }

        return boot.Bid;
    }

    public string ConnectionString()
    {
        string connectionString = "";
        connectionString = File.ReadAllText("Config.txt");
        string dbPath = $"Data Source={connectionString}";
        return dbPath;
    }
}