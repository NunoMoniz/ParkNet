using Microsoft.Data.SqlClient;

namespace ParkNet.App;

// Esta classe foi uma tentativa de contornar o erro na falta de FK,
// quando o user adiciona um parque e os seus respetivos andares e lugares de uma só vez,
// ou seja, apenas na página Create do namespace ParkNet.App.Pages.Parks.Parks; 
class SqlConnections
{
    public static void AddIdToTable(string table)
    {
        string connectionString = "Server=NunoMonizPC;Database=ParkNet;User Id=admin@mail.com;Password=b98p/znnC_&Zp$y";
        string queryInsert = $"INSERT INTO {table} (ID, Column1, Column2) VALUES (@Id, @Column1Value, @Column2Value)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string queryLastId = $"SELECT MAX(ID) FROM {table}";
            SqlCommand command = new SqlCommand(queryLastId, connection);
            int lastId = Convert.ToInt32(command.ExecuteScalar());

            using (SqlCommand insertCommand = new SqlCommand(queryInsert, connection))
            {
                insertCommand.Parameters.AddWithValue("@Id", lastId + 1);
                insertCommand.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}

