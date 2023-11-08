///////////////////////////////////////////////////////////////////////////////
//
// Author: Melanie Magno, magnomk@etsu.edu && Tyler Campbell, campbellt5@etsu.edu && Jacob Klucher, klucher@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project3
// File Name: Dock.cs
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Dock
    {
        public string Id { get; set; }
        public Queue<Truck> Line { get; set; }
        public double TotalSales { get; set; }
        public int TotalCrates { get; set; }
        public int TotalTrucks { get; set; }
        public int TimeInUse { get; set; }
        public int TimeNotInUse { get; set; }

        /// <summary>
        /// general method to create an empty dock
        /// </summary>
        /// <param name="Id">the name/UIN of the dock</param>
        public Dock(string Id)
        {
            this.Id = Id;
            Line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
        }

        /// <summary>
        /// This method adds a truck to a queue at a specific dock.
        /// </summary>
        /// <param name="truck">the truck being added to the line at the dock</param>
        public void JoinLine(Truck truck)
        {
            Line.Enqueue(truck);
            //TimeInUse++;  //does time need to be added when the truck joins the line? this time needs to be tracked somewhere
            TotalTrucks++;
        }

        /// <summary>
        /// the method pulls a truck from the front of the line at a dock
        /// </summary>
        /// <returns>returns the 1st truck</returns>
        public Truck SendOff()
        {
            // does this method also need to make sure the truck is fully unloaded before it dequeues the truck? that needs to be done somewhere
            // as each crate is unloaded, the value can be added to TotalSales, and unloading a crate adds one time unit to TimeInUse
            return Line.Dequeue();

        }

    }
}
