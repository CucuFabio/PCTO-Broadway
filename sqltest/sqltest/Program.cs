using System;
using Microsoft.Data.SqlClient;
using System.Text;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "DESKTOP-61U4A9H\\SQLEXPRESS";

                builder.InitialCatalog = "AdventureWorks2022";

                builder.IntegratedSecurity = true;

                builder.TrustServerCertificate = true;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    string sql = "SELECT * FROM HumanResources.Employee;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        Console.WriteLine("Connessione riuscita!\n");

                        using (SqlDataReader reader = command.ExecuteReader())// Rilascia le risorse in automatico
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t");
                            }
                            Console.WriteLine("\n" + new string('-', 50));

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write(reader[i].ToString() + "\t");//TODO Gestire il NULL
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore SQL: " + e.Message);
                Console.WriteLine("Numero errore: " + e.Number);
            }

            Console.WriteLine("\nPremi un tasto per chiudere...");
            Console.ReadLine();
        }
    }
}