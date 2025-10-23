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
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("dotcrawler\nv25.10a\nWilliam Pettersson\n");
            RunGame();
        }

        static void RunGame()
        {
            // Setup game
            Map map = new Map();
            map.SetMap(9,
                [
                    1, 1, 1, 1, 1, 1, 1, 1, 1,
                    1, 4, 0, 0, 0, 0, 0, 1, 1,
                    1, 1, 0, 1, 5, 1, 0, 1, 1,
                    1, 1, 6, 1, 1, 1, 0, 0, 1,
                    1, 1, 0, 0, 0, 1, 1, 2, 1,
                    1, 1, 1, 1, 1, 1, 1, 0, 1,
                    1, 0, 0, 0, 0, 0, 0, 6, 1,
                    3, 0, 0, 0, 0, 0, 1, 1, 1,
                    1, 1, 1, 1, 1, 1, 1, 1, 1,
                ]
            );
            Player player = new Player();
            Textures textures = new Textures();
            Enemies enemies = new Enemies();
            enemies.AttachAI(map);

            // Main game loop
            exitGame = false;
            while (!exitGame)
            {
                // Draw to screen
                Console.Clear();
                Console.WriteLine($"HP: {player.GetHp()} - Gold: {player.GetGold()}");
                View view = new View();
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
                    Interact(infrontPlayer, map, enemies, player);
                }
                // Let enemies have their turn
                enemies.RunLogic(map, player);
                // Check if player is still alive
                if (player.GetHp() <= 0)
                {
                    exitGame = true;
                }
            }
        }

        static void Interact(int index, Map map, Enemies enemies, Player player)
        {
            int block = map.GetLayout()[index];
            if (block == 6) // Enemy
            {
                enemies.AttackEnemy(index, player, map);
            }
            else if (block == 4) // Chest
            {
                map.UpdateLayout(index, 5); // Change texture to open chest
                player.SetGold(player.GetGold() + 100);
            }
            else if (block == 2) // Door
            {
                map.UpdateLayout(index, 0); // "Open" door by replacing it with air
            }
            else if (block == 3) // Exit
            {
                exitGame = true;
                // Save player gold
            }
        }
    }
}
