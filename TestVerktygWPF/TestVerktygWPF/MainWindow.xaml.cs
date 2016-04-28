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

namespace TestVerktygWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
<<<<<<< HEAD
            _Frame.Navigate(new MainPageTeacher());
=======
            _Frame.Navigate(new View.AdminUserManagementPage());
>>>>>>> bbee70b1bcbb267ea5d06ead11ac60e8fc7dcb8b
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //TODO: send UserName and Password to database and login if there is a match
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                btnLogin_Click(sender, e);
        }
    }
}
