/*
 * Task.cs
 * 
 * Copyright (c) 2011-2020, Eric Enright
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *
 *     * Neither the name of Eric Enright nor the
 *       names of his contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL ERIC ENRIGHT BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
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
        private int _maxSeconds = 0;            // Max. seconds to be tracked before a warning is issued. Zero to disable.

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

        public int MaxSeconds
        {
            get { return _maxSeconds; }
            set { _maxSeconds = value; }
        }

        // Stuff below this line should not be serialized

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
            return String.Format("{0}{1} - {2}:{3:00}", Active ? "* " : "", Name, Hours, Minutes);
        }
    }
}
