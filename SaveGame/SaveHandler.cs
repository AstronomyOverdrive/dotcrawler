using System.IO;
using System.Text.Json;

namespace dotcrawler
{
    public class SaveHandler
    {
        // File with save data
        private string jsonFile = @"StoredData/save.json";
        private int highScore = 0;

        // Get highscore
        public int GetBest()
        {
            return highScore;
        }

        // Load savedata and return gold
        public int LoadGold()
        {
            if (File.Exists(jsonFile))
            {
                string json = File.ReadAllText(jsonFile);
                SaveGame save = JsonSerializer.Deserialize<SaveGame>(json)!;
                highScore = (int)save.highscore;
                return (int)save.gold;
            }
            else
            {
                return 0;
            }
        }

        // Save gold
        public void SaveGold(int amount)
        {
            // Update highscore
            if (amount > highScore)
            {
                highScore = amount;
            }
            // Save to file
            SaveGame save = new SaveGame();
            save.gold = amount;
            save.highscore = highScore;
            string json = JsonSerializer.Serialize(save);
            File.WriteAllText(jsonFile, json);
        }
    }
}
