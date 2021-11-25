using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using HomeTask_23_11.Annotations;

namespace HomeTask_23_11.DbContext.Entity
{
    public class Division : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public Division()
        {
            Employees = new ObservableCollection<Employee>()
            {
                new Employee() {Name = "Sergey Petrov", Age = 25},
                new Employee() {Name = "Petr Sergeev", Age = 30},
                new Employee() {Name = "Ivan Kuznetsov", Age =35},
                new Employee() {Name = "Kuznets Ivanov", Age = 40},
            };
        }

        private string divisionName;
        public string DivisionName
        {
            get => divisionName;
            set
            {
                divisionName = value;
                OnPropertyChanged(nameof(divisionName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return DivisionName;
        }
    }
}
