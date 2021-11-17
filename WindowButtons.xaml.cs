using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;

namespace WPF_START
{
    /// <summary>
    /// Логика взаимодействия для WindowButtoms.xaml
    /// </summary>
    public partial class WindowButtoms : Window
    {
        string[] MyColors = { "Navy", "Blue", "Aqua", "Teal", "Olive", "Green", 
            "Lime", "Yellow", "Orange", "Red", "Maroon", "Fuchsia", "Purple", "Black",
            "Silver", "Gray", "White"};

        Button[] buttons = new Button[17];
        public WindowButtoms()
        {
            InitializeComponent();
            ButtonCreateon();
        }

        public void ButtonCreateon()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Width = 100;
                buttons[i].Height = 50;
                buttons[i].Margin = new Thickness(2,2,2,2);
                buttons[i].Foreground = (SolidColorBrush)new BrushConverter().
                    ConvertFromString(MyColors[i]);
                buttons[i].Background = Brushes.Black;
                buttons[i].Content = MyColors[i];
                buttons[i].FontSize = 20;
                wrapPanel.Children.Add(buttons[i]);
            }
        }
    }
}
