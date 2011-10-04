﻿/*
 * Settings.cs
 * 
 * Copyright (C) 2011 5amsoftware.com
 * 
 * All rights reserved.  Distribution an modification strictly prohibited.
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
        private string _version = "0.1";

        private List<Task> _tasks;
        private int _startHour;
        private int _startMinute;
        private int _endHour;
        private int _endMinute;

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
         * Imports/loads version 0.1 of the settings file.  This format
         * piggy backs on version 0.
         */
        private void Load_Version0_1(XmlElement root)
        {
            // Load basic stuff
            Load_Version0(root);

            // Load new items
            // ...
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
                return true;
            }

            string version = nodes[0].InnerText;
            if (version == null || version == "")
                throw new Exception("Invalid settings version");

            // Dispatch version parsing
            bool imported = false;

            if (version == "0.1")
            {
                Load_Version0_1(root);
                imported = false;
            }
            else
                throw new Exception("Unknown settings version");

            return imported;
        }
    }
}
