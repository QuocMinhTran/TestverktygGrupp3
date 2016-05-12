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
using TestVerktygWPF.Model;
using TestVerktygWPF.ViewModel;

namespace TestVerktygWPF.View
{
    /// <summary>
    /// Interaction logic for TeacherTestManagementPage.xaml
    /// </summary>
    public partial class TeacherTestManagementPage : Page
    {
        IList<Test> tests = new List<Test>();
        Test test;
        User theTeacher;
        Repository repo = new Repository();

        public TeacherTestManagementPage(User user)
        {
            theTeacher = user;
            InitializeComponent();
            UpdateList();
            
        }

        private void UpdateList()
        {
            using (var db = new DbModel())
            {
                var query = (from t in db.Tests
                             join ut in db.UserTests on t.ID equals ut.TestFk
                             join u in db.Users on ut.UserFk equals u.ID
                             where u.UserName == theTeacher.UserName // add the condition of the user after we finish login site, now we can see only all tests of teachers
                             select t).ToList();
                foreach (var item in query)
                {
                    tests.Add(item);
                }
            }
            listViewTestToSend.ItemsSource = tests;
        }

        private void btnTimeUp_Click(object sender, RoutedEventArgs e)
        {
            txtBoxTestTime.Text = (int.Parse(txtBoxTestTime.Text) + 1).ToString();
        }

        private void btnTimeDown_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(txtBoxTestTime.Text) > 1)
            {
                txtBoxTestTime.Text = (int.Parse(txtBoxTestTime.Text) - 1).ToString();
            }
            else
            {
                MessageBox.Show("Det räcker inter");
            }
        }

        private void btnSendTestToAdmin_Click(object sender, RoutedEventArgs e)
        {
            test = listViewTestToSend.SelectedItem as Test;
            List<Student> StudentToTest = new List<Student>();
            foreach (var item in listStk.Children)
            {
                var boxes = item as CheckBox;
                if (rbnClass.IsChecked == true)
                {
                    using (var db = new DbModel())
                    {
                        var query = from s in db.Students
                                    join sc in db.StudentClasses on s.StudentClassFk equals sc.ID
                                    join scc in db.StudentClassCourses on sc.ID equals scc.StudentClassRefID
                                    join c in db.Courses on scc.CouseRefID equals c.ID
                                    where c.CourseName == boxes.Content.ToString()
                                    select s;
                        foreach (var item2 in query)
                        {
                            foreach (var item3 in StudentToTest)
                            {
                                if (item2 == item3)
                                {
                                    StudentToTest.Add(item2);
                                }
                            }
                        }
                    }
                }
                else if (rbnElev.IsChecked == true)
                {
                    using (var db = new DbModel())
                    {
                        var query = from s in db.Students
                                    where s.UserName == boxes.Content.ToString()
                                    select s;
                        foreach (var item2 in query)
                        {
                            StudentToTest.Add(item2);
                        }

                    }
                }
            }
            SendTestToAdmin(test, txtBoxTestTime.Text, DatePickerEndDate, DatePickerStartDate, StudentToTest);
        }

        private void SendTestToAdmin(Test test, string text, DatePicker datePickerEndDate, DatePicker datePickerStartDate, List<Student> students)
        {
            if (listViewTestToSend.SelectedItem != null && DatePickerStartDate.SelectedDate != null && DatePickerEndDate != null && students != null)
            {
                using (var db = new DbModel())
                {
                    var query = from t in db.Tests
                                where t.ID == test.ID
                                select t;
                    foreach (var item in query.ToList())
                    {
                        item.TimeStampe = int.Parse(txtBoxTestTime.Text);
                        item.StartDate = DatePickerStartDate.SelectedDate;
                        item.EndDate = DatePickerEndDate.SelectedDate;
                        var query2 = from t in db.Users
                                     where t.OccupationFk == 2
                                     select t;
                        foreach (var item2 in query2.ToList())
                        {
                            UserTest toAdmin = new UserTest();
                            toAdmin.TestFk = item.ID;
                            toAdmin.UserFk = item2.ID;
                            db.UserTests.Add(toAdmin);
                        }
                    }

                    foreach (var item in students)
                    {
                        StudentTest newTest = new StudentTest();
                        newTest.TestRefFk = test.ID;
                        newTest.StudentRefFk = item.ID;
                        newTest.IsChecked = false;
                        db.StudentTests.Add(newTest);
                    }

                    //var teacherUserTest = from u in db.UserTests
                    //                      where u.UserFk == theTeacher.ID
                    //                      select u;
                    //foreach (var item in teacherUserTest.ToList())
                    //{
                    //    db.UserTests.Remove(item);
                    //}
                    UpdateList();
                    DatePickerStartDate.SelectedDate = null;
                    DatePickerEndDate.SelectedDate = null;

                    db.SaveChanges();
                }
            }

        }

        private void listViewTestToSend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            test = sender as Test;
        }

        private void generateList(object sender, RoutedEventArgs e)
        {
            RadioButton rbn = sender as RadioButton;
            switch (rbn.Name.ToString())
            {
                case "rbnClass":
                    listStk.Children.Clear();
                    generateClassList();
                    break;
                case "rbnElev":
                    listStk.Children.Clear();
                    generateStudentList();
                    break;
                default:
                    break;
            }
        }

        private void generateClassList()
        {
            using (var db = new DbModel())
            {
                var query = from c in db.Courses
                            join stc in db.StudentClassCourses on c.ID equals stc.CouseRefID
                            join st in db.StudentClasses on stc.StudentClassRefID equals st.ID
                            join u in db.Users on st.ID equals u.StudentClassFk
                            where u.ID == theTeacher.ID
                            select c;
                foreach (var item in query)
                {
                    CheckBox box = new CheckBox();
                    box.Content = item.CourseName;
                    listStk.Children.Add(box);
                }
            }
        }

        private void generateStudentList()
        {
            using (var db = new DbModel())
            {
                var query = from s in db.Students
                            where s.StudentClassFk == theTeacher.StudentClassFk
                            select s;
                foreach (var item in query)
                {
                    CheckBox box = new CheckBox();
                    box.Content = item.UserName;
                    listStk.Children.Add(box);
                }
            }
        }
    }
}
