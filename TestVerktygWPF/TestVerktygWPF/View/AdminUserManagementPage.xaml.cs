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
        public List<Teacher> LsTeachers;
        public List<Admin> LsAdmins;
        public Student SelectedStudent = new Student();
        public Teacher SelectedTeacher = new Teacher();
        public Admin SelectedAdmin = new Admin();
        public bool IsSelectedUserAdmin = false;
        public bool IsSelectedUserTeacher = false;
        public bool IsSelectedUserStudent = false;
        public AdminUserManagementPage()
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
                SelectedStudent.LasttName = TxtPopLastName.Text;
                SelectedStudent.UserName = TxtPopUserName.Text;
                SelectedStudent.Password = TxtPopPassword.Text;
                SelectedStudent.Email = TxtPopEmail.Text;

                repo.Edittudent(SelectedStudent);
                UpdateUserList(1);
                IsSelectedUserStudent = false;
            }
            else if (IsSelectedUserTeacher)
            {
                SelectedTeacher.FirstName = TxtPopFirstName.Text;
                SelectedTeacher.LasttName = TxtPopLastName.Text;
                SelectedTeacher.UserName = TxtPopUserName.Text;
                SelectedTeacher.Password = TxtPopPassword.Text;
                SelectedTeacher.Email = TxtPopEmail.Text;

                repo.EditTeacher(SelectedTeacher);
                UpdateUserList(2);
                IsSelectedUserTeacher = false;
            }
            else
            {
                SelectedAdmin.FirstName = TxtPopFirstName.Text;
                SelectedAdmin.LasttName = TxtPopLastName.Text;
                SelectedAdmin.UserName = TxtPopUserName.Text;
                SelectedAdmin.Password = TxtPopPassword.Text;
                SelectedAdmin.Email = TxtPopEmail.Text;

                repo.EditAdmin(SelectedAdmin);
                UpdateUserList(3);
                IsSelectedUserAdmin = false;
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
                    break;
                case 3:
                    LsAdmins = repo.GetAllAdmins();
                    dgAdminDataGrid.ItemsSource = LsAdmins;
                    break;
                default:
                    break;
            }


        }


        private void DgElevDataGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectedStudent = (Student)dgElevDataGrid.SelectedItem;
            PopUpSelectedUser.IsOpen = true;
            TxtPopFirstName.Text = SelectedStudent.FirstName;
            TxtPopLastName.Text = SelectedStudent.LasttName;
            TxtPopUserName.Text = SelectedStudent.UserName;
            TxtPopPassword.Text = SelectedStudent.Password;
            TxtPopEmail.Text = SelectedStudent.Email;
            IsSelectedUserStudent = true;
        }

        private void DgTeacherDataGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectedTeacher = (Teacher)dgTeacherDataGrid.SelectedItem;
            PopUpSelectedUser.IsOpen = true;
            TxtPopFirstName.Text = SelectedTeacher.FirstName;
            TxtPopLastName.Text = SelectedTeacher.LasttName;
            TxtPopUserName.Text = SelectedTeacher.UserName;
            TxtPopPassword.Text = SelectedTeacher.Password;
            TxtPopEmail.Text = SelectedTeacher.Email;
            IsSelectedUserTeacher = true;
        }

        private void DgAdminDataGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectedAdmin = (Admin)dgAdminDataGrid.SelectedItem;
            PopUpSelectedUser.IsOpen = true;
            TxtPopFirstName.Text = SelectedAdmin.FirstName;
            TxtPopLastName.Text = SelectedAdmin.LasttName;
            TxtPopUserName.Text = SelectedAdmin.UserName;
            TxtPopPassword.Text = SelectedAdmin.Password;
            TxtPopEmail.Text = SelectedAdmin.Email;
            IsSelectedUserAdmin = true;
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
            else if (IsSelectedUserTeacher)
            {
               

                repo.RemoveTeacher(SelectedTeacher);
                UpdateUserList(2);
                IsSelectedUserTeacher = false;
            }
            else
            {

                repo.RemoveAdmin(SelectedAdmin);
                UpdateUserList(3);
                IsSelectedUserAdmin = false;
            }
        }
    }
}
