namespace dotcrawler
{
    public class Menu
    {
        // Used in menu loop
        private bool quit = false;
        // Error message to display
        private string errorMsg = "";

        public void Show()
        {
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
                Console.Write("\nPress \"E\" to enter the dungeon, \"D\" to delete a map or \"Q\" to quit: ");
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
                            Game game = new Game();
                            game.StartGame(loadMap);
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
                else if (option == "D")
                {
                    MapHandler maphandler = new MapHandler();
                    maphandler.ListMaps();
                    int id;
                    Console.Write("\nDelete map (id): ");
                    string? dungeon = Console.ReadLine();
                    if (!String.IsNullOrEmpty(dungeon) && int.TryParse(dungeon, out id))
                    {
                        if (!maphandler.DeleteMap(id))
                        {
                            errorMsg = "Invalid map";
                        }
                    }
                    else
                    {
                        errorMsg = "Invalid map";
                    }
                }
                else
                {
                    errorMsg = "Invalid option";
                }
                Console.Clear();
            }
        }
    }
}
