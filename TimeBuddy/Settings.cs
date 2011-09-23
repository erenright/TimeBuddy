using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeBuddy
{
    [Serializable]
    public class Settings
    {
        private List<Task> _tasks;
        private int _startHour;
        private int _startMinute;
        private int _endHour;
        private int _endMinute;

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
    }
}
