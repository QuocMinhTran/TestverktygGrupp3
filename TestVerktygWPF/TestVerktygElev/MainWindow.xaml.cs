using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data.Sql;
using TestVerktygElev.ViewModel;

namespace TestVerktygElev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repo = new Repository();
        //List<Student> students;
        //Student SelectedUser;
        public MainWindow()
        {
            InitializeComponent();
            Student xStudent = new Student();
            xStudent.FirstName = "Kom Och";
            xStudent.LastName = " Hjälp Mig";
            xStudent.ID = 1;
            
            _frame.Navigate(new MainPage(xStudent));
            //_frame.Navigate(new StatisticPage(repo.GetTest(1), 3,xStudent,10,4));
        }
 


        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    //TODO: send UserName and Password to database and login if there is a match
        //    students = repo.GetAllStudents();
        //    foreach (var item in students)
        //    {
        //        if (txtBoxUserNameInput.Text == item.UserName && txtBoxPasswordInput.Password == item.Password)
        //        {
        //            SelectedUser = item;
        //            loginPanel.Visibility = Visibility.Collapsed;
        //            MenuTabs.Visibility = Visibility.Visible;
        //            _frame.Navigate(new MainPage(item));
        //        }
        //    }
        //}

        //private void TextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key.Equals(Key.Enter))
        //        btnLogin_Click(sender, e);
        //}

        //private void Menu_Clicked(object sender, RoutedEventArgs e)
        //{
        //    MenuItem btn = sender as MenuItem;
        //    switch (btn.Header.ToString())
        //    {
        //        case "Startsida":
        //            _frame.Navigate(new MainPage(SelectedUser));
        //            break;
        //        case "Logga ut":
        //            SelectedUser = null;
        //            loginPanel.Visibility = Visibility.Visible;
        //            MenuTabs.Visibility = Visibility.Collapsed;
        //            _frame.Navigate(new MainWindow());
        //            break;
        //    }
        //}
    }
}
