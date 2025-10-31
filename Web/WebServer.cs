using System.IO;
using System.Text.Json;

namespace dotcrawler
{
    public class WebServer
    {
        // IP and port to run the server on
        private string IPPort = "http://127.0.0.1:8080";
        // For saving maps
        private List<MapInfo> maps = [];
        private string jsonFile = @"StoredData/maps.json";

        // Start webserver
        public void Start()
        {
            // Create app
            var builder = WebApplication.CreateBuilder([]);
            var app = builder.Build();

            // Serve html on route "/"
            app.MapGet("/", (HttpContext context) =>
            {
                context.Response.Headers["Content-Type"] = "text/html";
                return File.ReadAllText(@"Web/index.html");
            });

            // Receive map data on route "/save/{data}"
            app.MapPost("/save/{data}", (string? data) =>
            {
                // Check if client sent valid data
                if (String.IsNullOrEmpty(data))
                {
                    return Results.StatusCode(400);
                }
                else
                {
                    // Load currently saved maps
                    string readJSON = File.ReadAllText(jsonFile);
                    maps = JsonSerializer.Deserialize<List<MapInfo>>(readJSON)!;
                    // Get new map from client
                    MapInfo newMap = JsonSerializer.Deserialize<MapInfo>(data)!;
                    // Add new map to existing maps and save
                    maps.Add(newMap);
                    String writeJSON = JsonSerializer.Serialize(maps);
                    File.WriteAllText(jsonFile, writeJSON);
                    return Results.StatusCode(201);
                }
            });
            // Start app
            app.Run(IPPort);
        }

    }
}
