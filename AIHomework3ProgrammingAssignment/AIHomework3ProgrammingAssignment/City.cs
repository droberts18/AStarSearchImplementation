using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIHomework3ProgrammingAssignment
{
    class City
    {
        private string name;
        private int milesToMiami;
        private Dictionary<City, int> connectingCities;

        public City() { }

        public City(string name, int milesToMiami)
        {
            this.name = name;
            this.milesToMiami = milesToMiami;
            connectingCities = new Dictionary<City, int>();
        }

        public void addConnectingCity(City connectingCity, int milesTo)
        {
            connectingCities.Add(connectingCity, milesTo);
        }

        public string getName()
        {
            return name;
        }

        public int getMilesToMiami()
        {
            return milesToMiami;
        }

        public Dictionary<City, int> getConnectingCities()
        {
            return connectingCities;
        }
    }
}
