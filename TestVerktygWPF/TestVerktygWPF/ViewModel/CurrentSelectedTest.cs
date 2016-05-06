using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVerktygWPF.Model;

namespace TestVerktygWPF.ViewModel
{
    public class CurrentSelectedTest
    {
        private static Repository xRepo;
        public Test CurrentTest { get; private set; }
        private List<Test> m_lxAllTestsDone { get; set; }
        public List<Test> AllTests { get; private set; }
        public List<Questions> CurrentQuestions { get; private set; }
        public List<Student> CurrentStudents { get; private set; }
        public List<Answer> CurrentAnswers { get; private set; }
        public Student CurrentStudent { get; private set; }
        public int StudentTime { get; private set; }
        public int StudentScore { get; private set; }
        public CurrentSelectedTest()
        {
            xRepo = new Repository();
            AllTests = xRepo.GetAllTests();
            CurrentTest = new Test();
            m_lxAllTestsDone = new List<Test>();
            AllTests = new List<Test>();
            CurrentQuestions = new List<Questions>();
            CurrentStudents = new List<Student>();
            CurrentAnswers = new List<Answer>();
            CurrentStudent = new Student();

    }
        public void SetCurrentTest(int ID)
        {
            CurrentTest = xRepo.GetTest(ID);
            if (CurrentTest != null)
            {
                SetCurrentQuestions(CurrentTest);
                SetCurrentStudents(CurrentTest);
            }
          
        }
        public void SetCurrentTest(string sName)
        {
            CurrentTest = xRepo.GetTest(sName);
            Console.WriteLine(sName);
            SetCurrentQuestions(CurrentTest);
            SetCurrentStudents(CurrentTest);
        }

        private void SetCurrentQuestions(Test xCurrentTest)
        {
            CurrentQuestions = xRepo.GetQuestion(xCurrentTest.ID);
            //SetCurrentOptions(CurrentQuestions);

        }
        //private void SetCurrentOptions(List<Questions> xCurrentQuestions)
        //{
        //    foreach (var item in CurrentQuestions)
        //    {
        //        /// CurrentOptions = xRepo.GetOptions(item.id);
        //    }
        //}
        public void SetCurrentStudent(string sFirstName, string sLastName)
        {
            CurrentStudent = xRepo.GetStudent(sFirstName, sLastName);
            SetScoreForStudent(CurrentStudent);
            SetTimeForStudent(CurrentStudent);
        }
        public void SetCurrentStudent(int ID)
        {
            CurrentStudent = xRepo.GetStudent(ID);
            Console.WriteLine(CurrentStudent.ID);
            SetScoreForStudent(CurrentStudent);
            SetTimeForStudent(CurrentStudent);
        }
        public void SetCurrentStudent(Student xStudent)
        {
            CurrentStudent = xRepo.GetStudent(xStudent.ID);
        }
        private void SetCurrentStudents(Test xTest)
        {
            CurrentStudents = xRepo.GetAllStudents(xTest);
        }
        private void SetTimeForStudent(Student xStudent)
        {
            StudentTime = xRepo.GetTestInfoTime(xStudent, CurrentTest);
        }
        private void SetScoreForStudent(Student xStudent)
        {
            StudentScore = xRepo.GetTestInfoScore(xStudent, CurrentTest);
        }
        public List<Test> AllTestsDone()
        {
            List<Test> AllTestsDone = new List<Test>();
            List<int> lxIds = xRepo.GetWritenTestsID();
            foreach (var item in lxIds)
            {
                AllTestsDone.Add(xRepo.GetTest(item));
            }
            foreach (var item in AllTestsDone)
            {
                Console.WriteLine(item.Name);
            }
            return AllTestsDone;
        }

    }
}
