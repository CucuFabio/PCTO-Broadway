using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System.Security.Cryptography;

namespace RisorseUmaneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HumanResourcesController : ControllerBase
    {
        [HttpGet(Name = "GetHumanResources")]

        public async Task<HumanResources> Get()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "DESKTOP-61U4A9H\\SQLEXPRESS";

            builder.InitialCatalog = "AdventureWorks2022";

            builder.IntegratedSecurity = true;

            builder.TrustServerCertificate = true;

            var connectionString = builder.ConnectionString;

            try
            {
                await using var connection = new SqlConnection(connectionString);
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                await connection.OpenAsync();

                string sql = "SELECT * FROM HumanResources.Employee;";
                await using var command = new SqlCommand(sql, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"SQL Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();

            return new HumanResources();
        }
    }
        /*public IEnumerable<HumanResources> Get()
        {
            Random rnd = new Random();

            List<string> Roles = new List<string>() { "Chief Executive Officer", "Vice President of Engineering", "Engineering Manager", "Senior Tool Designer", "Design Engineer" };

            List<string> MaritalStatusList = new List<string>() { "S", "M" };

            List<string> GenderStatusList = new List<string>() { "F", "M" };

            int count = 1;
            return Enumerable.Range(1, 5    ).Select(index => new HumanResources
            {
                BusinessEntityID = count++,
                NationalIDNumber_long = Random.Shared.Next(1, 999999999),
                LoginID = "adventure-works\\" + Random.Shared.Next(0, 9),
                OrganizationNode = "0x" + RandomNumberGenerator.GetHexString(4, false),
                OrganizationLevel = Random.Shared.Next(0, 4),
                JobTitle = Roles[rnd.Next(0, Roles.Count)],
                BirthDate = DateTime.Now.AddYears(-Random.Shared.Next(25, 65)),
                MaritalStatus = MaritalStatusList[rnd.Next(0, MaritalStatusList.Count)],
                Gender = GenderStatusList[rnd.Next(0, GenderStatusList.Count)],
                HireDate = DateTime.Now.AddYears(-Random.Shared.Next(1, 20)),
                SalariadFlag = Random.Shared.Next(0, 2),
                VacationHours = Random.Shared.Next(0, 100),
                SickLeaveHours = Random.Shared.Next(0, 100)
                //Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                //TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }*/
}
