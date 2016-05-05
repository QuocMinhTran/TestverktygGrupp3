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
        public List<Test> AllTestsDone { get; private set; }
        public List<Test> AllTests { get; private set; }
        public List<Questions> CurrentQuestions { get; private set; }
        public List<Student> CurrentStudents { get; private set; }
        public Student CurrentStudent { get; private set; }
        public int StudentTime { get; private set; }
        public int StudentScore { get; private set; }
        public CurrentSelectedTest()
        {
            xRepo = new Repository();
        }
        public void SetCurrentTest(int ID)
        {
            CurrentTest = xRepo.GetTest(ID);
            SetCurrentQuestions(CurrentTest);
            SetCurrentStudents(CurrentTest);
        }
        public void SetCurrentTest(string sName)
        {

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
        public void SetCurrentStudent(string sName)
        {

        }
        public void SetCurrentStudent(int ID)
        {
            CurrentStudent = xRepo.GetStudent(ID);
            SetScoreForStudent(CurrentStudent);
            SetTimeForStudent(CurrentStudent);
        }
        public void SetCurrentStudent(Student xStudent)
        {
            CurrentStudent = xRepo.GetStudent(xStudent.ID);
        }
        private void SetCurrentStudents(Test xTest)
        {
            //CurrentStudents = xRepo.geta(xTest);
        }
        private void SetTimeForStudent(Student xStudent)
        {
            StudentTime = xRepo.GetTestInfoTime(xStudent);
        }
        private void SetScoreForStudent(Student xStudent)
        {
            StudentScore = xRepo.GetTestInfoScore(xStudent);
        }


    }
}
