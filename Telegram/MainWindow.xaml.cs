using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telegram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> userList { get; set; }
        public MainWindow()
        {
            userList = new List<User>() 
            {
                new User { UserID = 111111, Message = "Привет! как дела???" },
                new User { UserID = 222222, Message = "Убей себя ап стену!!!"}
            };
            InitializeComponent();
        }

        private void Expand_Click(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
            }
        }

        private void RollUp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ContextMenu cm = this.FindName("contextToLoad") as ContextMenu;
            cm.IsOpen = true;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
        }
    }
}
