using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class CSV
    {
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

        /// <summary>
        /// creates a table with parameters for each crate
        /// </summary>
        /// <returns>csv table</returns>
        public static DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Time Unloaded", typeof(string));
            table.Columns.Add("Driver's name", typeof(string));
            table.Columns.Add("Delivery Company", typeof(string));
            table.Columns.Add("Crate ID Number", typeof(int));
            table.Columns.Add("Crate's Value", typeof(int));
            table.Columns.Add("Scenario", typeof(string));

            //not quite sure how to do this yet? maybe a foreach loop?
            table.Rows.Add();

            return table;

            //or do something with this?


        }

        public string CreateCSV()
        {
            StringBuilder sb = new StringBuilder();
            sb

        }

    }
}
