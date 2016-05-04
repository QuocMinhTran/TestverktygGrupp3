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

namespace TestVerktygWPF.View
{
    /// <summary>
    /// Interaction logic for TeacherTestManagementPage.xaml
    /// </summary>
    public partial class TeacherTestManagementPage : Page
    {
        IList<Test> tests = new List<Test>();
        public TeacherTestManagementPage()
        {
            InitializeComponent();
            using (var db = new DbModel())
            {
                var query = (from t in db.Tests
                             select t).ToList();
                foreach (var item in query)
                {
                    tests.Add(item);
                }
                //cbSelectClass.ItemsSource = db.GradeClasss.ToList();
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
                //ComboBox cbb = sender as ComboBox;
                //var query = from grade in db.GradeClasss
                //            where grade.Name == cbSelectClass.SelectedItem.ToString()
                //            select grade.Studends.ToList();
                //List<string> Names = new List<string>();
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item);
                //}
                cbSelectStudent.ItemsSource = db.Students.ToList();
                cbSelectStudent.DisplayMemberPath = "FirstName";
            }
        }

        private void btnSendTestToAdmin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
