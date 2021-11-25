using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using HomeTask_23_11.DbContext.Entity;

namespace HomeTask_23_11.DbContext
{
    public class DbContext
    {
        public ObservableCollection<Division> Powerplant { get; } 

        public DbContext()
        {
            Powerplant = new ObservableCollection<Division>()
            {
                new Division() { DivisionName = "Electrics"},
                new Division() { DivisionName = "Engineers"},
                new Division() { DivisionName = "Mechanics"},
                new Division() { DivisionName = "Accountants"}
            };
        }
    }


}
