///////////////////////////////////////////////////////////////////////////////
//
// Author: Melanie Magno, magnomk@etsu.edu && Tyler Campbell, campbellt5@etsu.edu && Jacob Klucher, klucher@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project3
// File Name: CSV.cs
//
///////////////////////////////////////////////////////////////////////////////

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
        private string TablePath {  get; set; }
        private DataTable Table { get; set; }

        public Warehouse warehouseSim {  get; set; }


        // Tyler - I think you would need to add a constructor for the object and then you could access it from other classes when it is created?

        /// <summary>
        /// calls other methods to create a csv file by setting the file path and creating a data table
        /// </summary>
        public CSV(Warehouse warehouseSim)
        {
            this.warehouseSim = warehouseSim;
            TablePath = SetFilePath();
            Table = CreateDataTable();
        }

        /// <summary>
        /// Asks a user for a file name. Then converts that string into a relative file path that can be used for saving the file
        /// </summary>
        /// <returns>file path for the table</returns>
        public string SetFilePath()
        {
            string fileName = string.Empty;
            bool goodEntry = false;

            while (!goodEntry || string.IsNullOrEmpty(fileName))
            {
                try
                {
                    Console.WriteLine("What would you like to name your csv file?");
                    fileName = Console.ReadLine();
                    goodEntry = true;
                }
                catch
                {
                    Console.WriteLine("Error, please enter a valid file name.");
                }
            }
            Console.WriteLine("CSV " + fileName + " created.");
            TablePath = Path.Combine(".\\CSV\\", $"{fileName}.csv");
            return TablePath;
        }


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

            return table;
        }

        /// <summary>
        /// adds the sub-info of each crate, dock, and truck at a particular point in time
        /// </summary>
        /// <param name="crate">the crate</param>
        /// <param name="truck">the truck</param>
        /// <param name="dock">the dock</param>
        public void AddRow(Crate crate, Truck truck, Dock dock)
        {
            string scene = "0";
            if(truck.CrateCount != 0)
            {
                scene = "A crate was unloaded but the truck still has more crates to unload";
            }
            if(truck.CrateCount == 0 && dock.TrucksInLine == 0)
            {
                scene = "A crate was unloaded and the truck has no more crates to unload and another truck is already in the Dock";
            }
            if(truck.CrateCount == 0 && dock.TrucksInLine != 0)
            {
                scene = "A crate was unloaded and the truck has no more crates to unload but another truck is NOT already in the Dock";
            }

            Table.Rows.Add(
                warehouseSim.timeIntervals,         //time incrememnt of crate being unloaded
                truck.Driver,                       //truck driver's name
                truck.DeliveryCompany,              //delivery company name
                crate.Id,                           //crate's id number
                crate.Price,                        //crate's value
                string.Empty                        //a string for one 3 scenarios depending on what happened:
                                                    //crate unloaded with truck still having more crates
                                                    //crate unloaded, truck is empty and no other trucks in line
                                                    //crate unloaded, truck empty and another truck is in line
                );
        }

        /// <summary>
        /// creates the backbone of a CSV file which is composed of column names and data entries
        /// </summary>
        /// <param name="table">a table of column names and row data</param>
        /// <returns>completed table</returns>
        public string CreateCSV(DataTable table)
        {
            var sb = new StringBuilder();

            //joining the columns into a comma separated list
            sb.AppendLine(string.Join(",", table.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

            foreach (DataRow row in table.Rows)
            {
                sb.AppendLine(string.Join(",", row.ItemArray));
            }

            return sb.ToString();
        }

        /// <summary>
        /// all the data content that is turned into a table is returned as a file
        /// </summary>
        public void WriteToFile()
        {
            try
            {
                // Create the directory if it doesn't exist
                string directoryPath = Path.GetDirectoryName(TablePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Write the CSV content to the file
                string csvContent = CreateCSV(Table);
                File.WriteAllText(TablePath, csvContent);

                Console.WriteLine($"CSV file successfully created at: {TablePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating CSV file: {ex.Message}");
            }
        }
    }
}
