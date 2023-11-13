///////////////////////////////////////////////////////////////////////////////
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
        public double PrevCrateValue { get; set; }
        public double TruckValue { get; set; }

        public Stack<Crate> Trailer;

        /// <summary>
        /// creates a truck with a driver and company sponsor and stack of crates
        /// </summary>
        /// <param name="driver">the driver of this truck</param>
        /// <param name="deliveryCompany">the company the truck is shipping for</param>
        public Truck(string driver, string deliveryCompany)
        {
            this.Driver = driver;
            this.DeliveryCompany = deliveryCompany;
            Trailer = new Stack<Crate>();
            TruckValue = 0;

            // currently having each truck start with a random number of crates between 5 and 15 
            Random rand = new Random();
            CrateCount = rand.Next(5, 16);
            RemainingCrates = CrateCount;
            for (int i = 0; i < CrateCount; i++)
            {
                Load(new Crate());
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

            // also accumulating the crate value while removing them from the truck
            PrevCrateValue = crate.Price;
            TruckValue += crate.Price;
            RemainingCrates--;
            return crate;
        }
    }
}
