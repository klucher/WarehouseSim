///////////////////////////////////////////////////////////////////////
//
// Author: Melanie Magno, magnomk@etsu.edu && Tyler Campbell, campbellt5@etsu.edu && Jacob Klucher, klucher@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project3
// File Name: Program.cs
//
///////////////////////////////////////////////////////////////////////////////

using System.Data;

namespace WarehouseSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.Run();
            Console.WriteLine("\n\nTotal Sales: " + warehouse.GetTotalSales());
            Console.WriteLine("Crates Unloaded: " + warehouse.GetTotalCreatesUnloaded());
            Console.WriteLine("Time In Use: " + warehouse.GetTotalTimeInUse());
            Console.WriteLine("Time Not In Use: " + warehouse.GetTotalTimeNotInUse());





            // adding some prints here to match the beginning of the assignment
            Console.WriteLine($"\n\nFor this run of the program there was {warehouse.DocksAmount} dock(s) simulated.");
            int TotTrucksProcessed = 0;
            for (int i = 0; i < warehouse.Docks.Count; i++)
            {
                Console.WriteLine($"The longest line in dock {i+1} was {warehouse.Docks[i].LongestLine} trucks.");
                TotTrucksProcessed += warehouse.Docks[i].TotalTrucksProcessed;
            }
            Console.WriteLine($"The total number of trucks processed through a dock was {TotTrucksProcessed}.");
            Console.WriteLine($"The total number of trucks that passed through the gate was {warehouse.TotTrucksSpawned}.");
            Console.WriteLine("Total of Crates Unloaded was " + warehouse.GetTotalCreatesUnloaded() + ".");
            Console.WriteLine("Total Value of Crates unloaded was $" + warehouse.GetTotalSales() + ".");
            Console.WriteLine($"The Average Value of each crate unloaded was ${Math.Round(warehouse.GetTotalSales() / warehouse.GetTotalCreatesUnloaded(), 2)}.");
            Console.WriteLine($"The Average Value of each truck processed was ${Math.Round(warehouse.GetTotalSales() / TotTrucksProcessed, 2)}.");
            for (int i = 0; i < warehouse.Docks.Count; i++)
            {
                Console.WriteLine($"Dock {i + 1} was in use for {warehouse.Docks[i].TimeInUse} time increments.");
                Console.WriteLine($"Dock {i + 1} was not in use for {warehouse.Docks[i].TimeNotInUse} time increments.");
            }
            Console.WriteLine($"The average amount of time a dock was in use is {warehouse.GetTotalTimeInUse() / warehouse.DocksAmount} time increments.");
            Console.WriteLine($"The total operating cost for {warehouse.DocksAmount} dock(s) is ${48 * 100 * warehouse.DocksAmount}.");
            Console.WriteLine($"Total profits are ${warehouse.GetTotalSales() - (48 * 100 * warehouse.DocksAmount)}.");

        }
    }
}