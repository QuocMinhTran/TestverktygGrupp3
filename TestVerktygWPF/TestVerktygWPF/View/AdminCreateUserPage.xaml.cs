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
        public List<StudentClass> liAlClasses = new List<StudentClass>();
        public int SelectedIntClass = 0;

        public AdminCreateUserPage()
        {
            InitializeComponent();
            Repository repo = new Repository();
            liAlClasses = repo.GetClasses();
            foreach (var item in liAlClasses)
            {
                CbxSelectClass.Items.Add(item.Name);
            }
            //CbxSelectClass.ItemsSource = liAlClasses;
            //CbxSelectClass.Items.Add(liAlClasses.ToArray());
            Console.WriteLine(CbxSelectClass.SelectedIndex);
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            if (RdBtnStudent.IsChecked == true)
            {
                var repo = new Repository();
                Student xStudent = new Student();
                xStudent.FirstName = tbxFirstName.Text;
                xStudent.LastName = tbxLastName.Text;
                xStudent.UserName = tbxUsername.Text;
                xStudent.Password = tbxPassword.Text;
                xStudent.Email = tbxEmail.Text;
                xStudent.OccupationFk = 3;
                xStudent.StudentClassFk = SelectedIntClass;

                repo.SaveStudent(xStudent);

            }

            else if (RdBtnTeacher.IsChecked == true)
            {
                var repo = new Repository();
                User xTeacher = new User();

                xTeacher.FirstName = tbxFirstName.Text;
                xTeacher.LastName = tbxLastName.Text;
                xTeacher.UserName = tbxUsername.Text;
                xTeacher.Password = tbxPassword.Text;
                xTeacher.Email = tbxEmail.Text;
                xTeacher.OccupationFk = 1;
                xTeacher.StudentClassFk = SelectedIntClass;
                repo.SaveUser(xTeacher);
            }

            else
            {
                var repo = new Repository();
                User xAdmin = new User();

                xAdmin.FirstName = tbxFirstName.Text;
                xAdmin.LastName = tbxLastName.Text;
                xAdmin.UserName = tbxUsername.Text;
                xAdmin.Password = tbxPassword.Text;
                xAdmin.Email = tbxEmail.Text;
                xAdmin.OccupationFk = 3;
                xAdmin.StudentClassFk = SelectedIntClass;
                repo.SaveUser(xAdmin);
            }

            MessageBox.Show($"{tbxFirstName.Text} är tillagd");

            tbxFirstName.Clear();
            tbxLastName.Clear();
            tbxUsername.Clear();
            tbxPassword.Clear();
            tbxEmail.Clear();
            RdBtnStudent.IsChecked = false;
            RdBtnAdmin.IsChecked = false;
            RdBtnTeacher.IsChecked = false;
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


        private void CbxSelectClass_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(CbxSelectClass.SelectedIndex);
            SelectedIntClass = CbxSelectClass.SelectedIndex + 1;
            Console.WriteLine("int"+SelectedIntClass);
        }
    }
}
