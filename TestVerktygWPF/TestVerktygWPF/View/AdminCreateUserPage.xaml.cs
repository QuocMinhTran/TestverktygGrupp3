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
using TestVerktygWPF.ViewModel;
using TestVerktygWPF.Model;

namespace TestVerktygWPF.View
{
    /// <summary>
    /// Interaction logic for AdminCreateUserPage.xaml
    /// </summary>
    public partial class AdminCreateUserPage : Page
    {
        
        public AdminCreateUserPage()
        {
            InitializeComponent();
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
           // if (RdBtnStudent.IsChecked == true)
           // {
           //     var repo = new Repository();
           //     Student xStudent = new Student();

           //     xStudent.FirstName = tbxFirstName.Text;
           //     xStudent.LasttName = tbxLastName.Text;
           //     xStudent.UserName = tbxUsername.Text;
           //     xStudent.Password = tbxPassword.Text;
           //     xStudent.Email = tbxEmail.Text;
           //     repo.SaveStudent(xStudent);
                
           // }

           //else if (RdBtnTeacher.IsChecked == true)
           // {
           //     var repo = new Repository();
           //     Teacher xTeacher = new Teacher();

           //     xTeacher.FirstName = tbxFirstName.Text;
           //     xTeacher.LasttName = tbxLastName.Text;
           //     xTeacher.UserName = tbxUsername.Text;
           //     xTeacher.Password = tbxPassword.Text;
           //     xTeacher.Email = tbxEmail.Text;
           //     repo.SaveTeacher(xTeacher);
           // }

           //else
           //{
           //     var repo = new Repository();
           //     User xAdmin= new User();

           //     xAdmin.FirstName = tbxFirstName.Text;
           //     xAdmin.LasttName = tbxLastName.Text;
           //     xAdmin.UserName = tbxUsername.Text;
           //     xAdmin.Password = tbxPassword.Text;
           //     xAdmin.Email = tbxEmail.Text;
           //     repo.SaveAdmin(xAdmin);
           // }

           // MessageBox.Show($"{tbxFirstName.Text} är tillagd");

           // tbxFirstName.Clear();
           // tbxLastName.Clear();
           // tbxUsername.Clear();
           // tbxPassword.Clear();
           // tbxEmail.Clear();
           // RdBtnStudent.IsChecked = false;
           // RdBtnAdmin.IsChecked = false;
           // RdBtnTeacher.IsChecked = false;
        }

        private void btnCancelUser_Click(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
            tbxLastName.Clear();
            tbxUsername.Clear();
            tbxPassword.Clear();
            tbxEmail.Clear();
            RdBtnStudent.IsChecked = false;
            RdBtnAdmin.IsChecked = false;
            RdBtnTeacher.IsChecked = false;
        }
    }
}
