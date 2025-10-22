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
					4, 0, 0, 5, 9, 0, 0, 0, 2,
					4, 0, 0, 4, 0, 8, 0, 0, 2,
					4, 3, 3, 3, 1, 0, 0, 6, 2,
					4, 0, 0, 2, 0, 3, 7, 0, 2,
					4, 3, 0, 1, 4, 0, 0, 6, 2,
					4, 0, 0, 5, 0, 4, 0, 0, 2,
					4, 0, 0, 5, 0, 0, 0, 0, 2,
					0, 3, 3, 3, 3, 3, 3, 3, 0
				]
			);
        }
    }
}
