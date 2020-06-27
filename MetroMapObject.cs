using System;
using System.Collections.Generic;

namespace test
{
    public class MetroMapObject
    {
        private List<StationObject> stations;

        public MetroMapObject()
        {
            this.stations = new List<StationObject>();
            //this is the entire list of stations entered into a map object

            
            StationObject a = new StationObject("A");
            a.AddConnection("B");
            a.OnLines("red");
            stations.Add(a);
            //
            StationObject b = new StationObject("B");
            b.AddConnection("A");
            b.AddConnection("C");
            b.AddConnection("H");
            b.OnLines("black");
            b.OnLines("red");
            stations.Add(b);
            //
            StationObject c = new StationObject("C");
            c.AddConnection("D");
            c.AddConnection("B");
            c.AddConnection("J");
            c.AddConnection("K");
            c.OnLines("red");
            c.OnLines("green");
            stations.Add(c);
            //
            StationObject d = new StationObject("D");
            d.AddConnection("E");
            d.AddConnection("C");
            d.AddConnection("L");
            d.AddConnection("J");
            d.OnLines("red");
            stations.Add(d);
            //
            StationObject e = new StationObject("E");
            e.AddConnection("D");
            e.AddConnection("F");
            e.AddConnection("J");
            e.AddConnection("M");
            e.OnLines("red");
            stations.Add(e);
            //
            StationObject f = new StationObject("F");
            f.AddConnection("J");
            f.AddConnection("E");
            f.AddConnection("G");
            f.OnLines("red");
            f.OnLines("black");
            stations.Add(f);
            //
            StationObject h = new StationObject("H");
            h.AddConnection("J");
            h.AddConnection("B");
            h.OnLines("black");
            stations.Add(h);
            //
            StationObject j = new StationObject("J");
            j.AddConnection("H");
            j.AddConnection("C");
            j.AddConnection("D");
            j.AddConnection("E");
            j.AddConnection("F");
            j.AddConnection("O");
            j.OnLines("black");
            j.OnLines("blue");
            j.OnLines("green");
            stations.Add(j);
            //
            StationObject o = new StationObject("O");
            o.AddConnection("J");
            o.OnLines("blue");
            stations.Add(o);
            //k
            StationObject k = new StationObject("K");
            k.AddConnection("C");
            k.AddConnection("L");
            k.OnLines("green");
            stations.Add(k);
            //l
            StationObject l = new StationObject("L");
            l.AddConnection("D");
            l.AddConnection("K");
            l.AddConnection("M");
            l.AddConnection("N");
            l.OnLines("blue");
            l.OnLines("green");
            stations.Add(l);
            //n
            StationObject n = new StationObject("N");
            n.AddConnection("L");
            n.OnLines("green");
            n.OnLines("blue");
            stations.Add(n);
            //m
            StationObject m = new StationObject("M");
            m.AddConnection("L");
            m.AddConnection("E");
            m.OnLines("blue");
            m.OnLines("green");
            stations.Add(m);
            //g
            StationObject g = new StationObject("G");
            g.AddConnection("F");
            g.OnLines("black");
            stations.Add(g);
        }

        public List<StationObject> Stations
        {
            get {return stations;}
        }

        public int StationsCount
        {
            get { return stations.Count; }
        }
    }
}
