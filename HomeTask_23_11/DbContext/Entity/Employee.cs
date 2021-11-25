using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using HomeTask_23_11.Annotations;

namespace HomeTask_23_11.DbContext.Entity
{
    public class Employee : INotifyPropertyChanged
    {
        public static int Count = 0;
        private string name;
        private int age;
        
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(name));
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged(nameof(age));
            }
        }

        public int Id { get; private set; }

        public Employee()
        {
            Id = ++Count;
        }
        public override string ToString()
        {
            return $"{Id}\t||\t{Name}\t||\t{Age}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
