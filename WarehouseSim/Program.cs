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
            Console.WriteLine("Total Sales: " + warehouse.GetTotalSales());
            Console.WriteLine("Crates Unloaded: " + warehouse.GetTotalCreatesUnloaded());
            Console.WriteLine("Time In Use: " + warehouse.GetTotalTimeInUse());
            Console.WriteLine("Time Not In Use: " + warehouse.GetTotalTimeNotInUse());
        }
    }
}