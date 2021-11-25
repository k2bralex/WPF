using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HomeTask_23_11.DbContext.Entity;

namespace HomeTask_23_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //создаем БД, наполнение классов в конуструкторах каждого класса
        //(для сохранения в файл прийдется немного переделать)
        public DbContext.DbContext PlantDb { get; set; }
        public object SelectedItem;

        public MainWindow()
        {
            InitializeComponent();

            PlantDb = new DbContext.DbContext();

            this.DataContext = PlantDb;

            AddWindow window = new AddWindow();
            window.ShowDialog();

        }

        //устанавливаем связь между выделенем на вкладке TabControl и Combobox 
        private void cbxDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbControl.SelectedIndex = cbxDivision.SelectedIndex;
        }
        private void TbControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxDivision.SelectedIndex = tbControl.SelectedIndex;
        }

        //логика доабвления нового работника
        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Employee newEmployee = new Employee();
            if (int.TryParse(tbxAge.Text, out int age) &&
                !string.IsNullOrWhiteSpace(tbxName.Text))
            {
                newEmployee.Name = tbxName.Text;
                newEmployee.Age = int.Parse(tbxAge.Text);

            }

            foreach (var p in PlantDb.Powerplant)
            {
                if (p.DivisionName == cbxDivision.SelectedItem.ToString())
                    p.Employees.Add(newEmployee);
            }

        }

        //внесение изменений в работника
        //(работает криво? т/к/ из-за динамического создания ListView не хватает знаний для корректного
        //доступа к эелементам БД)
        //изменения вносятся? но при ётом солздается новый работник с следующим ID
        private void BtnChange_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var p in PlantDb.Powerplant)
            {
                if (p.Employees.Contains(SelectedItem as Employee))
                {
                    int index = p.Employees.IndexOf(SelectedItem as Employee);
                    Employee changeEmployee =  p.Employees[index];
                    p.Employees.RemoveAt(index);    
                    changeEmployee.Name = tbxName.Text;
                    changeEmployee.Age = int.Parse(tbxAge.Text);
                    p.Employees.Add(changeEmployee);
                    SelectedItem = changeEmployee;
                }
            }
        }

        //при выборе сотруджника в листе его данные заполняют соответствующие поля TextBox-ов
        private void LvEmployees_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView control = (ListView)sender;
            var item = control.SelectedItem;
            if (item != null)
            {
                tbxName.Text = (item as Employee).Name;
                tbxAge.Text = (item as Employee).Age.ToString();
            }
            //костыль для передачи в кнопку ИЗМЕНИТЬ выбранного элемента
            SelectedItem = item;
        }


        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != null)
            {
                foreach (var p in PlantDb.Powerplant)
                {
                    if (p.Employees.Contains(SelectedItem as Employee))
                    {
                        p.Employees.Remove(SelectedItem as Employee);
                        SelectedItem = null;
                    }
                }
            }
        }
    }
}
