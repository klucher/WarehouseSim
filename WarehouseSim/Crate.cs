///////////////////////////////////////////////////////////////////////////////
//
// Author: Melanie Magno, magnomk@etsu.edu && Tyler Campbell, campbellt5@etsu.edu && Jacob Klucher, klucher@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project3
// File Name: Crate.cs
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Crate
    {
        // id as a string with a get and set
        public string Id { get; set; }

        // price as a double to keep track of the cost of the contents from 50 to 500
        public double Price { get; set; }

        // id as an int that can be counted upward
        // to have all of the crates talk to each other, this variable will really need to be coming from somewhere outside of crate class
        // making this static might actually fix this issue, need to test to see
        private static int id = 0000001;


        /// <summary>
        /// a single box inside a truck, this method creates a random price between $50 and $500 and sets a unique ID
        /// for this crate
        /// </summary>
        /// <param name="Id">the unique ID number</param>
        public Crate()
        {
            Id = id++.ToString();
            Price = new Random().Next(50, 501);
        }
    }
}
