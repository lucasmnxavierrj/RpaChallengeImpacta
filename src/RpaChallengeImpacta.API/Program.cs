using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RpaChallengeImpacta.Domain.Models;
using RpaChallengerImpacta.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapPost("/api/data", async (DatabaseContext context, List<Proxy> proxies) =>
{
    if (proxies == null || proxies.Count == 0)
        return Results.BadRequest("No proxies provided.");

    try
    {
        await context.AddRangeAsync(proxies);
        await context.SaveChangesAsync();

        return Results.Created("/api/data", proxies);
    }
    catch (Exception ex)
    {
        return Results.StatusCode(500);
    }
})
.WithOpenApi();

app.Run();
