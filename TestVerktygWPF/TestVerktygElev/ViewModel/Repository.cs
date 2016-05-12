using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygElev.ViewModel
{
    class Repository
    {

        public List<Test> GetTestForStudent(int p_iID)
        {
            List<Test> lxTest = new List<Test>();
            using (var db = new Model1())
            {
                var querry = from StudentTest in db.StudentTests
                             where StudentTest.IsTestDone == false
                             join Test in db.Tests on StudentTest.TestRefFk equals Test.ID
                             join StudentStudent in db.Students on StudentTest.StudentRefFk equals StudentStudent.ID into Group
                             from TestGroup in Group
                             where TestGroup.ID == p_iID
                             select Test;
                foreach (var item in querry)
                {
                    
                    Console.WriteLine(item.Name + " Name of Test From DataBase");
                    lxTest.Add(item);
                }
            }
            return lxTest;
        }
        public int GetStudentTestID(int p_iStudentID, int p_iTestID)
        {
            StudentTest xStudentTest = new StudentTest();
            using (var db = new Model1())
            {
                var querry = from StudentTest in db.StudentTests
                             join xTest in db.Tests on StudentTest.TestRefFk equals xTest.ID into GroupT
                             join xStuden in db.Students on StudentTest.StudentRefFk equals xStuden.ID into Group
                             from xGroup in Group
                             where xGroup.ID == p_iStudentID
                             from xGroupT in GroupT
                             where xGroupT.ID == p_iTestID
                             select StudentTest;
                foreach (var item in querry)
                {
                    xStudentTest = item;
                }



            }
            return xStudentTest.ID;
        }

        public List<StudentAnswer> GetStudentAnswers(int p_iStudentiD, int p_iTestiD)
        {
            List<StudentAnswer> lxStudentAnswer = new List<StudentAnswer>();
            using (var db = new Model1())
            {
                var querry = from xTest in db.StudentTests
                             join xStudent in db.Students on xTest.StudentRefFk equals xStudent.ID
                             join xAnswers in db.StudentAnswers on xTest.ID equals xAnswers.StudentTestFk
                             where xTest.ID == p_iTestiD
                             //where xStudent.ID == p_iStudentiD
                             select xAnswers;

                //var querry = from x in db.StudentAnswers
                //             select x;

                Console.WriteLine(querry.ToString());
                foreach (var item in querry)
                {
                    lxStudentAnswer.Add(item);
                }
            }
            
            return lxStudentAnswer;
        }

        internal Test GetTest(int p_IDTest)
        {
            Test xTest = new Test();
            using (var db = new Model1())
            {
                var querry = from test in db.Tests
                             where test.ID == p_IDTest
                             select test;
                foreach (var item in querry)
                {
                    xTest = item;
                }
            }
            return xTest;
        }

        internal List<Answer> GetAllAnswers(Test m_xTest)
        {
            List<Answer> lxAnwsers = new List<Answer>();
            using (var db = new Model1())
            {
                var querry = from Ans in db.Answers
                             join quest in db.Questions on Ans.QuestionFk equals quest.ID
                             join test in db.Tests on quest.TestFk equals test.ID
                             select Ans;
                foreach (var item in querry)
                {
                    lxAnwsers.Add(item);
                }
            }
            return lxAnwsers;
        }

        public List<Question> GetQuestions(int p_IDTest)
        {
            List<Question> xQuestion = new List<Question>();
            using (var db = new Model1())
            {
                var querry = from Quest in db.Questions
                             where Quest.TestFk == p_IDTest
                             select Quest;
                foreach (var item in querry)
                {
                    xQuestion.Add(item);
                }
            }
            return xQuestion;
        }

        internal List<Answer> GetAnwsers(int p_iQuestionID)
        {
            List<Answer> lxAnwsers = new List<Answer>();
            using (var db = new Model1())
            {
                var querry = from Ans in db.Answers
                             where Ans.QuestionFk == p_iQuestionID
                             select Ans;
                foreach (var item in querry)
                {
                    lxAnwsers.Add(item);
                }
            }
            return lxAnwsers;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (var db = new Model1())
            {
                var query = from s in db.Students
                            select s;
                foreach (var item in query)
                {
                    students.Add(item);
                }
            }
            return students;
        }

        public void SaveTest(List<StudentAnswer> m_lxStudentAnswer, int p_iScore,int p_iWritenTime)
        {
            int Id = 0;
            using (var db = new Model1())
            {
                foreach (var item in m_lxStudentAnswer)
                {
                    db.StudentAnswers.Add(item);
                    Id = item.StudentTestFk;
                }
                db.SaveChanges();
            }
            UpdateStudentTest(Id,p_iScore,p_iWritenTime);
        }
        public void UpdateStudentTest(int p_iStudentTest, int p_iScore ,int p_iWritenTime)
        {
            using (var db = new Model1())
            {
                var querry = from xStudentTest in db.StudentTests
                             where xStudentTest.ID == p_iStudentTest
                             select xStudentTest;
                foreach (var item in querry)
                {
                    Console.WriteLine("I HAVE I LIFE FOR NOW ::::" + item.ID + "ADASD");
                    item.IsTestDone = true;
                    item.Score = p_iScore;
                    item.WritenTime = p_iWritenTime;
                    
                }
                db.SaveChanges();
            }
        }
    }
}
