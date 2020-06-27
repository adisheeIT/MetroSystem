using System;
using System.Text;
using System.Collections.Generic;

namespace test
{
    public class RouteObject
    {
        private int distance;
        private List<StationObject> route;
        private StationObject originStation;
        private int lineSwitches;

        private StationObject destination;



        public StationObject Destination
        {
            get { return this.destination;}
        }

        private List<StationObject> DuplicateStations(List<StationObject> routeToClone){
            List<StationObject> clonedRoute = new List<StationObject>();
            for (int c = 0; c < this.route.Count; c++){
                clonedRoute.Add(this.route[c]);
            }
            return clonedRoute;
        }
        
        public RouteObject CloneRoute()
        {
            RouteObject clone = new RouteObject(this.originStation, this.destination);
            clone.distance = this.distance;
            clone.route = DuplicateStations(this.route);
            clone.lineSwitches = this.lineSwitches;
            return clone;
        }

        public RouteObject(StationObject originStation, StationObject destination)
        {
            this.originStation = originStation;
            this.route = new List<StationObject>();
            //AddStopToRoute(originStation);
            this.destination = destination; 
        }
        
        public int Distance
        {
            get { return distance; }
        }

        public void AddStopToRoute(StationObject stop)
        {
            route.Add(stop);
            distance += 1;
        }

        public StationObject CurrentStation()
        {
            return route[route.Count - 1];
        }

        public StationObject PreviousStation()
        {
            return route[route.Count - 2];
        }

        public string PrintRoute()
        {
            StringBuilder sb = new StringBuilder();
            for (int s = 0; s < distance; s++)
            {
                string space = (s + 1 == distance) ? ". " : ", ";
                sb.Append(route[s].Name + space);
            }
            return sb.ToString();
        }

        public bool AlreadyCheckedThisStation(StationObject checkThis)
        {
            return route.Contains(checkThis);
        }

        public int LineSwitches
        {
            get { return this.lineSwitches; }
        }


        public void CheckLineSwitch(StationObject current, StationObject next, StationObject previous)
        {
            bool switched = true;
            for (int a = 0; a < current.GetLines.Count; a++)
            {
                string currentLine = current.GetLines[a];
                for (int b = 0; b < previous.GetLines.Count; b++)
                {
                    string previousLine = previous.GetLines[b];
                    for (int c = 0; c < next.GetLines.Count; c++)
                    {
                        string nextLine = next.GetLines[c];
                        if (previousLine == currentLine && currentLine == nextLine)
                        {
                            switched = false;
                        }
                    }
                }
            }
            if (switched)
                lineSwitches++;
        }
    }
}