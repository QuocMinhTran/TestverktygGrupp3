using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygElev.ViewModel
{
    class Repository
    {
        //public Test GetTest()
        //{
        //    Test test = new Test();
        //    test.Name = "testes";
        //    test.StartDate = DateTime.Today;
        //    test.EndDate = DateTime.Today.AddDays(1);
        //    return test;
        //}

        //public List<Question> GetQuestion()
        //{
        //    List<Question> qList = new List<Question>();
        //    Question q = new Question();
        //    Answer opt = new Answer();
        //    Answer opt2 = new Answer();

        //    Question q2 = new Question();
        //    Answer opt3 = new Answer();
        //    Answer opt4 = new Answer();
        //    Answer opt5 = new Answer();

        //    q.Name = "fråga nummer ett";
        //    q.QuestionType = "envalsfråga";
        //    opt.Text = "rätt svar";
        //    opt.RightAnswer = true;
        //    opt2.Text = "fel svar";
        //    opt2.RightAnswer = false;
        //    q.Answers.Add(opt);
        //    q.Answers.Add(opt2);

        //    q2.Name = "fråga nummer två";
        //    q2.QuestionType = "flervalsfråga";
        //    opt3.Text = "rätt";
        //    opt3.RightAnswer = true;
        //    opt4.Text = "rätt";
        //    opt4.RightAnswer = true;
        //    opt5.Text = "fel";
        //    opt5.RightAnswer = false;
        //    q2.Answers.Add(opt3);
        //    q2.Answers.Add(opt4);
        //    q2.Answers.Add(opt5);

        //    Question q3 = new Question();
        //    Answer opt6 = new Answer();
        //    Answer opt7 = new Answer();
        //    Answer opt8 = new Answer();
        //    Answer opt9 = new Answer();

        //    q3.Name = "fråga nummer tre";
        //    q3.QuestionType = "rangordning";
        //    opt6.Text = "ett";
        //    opt7.Text = "två";
        //    opt8.Text = "tre";
        //    opt9.Text = "fyra";
        //    q3.Answers.Add(opt6);
        //    q3.Answers.Add(opt7);
        //    q3.Answers.Add(opt8);
        //    q3.Answers.Add(opt9);

        //    qList.Add(q);
        //    qList.Add(q2);
        //    qList.Add(q3);
        //    return qList;


        //}

        //public List<Question> GetQuestion(int ID)
        //{
        //    //List<Question> lxQuestions = new List<Question>();
        //    List<Answer> lxAnswer = new List<Answer>();
        //    //using (var db = new Model1())
        //    //{
        //    //    var querry = from Quest in db.Questions
        //    //                 where Quest.TestFk == ID
        //    //                 select Quest;

        //    //    foreach (var item in querry)
        //    //    {
        //    //        lxQuestions.Add(querry);
        //    //    }
        //    //}
        //    //return lxQuestions;
                  
        //    List<Question> lxQuestion = new List<Question>();
        //    using (var db = new Model1())
        //    {
        //        var selectTest = from question in db.Questions
        //                         where question.TestFk == ID
        //                         select question;

        //        foreach (var item in selectTest)
        //        {
        //            lxQuestion.Add(item);
        //        }
        //    }
        //    return lxQuestion;
        //}

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
    }
}
