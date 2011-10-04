/*
 * Task.cs
 * 
 * Copyright (C) 2011 5amsoftware
 * 
 * All rights reserved.  Distribution an modification strictly prohibited.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeBuddy
{
    public class Task
    {
        private string _Name;                   // Name of the task
        private int _seconds = 0;               // Number of seconds the task has been active (running counter)
        private bool _active = false;           // Whether or not the task is active.  If true, no other tasks are.

        public bool Active
        {
            set { _active = value; }
            get { return _active; }
        }

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public int RawSeconds
        {
            get { return _seconds; }
            set { _seconds = value; }
        }

        public int Minutes
        {
            get { return (RawSeconds - (Hours * 60 * 60)) / 60; }
        }

        public decimal HoursFractional
        {
            get { return Math.Round(Hours + ((decimal)Minutes / 60), 2); }
        }

        public int Hours
        {
            get { return RawSeconds / 60 / 60; }
        }

        public string HHMM
        {
            get { return String.Format("{0}:{1:00}", Hours, Minutes); }
        }

        public Task()
        {
            // Stub for XmlSerializer
        }
        
        public Task(string name)
        {
            Name = name;
        }

        /*
         * Tick function called once per second.  Increments the
         * seconds counter.
         */
        public void Tick()
        {
            if (Active)
            {
                ++_seconds;
                //_seconds += 60; // for testing
            }
        }

        public void Adjust(int seconds)
        {
            _seconds += seconds;
        }

        public void Clear()
        {
            _seconds = 0;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}:{2:00}", Name, Hours, Minutes);
        }
    }
}
