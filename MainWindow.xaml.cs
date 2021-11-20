using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Calculator;

namespace WPF_START
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TaskData> taskList = new List<TaskData>()
        {
            new TaskData { Name = "Задание 1", FullName = "Разноцветные кнопки", 
            TaskText="Необходимо разработать приложение содержащее набор кнопок, занимающих" +
                " 2/3 ширины окна при любых его размерах. Каждая кнопка должна в качестве " +
                "содержимого отображать название цвета и обладать наружным отступом равным " +
                "2.0. Также соответствующий цвет должен использоваться в качестве цвета " +
                "переднего плана кнопки. Необходимо использовать следующий набор цветов: " +
                "Navy, Blue, Aqua, Teal, Olive, Green, Lime, Yellow, Orange, Red, Maroon, " +
                "Fuchsia, Purple, Black, Silver, Gray, White."},
            new TaskData { Name = "Задание 2", FullName = "Калькулятор",
            TaskText = "Необходимо разработать приложение «Калькулятор». В верхней части приложения " +
                "необходимо использовать два поля для ввода текста. Первое используется для отображения " +
                "предыдущих операций, а второе — для ввода текущего числа. Оба поля должны запрещать " +
                "редактировать свое содержимое посредством клавиатурного ввода. Данные поля будут " +
                "заполняться автоматически при нажатии на соответствующие кнопки, расположенные ниже." +
                "Кнопки «0» — «9» добавляют соответствующую цифрув конец текущего числа. При этом должны " +
                "выполняться проверки, не допускающие неправильного ввода. Например, нельзя вводить числа, " +
                "начинающиеся с ноля, после которого нет десятичной точки. " +
                "Кнопка «.» добавляет (если это возможно) десятичную точку в текущее число. " +
                "Кнопки «/», «*», «+», «-» выполняют соответствующую операцию над результатом предыдущей операции и текущим числом. " +
                "Кнопка «=» вычисляет выражение и выводит результат." +
                "Кнопка «CE» очищает текущее число. " +
                "Кнопка «C» очищает текущее число и предыдущее выражение. " +
                "Кнопка «<» очищает последний введенный символ в текущем числе."}
        };

        public void Seed()
        {
            foreach (var item in taskList)
            {
                viewListBox.Items.Add(item);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Seed();           
        }

        private void viewListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            headlineLabel.Content = viewListBox.SelectedItem.GetType().GetProperty("FullName").
                GetValue(viewListBox.SelectedItem).ToString();

            taskTextBox.Text = viewListBox.SelectedItem.GetType().GetProperty("TaskText").
                GetValue(viewListBox.SelectedItem).ToString();
        }

        private void startButtom_Click(object sender, RoutedEventArgs e)
        {
            if (viewListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Для запуска выберете задание");
            }
            switch (viewListBox.SelectedIndex)
            {
                case 0: WindowButtoms windowButtoms = new WindowButtoms();
                    windowButtoms.Show();
                    break;
                case 1:
                    var calculator = new Calculator.MainWindow();
                    calculator.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}
