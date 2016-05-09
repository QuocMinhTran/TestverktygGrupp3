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
        // public int NumberOfTests;

        public double AvrageTimeForTest;



        public double NumberOfQuestionsInSelectedTest; //maxpoäng
        public double StudentsScoreOfTest; // AllasPoäng
        public double ResultA;
        public double AvrageProcentGrade;
        public double NumberOfstudents;

        public StatistikMasterPage()
        {
            InitializeComponent();
            CurrentSelectedTest csTest = new CurrentSelectedTest();

            cbxSelectTest.Items.Add("kalle");
            liAllTests = csTest.AllTestsDone();
            //cbxSelectTest.SelectedIndex = 0;
            Console.WriteLine(liAllStudents.Count);
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

            double TotalTestTime =0;
            int NumberOfTests = 0;
            List<StudentTest> lxStudentTest = new List<StudentTest>();
            Repository Repo = new Repository();
            lxStudentTest = Repo.GetTestDone(SelectedTest.ID);
            foreach (var item in liAllTests)
            {
                Console.WriteLine(NumberOfTests + "NUMBER OF TESTSZ");
                foreach (var item2 in lxStudentTest)
                {
                    Console.WriteLine(item + "Item" + item2 + "Student");
                    if (item.ID == item2.TestRefFk)
                    {
                        NumberOfTests++;
                        TotalTestTime += item2.WritenTime;
                        Console.WriteLine(TotalTestTime);
                    }

                }
                //if (item.ID == lxStudentTest)
                //{
                //    NumberOfTests++;
                //    TotalTestTime += item.TimeStampe;

                //}
            }
            AvrageTimeForTest = TotalTestTime / NumberOfTests;
            Console.WriteLine(AvrageTimeForTest + "Avarage To Time");
        }

        private void CbxSelectTest_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            spStudent.Visibility = Visibility.Collapsed;
            var varSender = sender as ComboBox;

            CurrentSelectedTest csTest = new CurrentSelectedTest();
            csTest.SetCurrentTest(varSender.SelectedItem.ToString());
            SelectedTest = csTest.CurrentTest;
            NumberOfQuestionsInSelectedTest = csTest.CurrentQuestions.Count();

            NumberOfstudents = csTest.CurrentStudents.Count();

            if (SelectedTest != null)
            {
                lvClassStatistics.Items.Clear();
                StudentsScoreOfTest = 0;
                csTest.SetCurrentTest(SelectedTest.ID);

                foreach (var item in csTest.CurrentStudents)
                {
                    Console.WriteLine("Student id från valt prov " + item.ID);
                    csTest.SetCurrentStudent(item.ID);
                    lvClassStatistics.Items.Add("Namn " + csTest.CurrentStudent.FirstName + csTest.CurrentStudent.LastName + " Poäng " + csTest.StudentScore + " Tid " + csTest.StudentTime);
                    StudentsScoreOfTest += csTest.StudentScore;
                }

            }

            AvrageTestTime();
            DisplayAvrageInfo();
            AvrageScoreForTest();
        }

        private void AvrageScoreForTest()
        {

            
            ResultA = NumberOfQuestionsInSelectedTest - StudentsScoreOfTest;
            Console.WriteLine("Studenternas sammanlagda poäng : " + StudentsScoreOfTest);
            Console.WriteLine("Antal frågor i testet : " + NumberOfQuestionsInSelectedTest);
            Console.WriteLine("ResultatA : " + ResultA);
            AvrageProcentGrade = ResultA/NumberOfQuestionsInSelectedTest;


            
            Console.WriteLine("procent av provet i svar : " + AvrageProcentGrade);
            

        }

        private void DisplayAvrageInfo()
        {
            tbNameOfTest.Text = "Namn på provet: " + SelectedTest.Name;
            tbAverageTimeOnTest.Text = "Genomsnittstid på provet: " + AvrageTimeForTest.ToString();
        }

        private void CbxSelectStudent_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            spStudent.Visibility = Visibility.Visible;
            //cbxSelectTest.SelectedIndex = 0;

            //SelectedStudent = sender as Student;
            //SelectedStudent = (Student)cbxSelectStudent.SelectedItem;
            var x = sender as ComboBox;
            Console.WriteLine(x.SelectedItem.ToString());



        }
    }
}
