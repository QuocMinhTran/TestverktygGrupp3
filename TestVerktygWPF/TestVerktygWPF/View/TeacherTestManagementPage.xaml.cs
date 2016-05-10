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

        public TeacherTestManagementPage()
        {
            InitializeComponent();
            using (var db = new DbModel())
            {
                var query = (from t in db.Tests
                             join ut in db.UserTests on t.ID equals ut.TestFk
                             join u in db.Users on ut.UserFk equals u.ID
                             where u.OccupationFk == 1 // add the condition of the user after we finish login site, now we can see only all tests of teachers
                             select t).ToList();
                foreach (var item in query)
                {
                    tests.Add(item);
                }
                cbSelectClass.ItemsSource = db.StudentClasses.ToList();
                cbSelectClass.DisplayMemberPath = "Name";
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

        private void cbSelectClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new DbModel())
            {
                var query = from s in db.Students
                            join stc in db.StudentClasses on s.StudentClassFk equals stc.ID
                            join u in db.Users on stc.ID equals u.StudentClassFk
                            where u.OccupationFk == 1 // add the condition of the user after we finish login site, now we can see only all tests of teachers
                            select s;
                //cbSelectStudent.Items.Add("Alla");
                cbSelectStudent.ItemsSource = query.ToList();
                cbSelectStudent.DisplayMemberPath = "FirstName";
                //cbSelectStudent.Items.Add("Alla");
            }
        }

        private void btnSendTestToAdmin_Click(object sender, RoutedEventArgs e)
        {
            test = listViewTestToSend.SelectedItem as Test;
            SendTestToAdmin(test, txtBoxTestTime.Text, DatePickerEndDate, DatePickerStartDate, cbSelectClass.SelectedItem, cbSelectStudent.SelectedItem);
        }

        private void SendTestToAdmin(Test test, string text, DatePicker datePickerEndDate, DatePicker datePickerStartDate, object selectedItem1, object selectedItem2)
        {
            if (listViewTestToSend.SelectedItem != null && DatePickerStartDate.SelectedDate != null && DatePickerEndDate != null)
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
                    if (cbSelectStudent.SelectedValue.ToString() == "Alla" && cbSelectClass.SelectedItem != null)
                    {
                        var xstudents = from s in db.Students
                                        join sc in db.StudentClasses on s.StudentClassFk equals sc.ID
                                        where sc.Name == cbSelectClass.SelectedValue.ToString()
                                        select s;
                        foreach (var item in xstudents.ToList())
                        {
                            StudentTest newTest = new StudentTest();
                            newTest.TestRefFk = test.ID;
                            newTest.StudentRefFk = item.ID;
                            newTest.IsChecked = false;
                            db.StudentTests.Add(newTest);
                        }
                    }
                    else if (cbSelectClass.SelectedItem != null && cbSelectStudent.SelectedItem != null)
                    {
                        var xstudents = from s in db.Students
                                        where s.FirstName == cbSelectStudent.SelectedValue.ToString()
                                        select s;
                        foreach (var item in xstudents.ToList())
                        {
                            StudentTest newTest = new StudentTest();
                            newTest.TestRefFk = test.ID;
                            newTest.StudentRefFk = item.ID;
                            newTest.IsChecked = false;
                            db.StudentTests.Add(newTest);
                        }
                    }

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
    }
}
