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
                else
                {
                    Console.WriteLine($"Ignoring unknown option \"{argument}\"...");
                }
            }
            if (runServer)
            {
                WebServer server = new WebServer();
                server.Start();
            }
            else
            {
                Menu menu = new Menu();
                menu.Show();
            }
        }
    }
}
