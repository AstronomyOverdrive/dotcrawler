//////////////////////////
//                      //
//  dotcrawler          //
//  Version 25.10a      //
//                      //
//  Written By:         //
//  William Pettersson  //
//                      //
//////////////////////////

using System;

namespace dotcrawler
{
    class Program
    {
        static bool exitGame = false; // Used for game loop

        // Main function
        static void Main(string[] args)
        {
			Console.Clear();
            bool runServer = false;
            foreach (string argument in args)
            {
                if (argument == "--server" || argument == "-s")
                {
                    runServer = true;
                }
				else {
				Console.WriteLine($"Ignoring unknown option \"{argument}\"...");}
            }
            if (runServer)
            {
                WebServer server = new WebServer();
                server.Start();
            }
            else
            {
                bool quit = false;
                string errorMsg = "";
                while (!quit)
                {
                    Console.WriteLine("dotcrawler\nv25.10a\nWilliam Pettersson\n");
                    // Error message
                    if (errorMsg != "")
                    {
                        Console.WriteLine($"Error: {errorMsg}");
                        errorMsg = "";
                    }
                    // Menu
                    Console.Write("\nPress \"E\" to enter the dungeon or \"Q\" to quit: ");
                    string option = Console.ReadKey().Key.ToString();
                    Console.WriteLine("\n");
                    if (option == "Q") // Quit
                    {
                        quit = true;
                    }
                    else if (option == "E") // Enter dungeon
                    {
                        MapHandler maphandler = new MapHandler();
                        maphandler.ListMaps();
                        int id;
                        Console.Write("\nSelect dungeon (id): ");
                        string? dungeon = Console.ReadLine();
                        if (!String.IsNullOrEmpty(dungeon) && int.TryParse(dungeon, out id))
                        {
                            MapInfo loadMap = maphandler.GetMap(id);
                            if (!String.IsNullOrEmpty(loadMap.name))
                            {
                                RunGame(loadMap);
                            }
                            else
                            {
                                errorMsg = "Invalid dungeon";
                            }
                        }
                        else
                        {
                            errorMsg = "Invalid dungeon";
                        }
                    }
                    else
                    {
                        errorMsg = "Invalid option";
                    }
                }
            }
        }

        static void RunGame(MapInfo loadMap)
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
            exitGame = false;
            while (!exitGame)
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
                // Let enemies have their turn
                enemies.RunLogic(map, player);
                // Check if player is still alive
                if (player.GetHp() <= 0)
                {
                    player.SetGold(0);
                    exitGame = true;
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

        static void Interact(int index, Map map, Enemies enemies, Player player, Random dieRoll)
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
                exitGame = true;
            }
        }
    }
}
