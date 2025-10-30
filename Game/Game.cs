namespace dotcrawler
{
    public class Game
    {
        // Used for main game loop
        private bool quit = false;

        // Setup and start a game
        public void StartGame(MapInfo loadMap)
        {
            // Setup game
            Map map = new Map();
            Player player = new Player();
            View view = new View();
            Enemies enemies = new Enemies();
            SaveHandler saveHandler = new SaveHandler();
            Random dieRoll = new Random();
            view.ShowResize();
            map.SetMap((int)loadMap.grid, loadMap.layout);
            player.SetPos((int)loadMap.spawn, map);
            player.SetGold(saveHandler.LoadGold());
            enemies.AttachAI(map);

            // Main game loop
            while (!quit)
            {
                // Draw to screen
                Console.Clear();
                Console.WriteLine($"HP: {player.GetHp()} - Gold: {player.GetGold()} - Best: {saveHandler.GetBest()}");
                view.GetView(player.GetPos(), player.GetDir(), map);

                // Get position infront and behind player
                int infrontPlayer = player.GetPos();
                int behindPlayer = player.GetPos();
                if (player.GetDir() == "East")
                {
                    infrontPlayer = player.GetPos() + 1;
                    behindPlayer = player.GetPos() - 1;
                }
                else if (player.GetDir() == "North")
                {
                    infrontPlayer = player.GetPos() - map.GetGrid();
                    behindPlayer = player.GetPos() + map.GetGrid();
                }
                else if (player.GetDir() == "South")
                {
                    infrontPlayer = player.GetPos() + map.GetGrid();
                    behindPlayer = player.GetPos() - map.GetGrid();
                }
                else if (player.GetDir() == "West")
                {
                    infrontPlayer = player.GetPos() - 1;
                    behindPlayer = player.GetPos() + 1;
                }
                // Handle player input
                string option = Console.ReadKey().Key.ToString();
                if (option == "W")
                {
                    player.SetPos(infrontPlayer, map);
                }
                else if (option == "A")
                {
                    player.Turn(false);
                }
                else if (option == "S")
                {
                    player.SetPos(behindPlayer, map);
                }
                else if (option == "D")
                {
                    player.Turn(true);
                }
                else if (option == "E")
                {
                    Interact(infrontPlayer, map, enemies, player, dieRoll);
                }
                else if (option == "Q")
                {
                    player.SetGold(saveHandler.GetBest());
                    quit = true;
                }
                // Let enemies have their turn
                enemies.RunLogic(map, player);
                // Check if player is still alive
                if (player.GetHp() <= 0)
                {
                    player.SetGold(0);
                    quit = true;
                }
            }
            // Save gold and highscore after a finished run
            saveHandler.SaveGold(player.GetGold());
            // Display message
            if (player.GetHp() <= 0)
            {
                Console.WriteLine("\nYou died!");
            }
            else
            {
                Console.WriteLine($"\nRun finished with {player.GetGold()} gold!");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        // Attempt to interact
        private void Interact(int index, Map map, Enemies enemies, Player player, Random dieRoll)
        {
            string block = map.GetLayout()[index];
            if (block == "enemy") // Enemy
            {
                if (dieRoll.Next(10) > 1) // Roll for hit chance
                {
                    enemies.AttackEnemy(index, player, map);
                }
            }
            else if (block == "chestClosed") // Chest
            {
                map.UpdateLayout(index, "chestOpen"); // Change texture to open chest
                player.SetGold(player.GetGold() + dieRoll.Next(81) + 20);
            }
            else if (block == "door") // Door
            {
                map.UpdateLayout(index, "air"); // "Open" door by replacing it with air
            }
            else if (block == "exit") // Exit
            {
                quit = true;
            }
        }
    }
}
