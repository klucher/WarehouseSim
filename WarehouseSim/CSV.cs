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


        // Tyler - I think you would need to add a constructor for the object and then you could access it from other classes when it is created?
        public CSV()
        {
            TablePath = SetFilePath();
            Table = CreateDataTable();
        }

        /// <summary>
        /// Asks a user for a file name. Then converts that string into a relative file path that can be used for saving the file
        /// </summary>
        /// <returns></returns>
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

            TablePath = Path.Combine("..\\CSV\\", $"{fileName}.csv");
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

        public void AddRow(Crate crate, Truck truck, Dock dock)
        {
            Table.Rows.Add(
                dock.TimeInUse,         //time incrememnt of crate being unloaded
                truck.Driver,           //truck driver's name
                truck.DeliveryCompany,  //delivery company name
                crate.Id,               //crate's id number
                crate.Price,            //crate's value
                string.Empty            //a string for one 3 scenarios depending on what happened:
                                        //crate unloaded with truck still having more crates
                                        //crate unloaded, truck is empty and no other trucks in line
                                        //crate unloaded, truck empty and another truck is in line
                );
        }

        public string CreateCSV(DataTable table)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(",", table.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

            foreach (DataRow row in table.Rows)
            {
                sb.AppendLine(string.Join(",", row.ItemArray));
            }

            return sb.ToString();
        }

        public void WriteToFile()
        {
            string csvContent = CreateCSV(Table);
            File.WriteAllText(TablePath, csvContent);
        }
    }
}
