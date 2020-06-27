using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MetroMapObject map = new MetroMapObject();
            //take user input
            Console.WriteLine("This app finds the shortest route(s) between two metro stations");
            Console.WriteLine("Please type the name of the origin staiton (eg. 'A') (CAPS ON)");
            string origin = Console.ReadLine();
            Console.WriteLine("Fab, now type the name of the destiation staiton (eg. 'D')");
            string destiation = Console.ReadLine();
            Console.WriteLine("Do you want to run in debug mode? (y/n)");
            string debug = Console.ReadLine();
            bool runInDebugMode = false;
            if (debug == "y" || debug == "Y")
                runInDebugMode = true;

            //find shortest


            StationFunctions functions = new StationFunctions(runInDebugMode);
            
            Console.WriteLine(functions.FindShortestRoutes(map, origin, destiation));
        }
    }
}
