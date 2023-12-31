﻿///////////////////////////////////////////////////////////////////////////////
//
// Author: Melanie Magno, magnomk@etsu.edu && Tyler Campbell, campbellt5@etsu.edu && Jacob Klucher, klucher@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project3
// File Name: Truck.cs
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Truck
    {
        public string Driver { get; set; }
        public string DeliveryCompany { get; set; }
        public int CrateCount { get; set; }
        public int RemainingCrates { get; set; }
        public Crate CurrentCrate { get; set; }
        public double PrevCrateValue { get; set; }
        public double TruckValue { get; set; }

        public Stack<Crate> Trailer;

        /// <summary>
        /// creates a truck with a driver and company sponsor that are passed in and creates a new stack of crates.
        /// the number of crates in the truck is randomly generated from 5-15. the amount of crates that has not been unloaded yet is also tracked
        /// </summary>
        /// <param name="driver">the driver of this truck</param>
        /// <param name="deliveryCompany">the company the truck is shipping for</param>
        public Truck(string driver, string deliveryCompany)
        {
            this.Driver = driver;
            this.DeliveryCompany = deliveryCompany;
            Trailer = new Stack<Crate>();
            TruckValue = 0;
            CurrentCrate = null;

            // currently having each truck start with a random number of crates between 5 and 15 
            Random rand = new Random();
            CrateCount = rand.Next(5, 16);
            RemainingCrates = CrateCount;
            for (int i = 0; i < CrateCount; i++)
            {
                Crate newCrate = new Crate();
                Load(newCrate);
                CurrentCrate = newCrate;
            }

        }

        /// <summary>
        /// loads/adds a crate into a truck's crate stack front of the line
        /// </summary>
        /// <param name="crate">a crate being put into a truck</param>
        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }

        /// <summary>
        /// removes a crate from a truck's stack/trailer -- LIFO
        /// </summary>
        /// <returns>the crate at the top of the stack</returns>
        public Crate Unload()
        {
            Crate crate = Trailer.Pop();
            
            // adding this currentcrate variable so that it can be accessed for the csv writing
            CurrentCrate = crate;

            // also accumulating the crate value while removing them from the truck
            PrevCrateValue = crate.Price;
            //updates the trucks value as each crate is unloaded, since we cut off the unloading at the end of the 48 time increments
            TruckValue += crate.Price;
            //decrements the count of the remaining crates now that one has been successfully unloaded
            RemainingCrates--;
            return crate;
        }
    }
}
