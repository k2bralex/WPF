using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_START
{
    public class TaskData
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string TaskText { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
