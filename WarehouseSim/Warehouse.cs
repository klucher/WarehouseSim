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
        /// runs the whole scenario for the warehouse
        /// </summary>
        public void Run()
        {
            //this is probably where we could start creating the new trucks and adding them to the Dock line etc. or calling other methods from here to do that

            //need a while loop for trucks to appear, need to create a random number generator
            //using NextDouble() then compare that to predetermined percentages based on what time of day it is
            //use bell curve for the chance of a truck to show up. If it is less than 24 increments, then divide the current increment by 24
            //if it is over 24, divide that number minus 24 by 24


            int docksAmount = DockCount();
            for (int i = 0; i < docksAmount; i++)
            {
                Docks.Add(new Dock());
            }

            while (timeIntervals < 48)
            {
                Random rand = new Random();

                // check the entrance at the start of the time interval to see if there is a truck at the entrance waiting. if there is, send it to a dock line instead
                if (Entrance.Peek() != null)
                {
                    // adding the truck to a random dock right now, need to add where this searches for the dock with the lowest line for efficiency?
                    int dockSelection = rand.Next(0, docksAmount);
                    Docks[dockSelection].JoinLine(Entrance.Dequeue());
                }

                // starting the simulation with a 50% chance each time interval to have a truck show up at the entrance.
                // doing this after the entrance check since it says it will take 1 time interval to process trucks there
                // later on can adjust this so that there is a bell curve of the trucks showing up with the middle of the day being the peak
                if (rand.NextDouble() < 0.5)
                {
                    Truck truck = new Truck("Billy", "MotherTrucker");
                    Entrance.Enqueue(truck);
                }
                else
                {
                    // currently not doing anything at the Enterance if a truck does not spawn
                }


                // check each dock to see if there is a truck actively unloading. if not, move the line up if there is a truck in line
                for (int i = 0; i < docksAmount; i++)
                {
                    // checking the current truck to unload at the dock. If there is no current truck, then dequeue one and start unloading that one
                    if (Docks[i].currentTruck == null && Docks[i].Line.Peek() != null)
                    {
                        Docks[i].SendOff();  //this will move the next truck up
                    }
                    else if (Docks[i].Unloading())
                    {
                        //if still unloading do something here

                        //if it is still unloading, then logically would we need to do anything? besides just add the truck to the end of the line
                        //or send to another open dock if there are any? - mel
                    }
                    else
                    {

                    }

                }








                // proceed to the next time interval
                timeIntervals++;
            }







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


        //create a method that returns a csv file
        //create a time increment variable that starts at 0 and ends at the end of the day (should be 47)
        //in crate unload method, need to check the time increment variable
        //In crate unload method (or somewhere like that, there needs to be a string that is returned if a crate is unloaded:
        //crate unloaded, but there are still more trucks to unload
        //crate unloaded, truck is empty AND another truck is in the dock
        //crate unloaded, truck is empty AND there is NOT another truck in the dock

        //potentially need to eventually create new method that opens new docks as it gets closer to noon and closes docks as it gets further away
    }
}
