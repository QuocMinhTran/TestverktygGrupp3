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
    }
}
