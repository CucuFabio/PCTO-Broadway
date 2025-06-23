using Microsoft.AspNetCore.Mvc;
using HumanResourcesApi;
using RisorseUmaneAPI;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

/*// GET api/AdventureWorks2022
app.MapGet("/api/AdventureWorks2022", async ([FromServices] MySqlDataSource db) =>
{
    var repository = new HumanResourcesRepository(db);
    return await repository.LatestPostsAsync();
});

// GET api/AdventureWorks2022/5
app.MapGet("/api/AdventureWorks2022/{id}", async ([FromServices] MySqlDataSource db, int id) =>
{
    var repository = new HumanResourcesRepository(db);
    var result = await repository.FindOneAsync(id);
    return result is null ? Results.NotFound() : Results.Ok(result);
});

// POST api/AdventureWorks2022
app.MapPost("/api/AdventureWorks2022", async ([FromServices] MySqlDataSource db, [FromBody] HumanResources body) =>
{
    var repository = new HumanResourcesRepository(db);
    await repository.InsertAsync(body);
    return body;
});

// PUT api/AdventureWorks2022/5
app.MapPut("/api/AdventureWorks2022/{id}", async (int id, [FromServices] MySqlDataSource db, [FromBody] HumanResources body) =>
{
    var repository = new HumanResourcesRepository(db);
    var result = await repository.FindOneAsync(id);
    if (result is null)
    {
        return Results.NotFound();
    }
    result.NationalIDNumber_long = body.NationalIDNumber_long;
    result.LoginID = body.LoginID;
    await repository.UpdateAsync(result);
    return Results.Ok(result);
});

// DELETE api/AdventureWorks2022/5
app.MapDelete("/api/AdventureWorks2022/{id}", async ([FromServices] MySqlDataSource db, int id) =>
{
    var repository = new HumanResourcesRepository(db);
    var result = await repository.FindOneAsync(id);
    if (result is null)
    {
        return Results.NotFound();
    }
    await repository.DeleteAsync(result);
    return Results.NoContent();
});

// DELETE api/AdventureWorks2022
app.MapDelete("/api/AdventureWorks2022", async ([FromServices] MySqlDataSource db) =>
{
    var repository = new HumanResourcesRepository(db);
    await repository.DeleteAllAsync();
    return Results.NoContent();
});*/

app.Run();
