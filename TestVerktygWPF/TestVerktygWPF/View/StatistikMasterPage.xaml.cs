using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for StatistikMasterPage.xaml
    /// </summary>
    public partial class StatistikMasterPage : Page
    {
        public Test SelectedTest = new Test();
        public List<Test> liAllTests = new List<Test>();
        public List<Student> liAllStudents = new List<Student>();
        public Student SelectedStudent = new Student();
        public int NumberOfTests;
        public double TotalTestTime;
        public double AvrageTimeForTest;

        public StatistikMasterPage()
        {
            InitializeComponent();
            CurrentSelectedTest csTest = new CurrentSelectedTest();

            cbxSelectTest.Items.Add("kalle");
            liAllTests = csTest.AllTestsDone();
            cbxSelectTest.SelectedIndex = 0;
            foreach (var item in liAllTests)
            {
                cbxSelectTest.Items.Add(item.Name);
            }

            Repository repo = new Repository();
            liAllStudents = repo.GetAllStudents();
            //cbxSelectStudent.SelectedIndex = 0;
            foreach (var item in liAllStudents)
            {
                cbxSelectStudent.Items.Add(item.FirstName + " " + item.LastName);
            }



        }

        private void AvrageTestTime()
        {
            foreach (var item in liAllTests)
            {
                if (item.ID == SelectedTest.ID)
                {
                    NumberOfTests++;
                    TotalTestTime = +item.TimeStampe;

                }
            }
            AvrageTimeForTest = TotalTestTime / NumberOfTests;
        }

        private void CbxSelectTest_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spClass.Visibility = Visibility.Visible;
            spStudent.Visibility = Visibility.Collapsed;
            var varSender = sender as ComboBox;
           
            CurrentSelectedTest csTest = new CurrentSelectedTest();
            csTest.SetCurrentTest(varSender.SelectedItem.ToString());
            SelectedTest = csTest.CurrentTest;
            if (SelectedTest != null)
            {
                csTest.SetCurrentTest(SelectedTest.ID);
                foreach (var item in csTest.CurrentStudents)
                {
                    csTest.SetCurrentStudent(item.ID);
                    lvClassStatistics.Items.Add(csTest.CurrentStudent + csTest.StudentScore.ToString() + csTest.StudentTime);
                }


            }

            AvrageTestTime();
            DisplayAvrageInfo();
        }

        private void DisplayAvrageInfo()
        {
            //tbNameOfTest.Text = SelectedTest.Name;
            //tbAverageTimeOnTest.Text = AvrageTimeForTest.ToString();
        }

        private void CbxSelectStudent_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spClass.Visibility = Visibility.Collapsed;
            spStudent.Visibility = Visibility.Visible;
            //cbxSelectTest.SelectedIndex = 0;
            
            //SelectedStudent = sender as Student;
            //SelectedStudent = (Student)cbxSelectStudent.SelectedItem;
            var x = sender as ComboBox;
                Console.WriteLine(x.SelectedItem.ToString());
            
            

        }
    }
}
