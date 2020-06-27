using System;
using System.Collections.Generic;

namespace test
{
    public class StationFunctions
    {

         int lowestPathSoFar;
         private bool debug;
        
       
        public StationFunctions(bool debugOn){
            lowestPathSoFar = 1000;
            debug = debugOn;
        }
        

        private StationObject GetStation(MetroMapObject mapObject, string name)
        //simple method
        {
            for (int i = 0; i < mapObject.StationsCount; i++)
            {    
               StationObject calledStation = mapObject.Stations[i];
               if (name == calledStation.Name)
               {
                   return calledStation;
               }
            }
            return null;
        }
      
        
        public string FindShortestRoutes(MetroMapObject map, string start, string end)
        {
            StationObject starting = GetStation(map, start);
            StationObject ending = GetStation(map, end);
            RouteObject routeFromOrigin = new RouteObject(starting, ending);
            routeFromOrigin.AddStopToRoute(starting);
            
            RouteBundle shortestRoutes = ExporeAllBranches(routeFromOrigin, new RouteBundle(), map);
            return shortestRoutes.PrintResult();
        }



        private RouteBundle ExporeAllBranches(RouteObject seedRoute, RouteBundle allRoutes, MetroMapObject mapE)
        {
            if (debug)
            Console.WriteLine($"smallest path so far: {lowestPathSoFar}");
            StationObject currentStation = seedRoute.CurrentStation();
            //seedRoute.AddStopToRoute(currentStation);
            if (debug)
            Console.WriteLine($"length of route: {seedRoute.Distance}");
            if (debug)
            Console.WriteLine($"~~~~~current station~~~~~: {currentStation.Name}");
            //the for loop below is to handle any station with more than 1 stop left to explore,
            //either dumping it or finding a route 
            if (debug)
            Console.WriteLine($"current station # of contacts: {currentStation.NumberOfContacts}");
            for (int s = 0; s < currentStation.NumberOfContacts; s++)
            {
                if (debug)
                Console.WriteLine($"location in for loop: <{s}>");
                //Console.WriteLine($"destination name: {seedRoute.Destination.Name}");
                StationObject addStation = GetStation(mapE, currentStation.ConnectionList[s]);
                if (debug)
                Console.WriteLine($"next station: [{addStation.Name}]");
                if (addStation.Name == seedRoute.Destination.Name)
                {
                    allRoutes.AddRoute(seedRoute);
                    if (seedRoute.Distance >= 3)
                        seedRoute.CheckLineSwitch(currentStation, addStation, seedRoute.PreviousStation());
                    if (debug)
                    Console.WriteLine($"# # # # NEW BRANCH ADDED # # # #");
                    if (seedRoute.Distance <= lowestPathSoFar) { lowestPathSoFar = seedRoute.Distance; }
                    if (debug)
                    Console.WriteLine($"Is new record?: {seedRoute.Distance <= lowestPathSoFar}");
                    if (debug)
                    Console.WriteLine($"smallest path so far: {lowestPathSoFar}");
                    continue;
                }
                if (debug){
                Console.WriteLine($"next station # of contacts: {addStation.NumberOfContacts}");
                Console.WriteLine($"enters recursive loop: {seedRoute.Distance + 1 < lowestPathSoFar && addStation.NumberOfContacts > 1 && !seedRoute.AlreadyCheckedThisStation(addStation)}");
                Console.WriteLine($"already checked the next station? {seedRoute.AlreadyCheckedThisStation(addStation)}");}
                if (seedRoute.Distance + 1 < lowestPathSoFar && addStation.NumberOfContacts > 1 && !seedRoute.AlreadyCheckedThisStation(addStation))
                {
                    RouteObject clone = seedRoute.CloneRoute();
                    clone.AddStopToRoute(addStation);
                    if (clone.Distance >= 3)
                        clone.CheckLineSwitch(currentStation, addStation, seedRoute.PreviousStation());
                    allRoutes = ExporeAllBranches(clone, allRoutes, mapE);
                }
                if (debug)
                Console.WriteLine($"/////current station post loop/////: {currentStation.Name}");
            }
            //below is the part of code that should only be accessed by branches with a single station remaining.
            StationObject nextStation = GetStation(mapE, currentStation.ConnectionList[0]);
            if (debug){
            Console.WriteLine($"next station: {nextStation.Name}");
            Console.WriteLine($"next station # of contacts: {nextStation.NumberOfContacts}");}
            string dest = seedRoute.Destination.Name;
            if (seedRoute.Distance + 1 <= lowestPathSoFar && nextStation.Name == dest)
            {
                seedRoute.AddStopToRoute(nextStation);
                if (seedRoute.Distance >= 3)
                    seedRoute.CheckLineSwitch(currentStation, nextStation, seedRoute.PreviousStation());
                allRoutes.AddRoute(seedRoute);
                lowestPathSoFar = seedRoute.Distance;
                if (debug)
                Console.WriteLine($"smallest path so far: {lowestPathSoFar}");
            }
            allRoutes.PruneLongRoutes();
            return allRoutes;
        }
    }
}