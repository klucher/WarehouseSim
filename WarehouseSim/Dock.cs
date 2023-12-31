﻿///////////////////////////////////////////////////////////////////////////////
//
// Author: Melanie Magno, magnomk@etsu.edu && Tyler Campbell, campbellt5@etsu.edu && Jacob Klucher, klucher@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project3
// File Name: Dock.cs
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Dock
    {
        public string Id { get; set; }
        public Queue<Truck> Line { get; set; }
        public double TotalSales { get; set; }
        public int TotalCrates { get; set; }
        public int TotalTrucksProcessed { get; set; }
        public int TrucksInLine {  get; set; }
        public int LongestLine {  get; set; }
        public int TimeInUse { get; set; }
        public int TimeNotInUse { get; set; }
        public Truck CurrentTruck { get; set; }

        private static int id = 0000001;

        /// <summary>
        /// default constructor to create and intialize an empty dock
        /// </summary>
        /// <param name="Id">the name/UIN of the dock</param>
        public Dock()
        {
            Id = id++.ToString();
            Line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TotalTrucksProcessed = 0;
            TrucksInLine = 0;
            LongestLine = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
            CurrentTruck = null;
        }

        /// <summary>
        /// This method adds a truck to a queue at a specific dock.
        /// </summary>
        /// <param name="truck">the truck being added to the line at the dock</param>
        public void JoinLine(Truck truck)
        {
            Line.Enqueue(truck);
            TrucksInLine++;

            //this code will update the longest line throughout the day at the dock
            if (TrucksInLine > LongestLine)
            {
                LongestLine = TrucksInLine;
            }
        }

        /// <summary>
        /// the method pulls a truck from the front of the line at a dock to be unloaded. it decrements the count of trucks in line during this process
        /// </summary>
        /// <returns>returns the 1st truck</returns>
        public Truck SendOff()
        {
            this.CurrentTruck = Line.Dequeue();
            TrucksInLine--;
            TotalTrucksProcessed++;
            // the below line adds the truck that is being unloadeds crate count to the overall dock crate count
            TotalCrates += CurrentTruck.CrateCount;
            return CurrentTruck;

        }

        /// <summary>
        /// checks whether a truck is currently being unloaded at a dock
        /// </summary>
        /// <returns>false if truck is empty and done unloading or if no truck at all; returns true otherwise</returns>
        public bool Unloading()
        {
            if (CurrentTruck == null)
            {
                return false;
            }
            //else if (currentTruck.Trailer.Peek() == null )  //this was causing a crash when checking if the stack was == null?
            else if (CurrentTruck.RemainingCrates == 0) 
            {
                CurrentTruck = null; // when the remaining crates is zero we should have no current truck
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
