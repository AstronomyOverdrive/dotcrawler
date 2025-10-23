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
        // Main function
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("dotcrawler\nv25.10a\nWilliam Pettersson\n");
            Map map = new Map();
            map.SetMap(9,
                [
                    0, 1, 1, 1, 1, 1, 1, 1, 0,
                    1, 4, 0, 0, 0, 0, 0, 1, 1,
                    1, 1, 0, 1, 5, 1, 0, 1, 1,
                    1, 1, 6, 1, 1, 1, 0, 0, 1,
                    1, 1, 0, 0, 0, 1, 1, 0, 1,
                    1, 1, 1, 1, 1, 1, 1, 0, 1,
                    1, 0, 0, 0, 0, 0, 0, 6, 1,
                    1, 0, 0, 0, 0, 0, 1, 1, 1,
                    0, 1, 1, 1, 1, 1, 1, 1, 0,
                ]
            );

            Player player = new Player();
            Textures textures = new Textures();
            Enemies enemies = new Enemies();
            enemies.AttachAI(map);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"HP: {player.GetHp()} - Gold: 0");
                View view = new View();

                view.GetView(player.GetPos(), player.GetDir(), map);

                int moveForwards = player.GetPos();
                int moveBackwards = player.GetPos();
                if (player.GetDir() == "East")
                {
                    moveForwards = player.GetPos() + 1;
                    moveBackwards = player.GetPos() - 1;
                }
                else if (player.GetDir() == "North")
                {
                    moveForwards = player.GetPos() - map.GetGrid();
                    moveBackwards = player.GetPos() + map.GetGrid();
                }
                else if (player.GetDir() == "South")
                {
                    moveForwards = player.GetPos() + map.GetGrid();
                    moveBackwards = player.GetPos() - map.GetGrid();
                }
                else if (player.GetDir() == "West")
                {
                    moveForwards = player.GetPos() - 1;
                    moveBackwards = player.GetPos() + 1;
                }

                string option = Console.ReadKey().Key.ToString();
                if (option == "W")
                {
                    player.SetPos(moveForwards, map);
                }
                else if (option == "A")
                {
                    player.Turn(false);
                }
                else if (option == "S")
                {
                    player.SetPos(moveBackwards, map);
                }
                else if (option == "D")
                {
                    player.Turn(true);
                }
                else if (option == "E")
                {
                    if (map.GetLayout()[moveForwards] == 6)
                    {
                        enemies.AttackEnemy(moveForwards, player, map);
                    }
                }
                enemies.RunLogic(map, player);
            }

        }
    }
}
