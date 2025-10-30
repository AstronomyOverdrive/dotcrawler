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

        // List all available maps
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

        // Get selected map
        public MapInfo GetMap(int id)
        {
            if (maps.Count() > 0 && id >= 0 && id < maps.Count())
            {
                return maps[id];
            }
            else
            {
                return new MapInfo();
            }
        }

        // Delete selected map
        public bool DeleteMap(int id)
        {
            if (maps.Count() > 0 && id >= 0 && id < maps.Count())
            {
                maps.RemoveAt(id);
                String writeJSON = JsonSerializer.Serialize(maps);
                File.WriteAllText(jsonFile, writeJSON);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
