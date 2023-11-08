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

        public Warehouse()
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
        }

        public void Run()
        {
            //this is probably where we could start creating the new trucks and adding them to the Dock line etc. or calling other methods from here to do that

            //need a while loop for trucks to appear, need to create a random number generator
            //using NextDouble() then compare that to predetermined percentages based on what time of day it is
            //use bell curve for the chance of a truck to show up. If it is less than 24 increments, then divide the current increment by 24
            //if it is over 24, divide that number minus 24 by 24

        }

        //tasks to do
        //create a method that returns a csv file
        //create a time increment variable that starts at 0 and ends at the end of the day (should be 47)
        //in crate unload method, need to check the time increment variable
        //In crate unload method (or somewhere like that, there needs to be a string that is returned if a crate is unloaded:
        //crate unloaded, but there are still more trucks to unload
        //crate unloaded, truck is empty AND another truck is in the dock
        //crate unloaded, truck is empty AND there is NOT another truck in the dock

        //potentially need to eventually create new method that opens new docks as it gets closer to noon and closes docks as it gets further away



        //csv file to be created:
        //needs to return:  
        //time incrememnt of crate being unloaded
        //truck driver's name
        //delivery company name
        //crate's id number
        //crate's value
        //a string for one 3 scenarios depending on what happened
        //crate unloaded with truck still having more crates
        //crate unloaded, truck is empty and no other trucks in line
        //crate unloaded, truck empty and another truck is in line

        //to do this:
        //might be easier to create a new class that creates a Data Table
        //within this class, will need to make a DataTable table that is a new DataTable();
        //use table.Columns.Add("name of column", typeof(string/int/etc));
        //do this for each column needed (use above info to do
        //use table.Rows.Add(specific info to be added)? might have to tweak this

        //format might look like:
        //public static class CsvTable
        //{
        //public static DataTable CreateCsv()
        //{
        //DataTable table = new DataTable();
        //table.Columns.Add("Time Unloaded", typeof(int));
        //table.Columns.Add("Driver's name", typeof(string));
        //etc





    }
}
