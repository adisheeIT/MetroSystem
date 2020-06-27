using System;
using System.Collections.Generic;

namespace test
{

public class StationObject
    {

        private string name;

        //list of which other stations each
        //station is connected to
        private List<string> connectionList;
        private List<string> lines;
        private int contacts;

        public StationObject(string newName)
        {
            this.name = newName;     
            connectionList = new List<string>(); 
            lines = new List<string>();
            contacts = 0;
            
            
        }

        public void OnLines(string onLine)
        {
            lines.Add(onLine);
        }

        public List<string> GetLines
        {
            get {return lines;}
        }

        public void AddConnection(string newConnection)
        {
            connectionList.Add(newConnection);
            this.contacts += 1;
        }

        public List<string> ConnectionList { 
            get { return this.connectionList ;} 
            
        }
        public int NumberOfContacts { 
            get { return this.contacts; }
         }
        public string Name { get => name;}
    }


}