///////////////////////////////////////////////////////////////////////
//
// Author: Melanie Magno, magnomk@etsu.edu && Tyler Campbell, campbellt5@etsu.edu && Jacob Klucher, klucher@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project3
// File Name: Program.cs
//
///////////////////////////////////////////////////////////////////////////////

namespace WarehouseSim
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Warehouse warehouse = new Warehouse();

            warehouse.Run();

            /* added this for testing just to see if the docks wer created correctly. can use for troubleshooting
             * foreach (Dock dock in warehouse.Docks)
            {
                Console.WriteLine(dock.Id);
            }
            */

        }
    }
}