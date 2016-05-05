using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygElev.ViewModel
{
    class Repository
    {
        public Test GetTest()
        {
            Test test = new Test();
            test.Name = "testes";
            test.StartDate = DateTime.Today;
            test.EndDate = DateTime.Today.AddDays(1);
            return test;
        }

        public List<Question> GetQuestion()
        {
            List<Question> qList = new List<Question>();
            Question q = new Question();
            Answer opt = new Answer();
            Answer opt2 = new Answer();

            Question q2 = new Question();
            Answer opt3 = new Answer();
            Answer opt4 = new Answer();
            Answer opt5 = new Answer();

            q.Name = "fråga nummer ett";
            q.QuestionType = "envalsfråga";
            opt.Text = "rätt svar";
            opt.RightAnswer = true;
            opt2.Text = "fel svar";
            opt2.RightAnswer = false;
            q.Answers.Add(opt);
            q.Answers.Add(opt2);

            q2.Name = "fråga nummer två";
            q2.QuestionType = "flervalsfråga";
            opt3.Text = "rätt";
            opt3.RightAnswer = true;
            opt4.Text = "rätt";
            opt4.RightAnswer = true;
            opt5.Text = "fel";
            opt5.RightAnswer = false;
            q2.Answers.Add(opt3);
            q2.Answers.Add(opt4);
            q2.Answers.Add(opt5);

            Question q3 = new Question();
            Answer opt6 = new Answer();
            Answer opt7 = new Answer();
            Answer opt8 = new Answer();
            Answer opt9 = new Answer();

            q3.Name = "fråga nummer tre";
            q3.QuestionType = "rangordning";
            opt6.Text = "ett";
            opt7.Text = "två";
            opt8.Text = "tre";
            opt9.Text = "fyra";
            q3.Answers.Add(opt6);
            q3.Answers.Add(opt7);
            q3.Answers.Add(opt8);
            q3.Answers.Add(opt9);

            qList.Add(q);
            qList.Add(q2);
            qList.Add(q3);
            return qList;
        }
    }
}
