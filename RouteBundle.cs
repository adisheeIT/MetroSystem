using System;
using System.Collections.Generic;

namespace test
{
    public class RouteBundle
    {

        public List<RouteObject> routes;
        private int shortest;

        public RouteBundle()
        {
            this.routes = new List<RouteObject>();
            shortest = 999;
        }

        public void AddRoute(RouteObject newRoute)
        {
            routes.Add(newRoute);
        }
        
        public int Count()
        {
            return routes.Count;
        }

        public void SetSmallestRoute()
        {
            
            
            for (int r = 0; r < routes.Count; r++)
            {
                if (routes[r].Distance < shortest)
                {
                    shortest = routes[r].Distance;
                }
            }
                
           
        }

        public void PruneLongRoutes()
        {   
            SetSmallestRoute();
            for (int r = 0; r < routes.Count; r++)
            {
                if (routes[r].Distance > shortest)
                    routes.Remove(routes[r]);
            }
        }

        public string PrintResult()
        {
            String result = routes.Count > 1 ? "The shortest routes are\n" : "The shortest route is\n";
            for (int r = 0; r < routes.Count; r++)
            {
                result = result + routes[r].PrintRoute() + " with " + routes[r].LineSwitches + " line switches";
            }
            return result;
        }
    }
}