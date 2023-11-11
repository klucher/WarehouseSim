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

        private string TablePath {  get; set; }

        /// <summary>
        /// creates a table with parameters for each crate
        /// </summary>
        /// <returns>table</returns>
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
            foreach(string s in table.Columns)
            {
                //need to make s equal all the 
                table.Rows.Add(s);
            }
            

            return table;

            //or do something with this?


        }

        public string CreateCSV()
        {
            var sb = new StringBuilder();

            //need to somehow put the stringbuilder to create a csv file path
            //and pull in the data from createDataTable?
            CreateDataTable();

            return sb.ToString();
        }


    }
}
