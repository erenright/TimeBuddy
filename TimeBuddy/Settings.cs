﻿/*
 * Settings.cs
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
using System.Xml;

namespace TimeBuddy
{
    [Serializable]
    public class Settings
    {
        private string _version = "0.3";

        private List<Task> _tasks;
        private int _startHour;
        private int _startMinute;
        private int _endHour;
        private int _endMinute;
        private bool _hourlyReminderEnabled;
        private string _hourlyReminder;

        public string Version
        {
            get { return _version; }
            set { /* No-op; required by XmlSerializer */ }
        }

        public List<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        public int StartHour
        {
            get { return _startHour; }
            set { _startHour = value; }
        }

        public int StartMinute
        {
            get { return _startMinute; }
            set { _startMinute = value; }
        }

        public int EndHour
        {
            get { return _endHour; }
            set { _endHour = value; }
        }

        public int EndMinute
        {
            get { return _endMinute; }
            set { _endMinute = value; }
        }

        public bool HourlyReminderEnabled
        {
            get { return _hourlyReminderEnabled; }
            set { _hourlyReminderEnabled = value; }
        }

        public string HourlyReminder
        {
            get { return _hourlyReminder; }
            set { _hourlyReminder = value; }
        }

        /// <summary>
        /// Whether or not the report should round summaries.
        /// </summary>
        public bool RoundSummaries { get; set; }

        /// <summary>
        /// The number of minutes to which summaries should be rounded, if enabled.
        /// </summary>
        public int SummaryRoundPoint { get; set; }

        /*
         * Imports version 0 of the settings file.
         */
        private void Load_Version0(XmlElement root)
        {
            // Load StartHour
            XmlNodeList nodes = root.GetElementsByTagName("StartHour");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0 missing StartHour");

            string startHour = nodes[0].InnerText;

            try
            {
                StartHour = Convert.ToInt32(startHour);
            }
            catch (Exception e)
            {
                throw new Exception("Version0 corrupt StartHour", e);
            }


            // Load StartMinute
            nodes = root.GetElementsByTagName("StartMinute");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0 missing StartMinute");

            string startMinute = nodes[0].InnerText;

            try
            {
                StartMinute = Convert.ToInt32(startMinute);
            }
            catch (Exception e)
            {
                throw new Exception("Version0 corrupt StartMinute", e);
            }

            // Load EndHour
            nodes = root.GetElementsByTagName("EndHour");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0 missing EndHour");

            string endHour = nodes[0].InnerText;

            try
            {
                EndHour = Convert.ToInt32(endHour);
            }
            catch (Exception e)
            {
                throw new Exception("Version0 corrupt EndHour", e);
            }


            // Load EndMinute
            nodes = root.GetElementsByTagName("EndMinute");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0 missing EndMinute");

            string endMinute = nodes[0].InnerText;

            try
            {
                EndMinute = Convert.ToInt32(endMinute);
            }
            catch (Exception e)
            {
                throw new Exception("Version0 corrupt EndMinute", e);
            }


            // Load tasks
            nodes = root.GetElementsByTagName("Task");
            if (nodes == null)
                throw new Exception("Version0 missing tasks");

            _tasks = new List<Task>();

            foreach (XmlNode node in nodes)
            {
                XmlNodeList childNodes = node.ChildNodes;
                if (childNodes == null)
                    throw new Exception("Version0 has invalid tasks");

                string name = "";
                int seconds = -123456; // Unlikely to be found in the wild

                foreach (XmlNode childNode in childNodes)
                {
                    if (childNode.Name == "Name")
                    {
                        name = childNode.InnerText;
                    }
                    else if (childNode.Name == "RawSeconds")
                    {
                        try
                        {
                            seconds = Convert.ToInt32(childNode.InnerText);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Version0 has invalid tasks", e);
                        }
                    }
                }

                if (name == "" || seconds == -123456)
                    throw new Exception("Version0 has invalid tasks");

                Task task = new Task();
                task.Name = name;
                task.RawSeconds = seconds;

                _tasks.Add(task);
            }

        }

        /*
         * Imports/loads version 0.1 of the settings file.
         */
        private void Load_Version0_1(XmlElement root)
        {
            // Load StartHour
            XmlNodeList nodes = root.GetElementsByTagName("StartHour");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_1 missing StartHour");

            string startHour = nodes[0].InnerText;

            try
            {
                StartHour = Convert.ToInt32(startHour);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_1 corrupt StartHour", e);
            }


            // Load StartMinute
            nodes = root.GetElementsByTagName("StartMinute");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_1 missing StartMinute");

            string startMinute = nodes[0].InnerText;

            try
            {
                StartMinute = Convert.ToInt32(startMinute);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_1 corrupt StartMinute", e);
            }

            // Load EndHour
            nodes = root.GetElementsByTagName("EndHour");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_1 missing EndHour");

            string endHour = nodes[0].InnerText;

            try
            {
                EndHour = Convert.ToInt32(endHour);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_1 corrupt EndHour", e);
            }


            // Load EndMinute
            nodes = root.GetElementsByTagName("EndMinute");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_1 missing EndMinute");

            string endMinute = nodes[0].InnerText;

            try
            {
                EndMinute = Convert.ToInt32(endMinute);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_1 corrupt EndMinute", e);
            }


            // Load tasks
            nodes = root.GetElementsByTagName("Task");
            if (nodes == null)
                throw new Exception("Version0_1 missing tasks");

            _tasks = new List<Task>();

            foreach (XmlNode node in nodes)
            {
                XmlNodeList childNodes = node.ChildNodes;
                if (childNodes == null)
                    throw new Exception("Version0_1 has invalid tasks");

                string name = "";
                int seconds = -123456; // Unlikely to be found in the wild
                int maxSeconds = -123456;

                foreach (XmlNode childNode in childNodes)
                {
                    if (childNode.Name == "Name")
                    {
                        name = childNode.InnerText;
                    }
                    else if (childNode.Name == "RawSeconds")
                    {
                        try
                        {
                            seconds = Convert.ToInt32(childNode.InnerText);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Version0_1 has invalid tasks", e);
                        }
                    }
                    else if (childNode.Name == "MaxSeconds")
                    {
                        try
                        {
                            maxSeconds = Convert.ToInt32(childNode.InnerText);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Version0_1 has invalid tasks", e);
                        }
                    }
                }

                if (name == "" || seconds == -123456 || maxSeconds == -123456)
                    throw new Exception("Version0_1 has invalid tasks");

                Task task = new Task();
                task.Name = name;
                task.RawSeconds = seconds;
                task.MaxSeconds = maxSeconds;

                _tasks.Add(task);
            }
        }

        /*
         * Imports/loads version 0.2 of the settings file.
         */
        private void Load_Version0_2(XmlElement root)
        {
            // Load StartHour
            XmlNodeList nodes = root.GetElementsByTagName("StartHour");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_2 missing StartHour");

            string startHour = nodes[0].InnerText;

            try
            {
                StartHour = Convert.ToInt32(startHour);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_2 corrupt StartHour", e);
            }


            // Load StartMinute
            nodes = root.GetElementsByTagName("StartMinute");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_2 missing StartMinute");

            string startMinute = nodes[0].InnerText;

            try
            {
                StartMinute = Convert.ToInt32(startMinute);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_2 corrupt StartMinute", e);
            }

            // Load EndHour
            nodes = root.GetElementsByTagName("EndHour");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_2 missing EndHour");

            string endHour = nodes[0].InnerText;

            try
            {
                EndHour = Convert.ToInt32(endHour);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_2 corrupt EndHour", e);
            }


            // Load EndMinute
            nodes = root.GetElementsByTagName("EndMinute");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_2 missing EndMinute");

            string endMinute = nodes[0].InnerText;

            try
            {
                EndMinute = Convert.ToInt32(endMinute);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_2 corrupt EndMinute", e);
            }

            // Load HourlyReminderEnabled
            nodes = root.GetElementsByTagName("HourlyReminderEnabled");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_2 missing HourlyReminderEnabled");

            string hourlyReminderEnabled = nodes[0].InnerText;

            try
            {
                HourlyReminderEnabled = Convert.ToBoolean(hourlyReminderEnabled);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_2 corrupt HourlyReminderEnabled", e);
            }

            // Load HourlyReminder
            nodes = root.GetElementsByTagName("HourlyReminder");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_2 missing HourlyReminder");

            HourlyReminder = nodes[0].InnerText;


            // Load tasks
            nodes = root.GetElementsByTagName("Task");
            if (nodes == null)
                throw new Exception("Version0_2 missing tasks");

            _tasks = new List<Task>();

            foreach (XmlNode node in nodes)
            {
                XmlNodeList childNodes = node.ChildNodes;
                if (childNodes == null)
                    throw new Exception("Version0_2 has invalid tasks");

                string name = "";
                int seconds = -123456; // Unlikely to be found in the wild
                int maxSeconds = -123456;

                foreach (XmlNode childNode in childNodes)
                {
                    if (childNode.Name == "Name")
                    {
                        name = childNode.InnerText;
                    }
                    else if (childNode.Name == "RawSeconds")
                    {
                        try
                        {
                            seconds = Convert.ToInt32(childNode.InnerText);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Version0_2 has invalid tasks", e);
                        }
                    }
                    else if (childNode.Name == "MaxSeconds")
                    {
                        try
                        {
                            maxSeconds = Convert.ToInt32(childNode.InnerText);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Version0_2 has invalid tasks", e);
                        }
                    }
                }

                if (name == "" || seconds == -123456 || maxSeconds == -123456)
                    throw new Exception("Version0_2 has invalid tasks");

                Task task = new Task();
                task.Name = name;
                task.RawSeconds = seconds;
                task.MaxSeconds = maxSeconds;

                _tasks.Add(task);
            }
        }

        /*
         * Imports/loads version 0.3 of the settings file.
         */
        private void Load_Version0_3(XmlElement root)
        {
            // Load StartHour
            XmlNodeList nodes = root.GetElementsByTagName("StartHour");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_3 missing StartHour");

            string startHour = nodes[0].InnerText;

            try
            {
                StartHour = Convert.ToInt32(startHour);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_3 corrupt StartHour", e);
            }


            // Load StartMinute
            nodes = root.GetElementsByTagName("StartMinute");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_3 missing StartMinute");

            string startMinute = nodes[0].InnerText;

            try
            {
                StartMinute = Convert.ToInt32(startMinute);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_3 corrupt StartMinute", e);
            }

            // Load EndHour
            nodes = root.GetElementsByTagName("EndHour");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_3 missing EndHour");

            string endHour = nodes[0].InnerText;

            try
            {
                EndHour = Convert.ToInt32(endHour);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_3 corrupt EndHour", e);
            }


            // Load EndMinute
            nodes = root.GetElementsByTagName("EndMinute");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_3 missing EndMinute");

            string endMinute = nodes[0].InnerText;

            try
            {
                EndMinute = Convert.ToInt32(endMinute);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_3 corrupt EndMinute", e);
            }

            // Load HourlyReminderEnabled
            nodes = root.GetElementsByTagName("HourlyReminderEnabled");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_3 missing HourlyReminderEnabled");

            string hourlyReminderEnabled = nodes[0].InnerText;

            try
            {
                HourlyReminderEnabled = Convert.ToBoolean(hourlyReminderEnabled);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_3 corrupt HourlyReminderEnabled", e);
            }

            // Load HourlyReminder
            nodes = root.GetElementsByTagName("HourlyReminder");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_3 missing HourlyReminder");

            HourlyReminder = nodes[0].InnerText;

            // RoundSummaries
            nodes = root.GetElementsByTagName("RoundSummaries");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_3 missing RoundSummaries");

            try
            {
                RoundSummaries = Convert.ToBoolean(nodes[0].InnerText);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_3 has invalid RoundSummaries", e);
            }

            // Load SummaryRoundPoint
            nodes = root.GetElementsByTagName("SummaryRoundPoint");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
                throw new Exception("Version0_3 missing SummaryRoundPoint");

            try
            {
                SummaryRoundPoint = Convert.ToInt32(nodes[0].InnerText);
            }
            catch (Exception e)
            {
                throw new Exception("Version0_3 corrupt SummaryRoundPoint", e);
            }

            
            // Load tasks
            nodes = root.GetElementsByTagName("Task");
            if (nodes == null)
                throw new Exception("Version0_3 missing tasks");

            _tasks = new List<Task>();

            foreach (XmlNode node in nodes)
            {
                XmlNodeList childNodes = node.ChildNodes;
                if (childNodes == null)
                    throw new Exception("Version0_3 has invalid tasks");

                string name = "";
                int seconds = -123456; // Unlikely to be found in the wild
                int maxSeconds = -123456;

                foreach (XmlNode childNode in childNodes)
                {
                    if (childNode.Name == "Name")
                    {
                        name = childNode.InnerText;
                    }
                    else if (childNode.Name == "RawSeconds")
                    {
                        try
                        {
                            seconds = Convert.ToInt32(childNode.InnerText);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Version0_3 has invalid tasks", e);
                        }
                    }
                    else if (childNode.Name == "MaxSeconds")
                    {
                        try
                        {
                            maxSeconds = Convert.ToInt32(childNode.InnerText);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Version0_3 has invalid tasks", e);
                        }
                    }
                }

                if (name == "" || seconds == -123456 || maxSeconds == -123456)
                    throw new Exception("Version0_3 has invalid tasks");

                Task task = new Task();
                task.Name = name;
                task.RawSeconds = seconds;
                task.MaxSeconds = maxSeconds;

                _tasks.Add(task);
            }
        }

        /*
         * Load saved tasks.  First the version number is queried,
         * and then the data passed off to the appropriate loader.
         * 
         * _version will be left unmolested, since anything loaded
         * will be imported to this version.
         * 
         * Return value is true if a previous version was imported.
         */
        public bool Load(string filename)
        {
            // Parse the XML file
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            // Get root node
            XmlNodeList nodes = doc.GetElementsByTagName("Settings");
            if (nodes == null || nodes.Count == 0 || nodes.Count > 1)
            {
                // This is an invalid file
                throw new Exception("Invalid settings file");
            }

            XmlElement root = (XmlElement)nodes[0];

            // Determine version
            nodes = root.GetElementsByTagName("Version");
            if (nodes == null || nodes.Count == 0)
            {
                // There is no version, so this must be Version0
                Load_Version0(root);
                return true;    // Notify user that we imported data
            }

            string version = nodes[0].InnerText;
            if (version == null || version == "")
                throw new Exception("Invalid settings version");

            // Dispatch version parsing
            bool imported = false;

            if (version == "0.1")
            {
                Load_Version0_1(root);
                imported = true;    // Notify user that we imported data
            }
            else if (version == "0.2")
            {
                Load_Version0_2(root);
                imported = true;    // Notify user that we imported data
            }
            else if (version == "0.3")
            {
                Load_Version0_3(root);
                imported = false;   // Normal load, so no message to user
            }
            else
            {
                throw new Exception("Unknown settings version");
            }

            return imported;
        }
    }
}
