using System.IO;
using System.Text.Json;

namespace dotcrawler
{
    public class MapHandler
    {
        // File containing maps
        private string jsonFile = @"maps.json";
        // List with all available maps
        private List<MapInfo> maps = [];

        public void ListMaps()
        {
            if (File.Exists(jsonFile))
            {
                // Load maps
                string json = File.ReadAllText(jsonFile);
                maps = JsonSerializer.Deserialize<List<MapInfo>>(json)!;
                // Write to screen
                Console.WriteLine("Available maps:");
                for (int i = 0; i < maps.Count(); i++)
                {
                    Console.WriteLine($"[{i}] - {maps[i].name}");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find maps.json!");
            }
        }
    }
}
