///////////////////////////////////////////////////////////////////////////////
//
// Author: Melanie Magno, magnomk@etsu.edu && Tyler Campbell, campbellt5@etsu.edu && Jacob Klucher, klucher@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project3
// File Name: Warehouse.cs
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Warehouse
    {
        public List<Dock> Docks { get; set; }
        public Queue<Truck> Entrance { get; set; }
        public int timeIntervals { get; set; }

        public int TotTrucksSpawned { get; set; }

        public int DocksAmount { get; set; }

        List<string> driverNames = new List<string>()
        {"Buddy", "Dude", "Elf", "DukeNukem", "Grinch", "Thomas", "Rando", "Frankfurter", "Billy", "Bob"};
        List<string> companyNames = new()
        {"AmazonTM", "MotherTrucker", "Ebay", "Diwali", "December", "November", "PlutoIsAPlanet", "FreeWilly", "Pringles", "AlienWare"};

        /// <summary>
        /// generate empty warehouse at beginning of day
        /// </summary>
        public Warehouse()
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
            timeIntervals = 1;  //starting this at 1 for now instead of 0 because we will be using the time intervals for math equations later
        }

        /// <summary>
        /// adds each docks sales to a total score
        /// </summary>
        /// <returns>total sales of all docks</returns>
        public double GetTotalSales()
        {
            double totalSales = 0;
            foreach (var dock in Docks)
            {
                totalSales += dock.TotalSales;
            }
            return totalSales;
        }

        /// <summary>
        /// adds the number of crates unloaded for each dock to a total score
        /// </summary>
        /// <returns>total crates unloaded for all docks</returns>
        public double GetTotalCreatesUnloaded()
        {
            int totalCrates = 0;
            foreach (var dock in Docks)
            {
                totalCrates += dock.TotalCrates;
            }
            return totalCrates;
        }

        /// <summary>
        /// adds the time in use of each dock to a total score of all docks
        /// </summary>
        /// <returns>time in use for all docks together</returns>
        public int GetTotalTimeInUse()
        {
            int totalTimeInUse = 0;
            foreach (var dock in Docks)
            {
                totalTimeInUse += dock.TimeInUse;
            }
            return totalTimeInUse;
        }

        /// <summary>
        /// adds the time not in use of each dock to a total score of all docks
        /// </summary>
        /// <returns>total time not in use for all docks added together</returns>
        public double GetTotalTimeNotInUse()
        {
            int totalTimeNotInUse = 0;
            foreach (var dock in Docks)
            {
                totalTimeNotInUse += dock.TimeNotInUse;
            }
            return totalTimeNotInUse;
        }

        /// <summary>
        /// Calculates the lowest line in any of the docks and returns the dock number
        /// </summary>
        /// <returns></returns>
        public int GetLowestDockLine()
        {
            int lowestDockLine = Docks[0].TrucksInLine;
            int shortestDockIndex = 0; ;
            int shortestDockIndexAndNotLoading = -1;
            for (int i = 0; i < Docks.Count; i++)
            {
                /*//selects the lowest line that is not actively unloading
                if (Docks[i].TrucksInLine < lowestDockLine && !Docks[i].Unloading())
                {
                    lowestDockLine = Docks[i].TrucksInLine;
                    shortestDockIndex = i;
                }
                //if all are unloading, selects the shortest line
                else if (Docks[i].TrucksInLine < lowestDockLine)
                {
                    lowestDockLine = Docks[i].TrucksInLine;
                    shortestDockIndex = i;
                }
                else
                {
                    Console.WriteLine("Something went wrong here.");
                }*/

                //selects the lowest line that is not actively unloading
                if (!Docks[i].Unloading())
                {
                    lowestDockLine = Docks[i].TrucksInLine;
                    shortestDockIndex = i;
                    shortestDockIndexAndNotLoading = i;
                }
                //if all are unloading, selects the shortest line
                else
                {
                    if (Docks[i].TrucksInLine < lowestDockLine)
                    {
                        lowestDockLine = Docks[i].TrucksInLine;
                        shortestDockIndex = i;
                    }
                }

            }

            if (shortestDockIndexAndNotLoading < shortestDockIndex && shortestDockIndexAndNotLoading != -1)
            {
                shortestDockIndex = shortestDockIndexAndNotLoading;
            }

            return shortestDockIndex;
        }



        /// <summary>
        /// runs the whole scenario for the warehouse, adds docks, starts the time count, etc
        /// </summary>
        public void Run()
        {
            CSV fileCSV = new CSV(this);

            DocksAmount = DockCount();
            // asks the user for the number of docks in the sim, then adds them to the list of docks
            for (int i = 0; i < DocksAmount; i++)
            {
                Docks.Add(new Dock());
            }

            while (timeIntervals <= 48)
            {
                Random rand = new Random();

                // check the entrance at the start of the time interval to see if there is a truck at the entrance waiting. if there is, send it to a dock line instead
                //if (Entrance.Peek() != null)

                if (Entrance.Count > 0)
                {
                    // adding the truck to a random dock right now, need to add where this searches for the dock with the lowest line for efficiency?
                    //int dockSelection = rand.Next(0, DocksAmount);
                    int dockSelection = GetLowestDockLine();
                    Docks[dockSelection].JoinLine(Entrance.Dequeue());

                    // Debug
                    Console.WriteLine("Truck joined Dock #" + (dockSelection+1));
                    Console.WriteLine($"There is {Docks[dockSelection].TrucksInLine} trucks in line at Dock #{dockSelection+1}. The longest line has been {Docks[dockSelection].LongestLine}.");
                }

                // OUTDATED COMMENT starting the simulation with a 50% chance each time interval to have a truck show up at the entrance.
                // doing this after the entrance check since it says it will take 1 time interval to process trucks there
                // later on can adjust this so that there is a bell curve of the trucks showing up with the middle of the day being the peak
                if (ShouldTruckArrive(timeIntervals))
                {
                    //get index of driver and company names lists
                    int driver = rand.Next(driverNames.Count);
                    int company = rand.Next(companyNames.Count);

                    //Truck truck = new Truck("Billy", "MotherTrucker");
                    Truck truck = new Truck(driverNames[driver], companyNames[company]);
                    Entrance.Enqueue(truck);
                    TotTrucksSpawned++;
                    // Tyler - added this new variable to count how many trucks were created to compare to how many made it through the docks


                    //Debug
                    Console.WriteLine("Driver: " + truck.Driver + "\nCompany: " + truck.DeliveryCompany);

                    // Update statistics for TotalTrucks
                    // NEEDS CODE HERE
                }

                // check each dock to see if there is a truck actively unloading. if not, move the line up if there is a truck in line
                for (int i = 0; i < DocksAmount; i++)
                {
                    Dock dock = Docks[i];

                    // checking the current truck to unload at the dock. If there is no current truck, then dequeue one and start unloading that one
                    if (dock.CurrentTruck == null || dock.CurrentTruck.RemainingCrates == 0)
                    {
                        if (dock.Line.Count > 0)
                        {
                            dock.SendOff();  //this will move the next truck up to be the current truck of the dock

                            // debug
                            Console.WriteLine($"Moving next truck up to the dock to be unloaded at dock {i+1}.");

                            // Update statistics for TimeInUse
                            dock.TimeInUse++;
                        }
                        else
                        {
                            // Update statistics for TimeNotInUse
                            dock.TimeNotInUse++;

                            // debug
                            Console.WriteLine($"No truck waiting in line at dock {i+1}.");
                        }
                    }
                    else
                    {
                        if (!dock.Unloading())
                        {
                            // debug
                            Console.WriteLine($"Dock {i+1} is now unloading.");
                            dock.CurrentTruck.Unload();
                            dock.TimeInUse++;  
                            //this should continue unloading once per time interval while the trailer is not empty
                            dock.TotalSales += dock.CurrentTruck.PrevCrateValue;

                        }
                        else
                        {
                            // debug
                            Console.WriteLine($"Dock {i + 1} is still unloading.");
                            dock.CurrentTruck.Unload();
                            dock.TimeInUse++; 
                            //this should continue unloading once per time interval while the trailer is not empty
                            dock.TotalSales += dock.CurrentTruck.PrevCrateValue;
                            if (timeIntervals == 48)
                            {
                                Console.WriteLine($"There are {dock.CurrentTruck.RemainingCrates} crates left in the truck at the end of the day.");
                                //subtracting the remaining crates that were left in the truck during the last time interval
                                dock.TotalCrates -= dock.CurrentTruck.RemainingCrates;
                            }

                        }
                        //broken for now, just need new variable in the above section somehow

                        // Tyler- created the CSV class object here and used the AddRow method with the new CurrentCrate variable
                        
                        fileCSV.AddRow(dock.CurrentTruck.CurrentCrate, dock.CurrentTruck, dock);


                        //dock.TotalSales += dock.currentTruck.TruckValue; //this looks like it would overcount sales

                        // debug
                        Console.WriteLine($"Adding current truck value to total sales for dock {i+1}.");
                        Console.WriteLine($"Current truck value: " + dock.CurrentTruck.TruckValue);
                        Console.WriteLine($"Dock {i+1} Total Sales: " + dock.TotalSales);
                    }
                }
                // proceed to the next time interval
                timeIntervals++;

                // debug
                Console.WriteLine("Proceding to next time interval: " + timeIntervals);
            }

            // After simulation finishes, write the CSV file
            fileCSV.WriteToFile();
        }
        /// <summary>
        /// allows user to input number of docks in a warehouse
        /// </summary>
        /// <returns>returns a dock count for how many counts there are in a warehouse</returns>
        public int DockCount()
        {
            int dockCount = 0;
            bool goodEntry = false;
            while (!goodEntry)
            {
                try
                {
                    Console.WriteLine("How many docks would you like to simulate?");
                    dockCount = int.Parse(Console.ReadLine());
                    goodEntry = true;
                }
                catch
                {
                    Console.WriteLine("Error, please enter a whole number.");
                }
            }
            return dockCount;
        }

        /// <summary>
        /// Allows for higher probability of trucks arriving closer to peak time.
        /// </summary>
        /// <param name="time">the current time in the simulation</param>
        /// <returns>returns true if randomValue is less than probability</returns>
        public bool ShouldTruckArrive(int time)
        {
            // Peak time for truck arrivals: 24 = noon
            int peakTime = 24;

            // Standard deviation for the bell curve
            // Lower = more spread out, higher = more concentration around peakTime
            double standardDeviation = 15.0; // Adjust as needed. 10.0 - 20.0 seems to be the best

            // Calculate probability of a truck arriving at the given time increment
            double probability = Math.Exp(-Math.Pow(time - peakTime, 2) / (2 * Math.Pow(standardDeviation, 2)));

            // Generate random number between 0 and 1.
            double randomvalue = new Random().NextDouble();

            // debug
            Console.WriteLine("\nInterval Time: " + timeIntervals);
            Console.WriteLine("Peak Time: " + peakTime);
            Console.WriteLine("Is Truck Arriving (yes if positive): " + (probability - randomvalue));

            // If randomValue is less than probability, then a truck arrives.
            return randomvalue < probability;
        }

        //In crate unload method (or somewhere like that, there needs to be a string that is returned if a crate is unloaded:
        //crate unloaded, but there are still more trucks to unload
        //crate unloaded, truck is empty AND another truck is in the dock
        //crate unloaded, truck is empty AND there is NOT another truck in the dock

        //potentially need to eventually create new method that opens new docks as it gets closer to noon and closes docks as it gets further away
    }
}
