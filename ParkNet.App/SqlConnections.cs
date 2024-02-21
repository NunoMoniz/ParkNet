using Microsoft.Data.SqlClient;

namespace ParkNet.App;
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

