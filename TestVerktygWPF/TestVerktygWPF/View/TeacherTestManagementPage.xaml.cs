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
            listViewTestToSend.DisplayMemberPath = "Name";
        }

        private void btnSendTestToAdmin_Click(object sender, RoutedEventArgs e)
        {
            test = listViewTestToSend.SelectedItem as Test;
            List<Student> StudentToTest = new List<Student>();
            foreach (var item in listStk.Children)
            {
                var boxes = item as CheckBox;
                if (boxes.IsChecked == true)
                { 
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
            }
            SendTestToAdmin(test, txtBoxTimeInput.Text, DatePickerEndDate, DatePickerStartDate, StudentToTest);
        }

        private void SendTestToAdmin(Test test, string text, DatePicker datePickerEndDate, DatePicker datePickerStartDate, List<Student> students)
        {
            ClearWarning();
            if (listViewTestToSend.SelectedItem != null
                && CheckTimeInput(text) == true
                && CheckDates(DateTime.Now, datePickerStartDate.SelectedDate)
                && CheckDates(datePickerStartDate.SelectedDate, datePickerEndDate.SelectedDate)
                && students.Count >= 1)
            {
                using (var db = new DbModel())
                {
                    var query = from t in db.Tests
                                where t.ID == test.ID
                                select t;
                    foreach (var item in query.ToList())
                    {
                        item.TimeStampe = int.Parse(txtBoxTimeInput.Text);
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

                    MessageBox.Show("Provet har skickats till Admin");
                    UpdateList();

                    ClearSelection();

                    db.SaveChanges();
                }
            }

            else
            {
                if (students.Count < 1)
                {
                    lblWarning.Content += "Välj studenter som skall göra provet";
                }
            }
        }

        private void ClearSelection()
        {
            DatePickerStartDate.SelectedDate = null;
            DatePickerEndDate.SelectedDate = null;
            rbnClass.IsChecked = false;
            rbnElev.IsChecked = false;
            listStk.Visibility = Visibility.Collapsed;
        }

        private bool CheckTimeInput(string text)
        {
            int number;
            bool result = Int32.TryParse(text, out number);
            if (result == true && number >= 1)
                return true;
            else
            {
                lblWarning.Content += "Kontrollera tidsbegränsningen. Den ska endast bestå av positiva tal. \n";
                txtBoxTimeInput.BorderBrush = Brushes.Red;
                return false;
            }
        }

        private bool CheckDates(DateTime? startDate, DateTime? endDate)
        {
            if (startDate > endDate || startDate == null || endDate == null)
            {
                lblWarning.Content += "Kontrollera start- och slutdatum. \n";
                DatePickerStartDate.BorderBrush = Brushes.Red;
                DatePickerEndDate.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ClearWarning()
        {
            lblWarning.Content = "";
            DatePickerStartDate.ClearValue(DatePicker.BorderBrushProperty);
            DatePickerEndDate.ClearValue(DatePicker.BorderBrushProperty);
            txtBoxTimeInput.ClearValue(TextBox.BorderBrushProperty);
        }

        private void listViewTestToSend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            test = sender as Test;
            if (listViewTestToSend.SelectedIndex == -1)
                btnSendTestToAdmin.IsEnabled = false;
            else
                btnSendTestToAdmin.IsEnabled = true;

        }

        private void generateList(object sender, RoutedEventArgs e)
        {
            listStk.Visibility = Visibility.Visible;
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
