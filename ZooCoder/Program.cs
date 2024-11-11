using System;
using System.Data;
//using System.Data.SQLite;
using Microsoft.Data.Sqlite;

//Connect to database and set names from animals table
        //var connectionString = "Data Source=FeedingSchedules.db;Version=3;";
        var connectionString = "Data Source=FeedingSchedules.db;";
        var connection = new SqliteConnection(connectionString);
            using (connection)
            {
                connection.Open();

                var sql = "SELECT Name FROM Animals";
                var command = new SqliteCommand(sql, connection);
                using (command)
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var animalName = reader.GetString(0);
                            Console.WriteLine($"Animal Name: {animalName}");
                        }
                    }
                }
            }
//----END DATABASE CODE--------
//-----------------------------------------

//Create builder for web application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
