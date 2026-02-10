using Microsoft.EntityFrameworkCore;
using SecureAdmin.Infrastructure.Data;
using System;
using Azure.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Load KeyVault
var keyVaultUrl = new Uri("https://secureadmin-kv-rohit.vault.azure.net/");

builder.Configuration.AddAzureKeyVault(
    keyVaultUrl,
    new DefaultAzureCredential());

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
//var connectionString = builder.Configuration["DbConnection"];

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSwaggerGen();
var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    
}

app.Run();
