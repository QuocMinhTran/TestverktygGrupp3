using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestVerktygWPF.Model;
using TestVerktygWPF.ViewModel;

namespace TestVerktygWPF.View
{
    /// <summary>
    /// Interaction logic for AdminUserManagementPage.xaml
    /// </summary>
    public partial class AdminUserManagementPage : Page
    {
        public List<Student> lsStudents;
        public List<User> LsTeachers;
        public List<User> LsAdmins;
        public Student SelectedStudent = new Student();
        public User SelectedUser = new User();


        public bool IsSelectedUser = false;
        public bool IsSelectedUserStudent = false;

        public AdminUserManagementPage(User user)
        {
            InitializeComponent();

            GetAllUsers();

            dgElevDataGrid.ItemsSource = lsStudents;
            dgAdminDataGrid.ItemsSource = LsAdmins;
            dgTeacherDataGrid.ItemsSource = LsTeachers;
        }

        private void GetAllUsers()
        {
            Repository repo = new Repository();
            lsStudents = repo.GetAllStudents();
            LsAdmins = repo.GetAllAdmins();
            LsTeachers = repo.GetAllTeachers();
        }

        private void BtnPopUpClose(object sender, RoutedEventArgs e)
        {
            PopUpSelectedUser.IsOpen = false;
        }

        private void BtnSaveEditStudent(object sender, RoutedEventArgs e)
        {
            PopUpSelectedUser.IsOpen = false;
            Repository repo = new Repository();
            if (IsSelectedUserStudent)
            {
                SelectedStudent.FirstName = TxtPopFirstName.Text;
                SelectedStudent.LastName = TxtPopLastName.Text;
                SelectedStudent.UserName = TxtPopUserName.Text;
                SelectedStudent.Password = TxtPopPassword.Text;
                SelectedStudent.Email = TxtPopEmail.Text;

                repo.Edittudent(SelectedStudent);
                UpdateUserList(1);
                IsSelectedUserStudent = false;
            }
            else if (IsSelectedUser)
            {
                SelectedUser.FirstName = TxtPopFirstName.Text;
                SelectedUser.LastName = TxtPopLastName.Text;
                SelectedUser.UserName = TxtPopUserName.Text;
                SelectedUser.Password = TxtPopPassword.Text;
                SelectedUser.Email = TxtPopEmail.Text;

                repo.EditUser(SelectedUser);
                UpdateUserList(2);
                IsSelectedUser = false;
            }


        }

        private void UpdateUserList(int count)
        {
            Repository repo = new Repository();
            switch (count)
            {
                case 1:
                    lsStudents = repo.GetAllStudents();
                    dgElevDataGrid.ItemsSource = lsStudents;
                    break;

                case 2:
                    LsTeachers = repo.GetAllTeachers();
                    dgTeacherDataGrid.ItemsSource = LsTeachers;
                    LsAdmins = repo.GetAllAdmins();
                    dgAdminDataGrid.ItemsSource = LsAdmins;
                    break;

                default:
                    break;
            }


        }


        private void DgElevDataGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectedStudent = (Student) dgElevDataGrid.SelectedItem;
            PopUpSelectedUser.IsOpen = true;
            TxtPopFirstName.Text = SelectedStudent.FirstName;
            TxtPopLastName.Text = SelectedStudent.LastName;
            TxtPopUserName.Text = SelectedStudent.UserName;
            TxtPopPassword.Text = SelectedStudent.Password;
            TxtPopEmail.Text = SelectedStudent.Email;
            IsSelectedUserStudent = true;
        }

        private void DgTeacherDataGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectedUser = (User) dgTeacherDataGrid.SelectedItem;
            PopUpSelectedUser.IsOpen = true;
            TxtPopFirstName.Text = SelectedUser.FirstName;
            TxtPopLastName.Text = SelectedUser.LastName;
            TxtPopUserName.Text = SelectedUser.UserName;
            TxtPopPassword.Text = SelectedUser.Password;
            TxtPopEmail.Text = SelectedUser.Email;
            IsSelectedUser = true;
        }

        private void DgAdminDataGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectedUser = (User) dgAdminDataGrid.SelectedItem;
            PopUpSelectedUser.IsOpen = true;
            TxtPopFirstName.Text = SelectedUser.FirstName;
            TxtPopLastName.Text = SelectedUser.LastName;
            TxtPopUserName.Text = SelectedUser.UserName;
            TxtPopPassword.Text = SelectedUser.Password;
            TxtPopEmail.Text = SelectedUser.Email;
            IsSelectedUser = true;
        }

        private void BtnDeleteUser(object sender, RoutedEventArgs e)
        {
            PopUpSelectedUser.IsOpen = false;
            Repository repo = new Repository();
            if (IsSelectedUserStudent)
            {
                repo.Removetudent(SelectedStudent);
                UpdateUserList(1);
                IsSelectedUserStudent = false;
            }
            else if (IsSelectedUser)
            {


                repo.RemoveUser(SelectedUser);
                UpdateUserList(2);
                IsSelectedUser = false;
            }
        }
    }
}
