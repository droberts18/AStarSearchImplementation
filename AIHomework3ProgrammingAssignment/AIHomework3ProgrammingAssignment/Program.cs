using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIHomework3ProgrammingAssignment
{
    class Program
    {
        static void addConnectingCitiesToEachOther(City c1, City c2, int milesBetween)
        {
            // Connecting two cities to each other with the correct distance between each
            c1.addConnectingCity(c2, milesBetween);
            c2.addConnectingCity(c1, milesBetween);
        }

        // Conducts an A* search from the starting city to Miami
        static void runAStarSearch(City currentCity)
        {
            Console.WriteLine("Starting in " + currentCity.getName() + "...\n");
            int totalCost = 0;
            Dictionary<City, int> currentCityConnectingCities = new Dictionary<City, int>();

            // Keeps the trip going until we reach Miami
            while(currentCity.getMilesToMiami() != 0)
            {
                currentCityConnectingCities = currentCity.getConnectingCities();
                int currentMiamiPlusCurrentCityDistance = 0;
                int bestMiamiPlusCurrentCityDistance = int.MaxValue;
                City bestConnectingCity = new City();
                int distanceBetweenCities = 0;

                Console.Write(currentCity.getName() + " connects to: ");

                foreach (KeyValuePair<City, int> connectingCity in currentCityConnectingCities)
                {
                    currentMiamiPlusCurrentCityDistance = connectingCity.Value + connectingCity.Key.getMilesToMiami();
                    // Outputting possible cities to route through with A* calculation for possible route through current potential connecting city
                    Console.Write(connectingCity.Key.getName() + "(" + currentMiamiPlusCurrentCityDistance + " = " + connectingCity.Value + " + " + connectingCity.Key.getMilesToMiami() + ")");

                    // Checking to see if the distance from the connecting city to Miami plus the distance between the current city and connecting city is less than that of other connecting cities
                    if (currentMiamiPlusCurrentCityDistance < bestMiamiPlusCurrentCityDistance)
                    {
                        // Setting the new best connecting city for the most optimal route under A*
                        bestConnectingCity = connectingCity.Key;
                        // Setting the travel distance between current city and most current optimal connecting city under A*
                        distanceBetweenCities = connectingCity.Value;
                        bestMiamiPlusCurrentCityDistance = distanceBetweenCities + connectingCity.Key.getMilesToMiami();
                    }

                    // Outputs a comma if the last city output to the console was not the last connecting city
                    if (!connectingCity.Key.Equals(currentCityConnectingCities.Last().Key))
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine("\nTraveled " + distanceBetweenCities + " miles to " + bestConnectingCity.getName() + "\n");
                totalCost += distanceBetweenCities;
                currentCity = bestConnectingCity;
            }
            Console.WriteLine("Reached Miami (goal node)");
            Console.WriteLine("Total Cost: " + totalCost + " miles\n");
        }

        // Start node is Seattle, goal node is Miami
        static void Main(string[] args)
        {
            // Creating all the cities with correct distances to Miami
            #region
            City seattle = new City("Seattle", 2735);
            City portland = new City("Portland", 2708);
            City sanFrancisco = new City("San Francisco", 2594);
            City losAngeles = new City("Los Angeles", 2338);
            City sanDiego = new City("San Diego", 2271);
            City phoenix = new City("Phoenix", 1981);
            City saltLake = new City("Salt Lake City", 2090);
            City denver = new City("Denver", 1727);
            City dallas = new City("Dallas", 1111);
            City austin = new City("Austin", 1115);
            City houston = new City("Houston", 968);
            City miami = new City("Miami", 0);
            City minneapolis = new City("Minneapolis", 1516);
            City chicago = new City("Chicago", 1193);
            City detroit = new City("Detroit", 1158);
            City washingtonDC = new City("Washington D.C.", 928);
            City baltimore = new City("Baltimore", 959);
            City newYorkCity = new City("New York City", 1094);
            #endregion

            // Creating connections/relationships between cities based on map in "AI HW #3 Problem #5.docx" (image also within file)
            #region
            addConnectingCitiesToEachOther(seattle, portland, 145);
            addConnectingCitiesToEachOther(seattle, saltLake, 701);
            addConnectingCitiesToEachOther(seattle, minneapolis, 1393);
            addConnectingCitiesToEachOther(portland, sanFrancisco, 536);
            addConnectingCitiesToEachOther(portland, losAngeles, 827);
            addConnectingCitiesToEachOther(saltLake, sanFrancisco, 600);
            addConnectingCitiesToEachOther(saltLake, sanDiego, 628);
            addConnectingCitiesToEachOther(saltLake, denver, 371);
            addConnectingCitiesToEachOther(minneapolis, denver, 699);
            addConnectingCitiesToEachOther(minneapolis, dallas, 865);
            addConnectingCitiesToEachOther(minneapolis, chicago, 355);
            addConnectingCitiesToEachOther(sanFrancisco, losAngeles, 348);
            addConnectingCitiesToEachOther(losAngeles, sanDiego, 112);
            addConnectingCitiesToEachOther(sanDiego, phoenix, 299);
            addConnectingCitiesToEachOther(denver, phoenix, 586);
            addConnectingCitiesToEachOther(denver, dallas, 663);
            addConnectingCitiesToEachOther(dallas, phoenix, 886);
            addConnectingCitiesToEachOther(dallas, austin, 182);
            addConnectingCitiesToEachOther(dallas, houston, 225);
            addConnectingCitiesToEachOther(chicago, austin, 981);
            addConnectingCitiesToEachOther(chicago, miami, 1193);
            addConnectingCitiesToEachOther(chicago, detroit, 237);
            addConnectingCitiesToEachOther(austin, houston, 146);
            addConnectingCitiesToEachOther(houston, miami, 968);
            addConnectingCitiesToEachOther(miami, detroit, 1158);
            addConnectingCitiesToEachOther(miami, washingtonDC, 928);
            addConnectingCitiesToEachOther(detroit, washingtonDC, 394);
            addConnectingCitiesToEachOther(detroit, baltimore, 397);
            addConnectingCitiesToEachOther(detroit, newYorkCity, 481);
            addConnectingCitiesToEachOther(washingtonDC, baltimore, 35);
            addConnectingCitiesToEachOther(baltimore, newYorkCity, 170);
            #endregion
            runAStarSearch(seattle);
        }
    }
}
