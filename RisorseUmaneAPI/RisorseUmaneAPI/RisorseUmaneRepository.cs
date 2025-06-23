using MySqlConnector;
using RisorseUmaneAPI;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;

namespace HumanResourcesApi;

public class HumanResourcesRepository(MySqlDataSource database)
{
    public async Task<HumanResources?> FindOneAsync(int id)
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"SELECT `BusinessEntityID`, `NationalIDNumber`, `LoginID` FROM `HumanResources` WHERE `BusinessEntityID` = @BusinessEntityID";
        command.Parameters.AddWithValue("@BusinessEntityID", id);
        var result = await ReadAllAsync(await command.ExecuteReaderAsync());
        return result.FirstOrDefault();
    }

    public async Task<IReadOnlyList<HumanResources>> LatestPostsAsync()
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"SELECT `BusinessEntityID`, `NationalIDNumber`, `LoginID` FROM `HumanResources` ORDER BY `BusinessEntityID` DESC LIMIT 10;";
        return await ReadAllAsync(await command.ExecuteReaderAsync());
    }

    public async Task DeleteAllAsync()
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM `HumanResources`";
        await command.ExecuteNonQueryAsync();
    }

    public async Task InsertAsync(HumanResources humanResources)
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO `HumanResources` (`NationalIDNumber`, `LoginID`) VALUES (@NationalIDNumber, @LoginID);";
        BindParams(command, humanResources);
        await command.ExecuteNonQueryAsync();
        humanResources.BusinessEntityID = (int)command.LastInsertedId;
    }

    public async Task UpdateAsync(HumanResources humanResources)
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"UPDATE `HumanResources` SET `NationalIDNumber` = @NationalIDNumber, `LoginID` = @LoginID WHERE `BusinessEntityID` = @BusinessEntityID;";
        BindParams(command, humanResources);
        BindId(command, humanResources);
        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteAsync(HumanResources humanResources)
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM `HumanResources` WHERE `BusinessEntityID` = @BusinessEntityID;";
        BindId(command, humanResources);
        await command.ExecuteNonQueryAsync();
    }

    private async Task<IReadOnlyList<HumanResources>> ReadAllAsync(DbDataReader reader)
    {
        var posts = new List<HumanResources>();
        using (reader)
        {
            while (await reader.ReadAsync())
            {
                var post = new HumanResources
                {
                    BusinessEntityID = reader.GetInt32(0),
                    NationalIDNumber_long = reader.GetInt32(1),
                    LoginID = reader.GetString(2), // Rimosso il prefisso fisso
                    OrganizationNode = "0x" + RandomNumberGenerator.GetHexString(4, false),
                    OrganizationLevel = Random.Shared.Next(0, 4),
                    JobTitle = "Generated Title", // Placeholder
                    BirthDate = DateTime.Now.AddYears(-Random.Shared.Next(25, 65)),
                    MaritalStatus = Random.Shared.Next(0, 2) == 0 ? "S" : "M",
                    Gender = Random.Shared.Next(0, 2) == 0 ? "F" : "M",
                    HireDate = DateTime.Now.AddYears(-Random.Shared.Next(1, 20)),
                    SalariadFlag = Random.Shared.Next(0, 2),
                    VacationHours = Random.Shared.Next(0, 100),
                    SickLeaveHours = Random.Shared.Next(0, 100)
                };
                posts.Add(post);
            }
        }
        return posts;
    }

    private static void BindId(MySqlCommand cmd, HumanResources humanResources)
    {
        cmd.Parameters.AddWithValue("@BusinessEntityID", humanResources.BusinessEntityID);
    }

    private static void BindParams(MySqlCommand cmd, HumanResources humanResources)
    {
        cmd.Parameters.AddWithValue("@NationalIDNumber", humanResources.NationalIDNumber_long);
        cmd.Parameters.AddWithValue("@LoginID", humanResources.LoginID);
    }
}