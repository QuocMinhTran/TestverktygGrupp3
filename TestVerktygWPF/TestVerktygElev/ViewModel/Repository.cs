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
            opt.Text = "rätt svar";
            opt.RightAnswer = true;
            opt2.Text = "fel svar";
            opt2.RightAnswer = false;
            q.Answers.Add(opt);
            q.Answers.Add(opt2);
            qList.Add(q);

            q2.Name = "fråga nummer två";
            opt3.Text = "rätt";
            opt3.RightAnswer = true;
            opt4.Text = "rätt";
            opt4.RightAnswer = true;
            opt5.Text = "fel";
            opt5.RightAnswer = false;
            q2.Answers.Add(opt3);
            q2.Answers.Add(opt4);
            q2.Answers.Add(opt5);

            qList.Add(q2);
            //for (int i = 0; i < 2; i++)
            //{
            //    q.QuestionsLabel = "wow";
            //    for (int j = 0; j < 2; j++)
            //    {
            //        opt.SelectivOption = "answer";
            //        opt2.SelectivOption = "get your ass back down here now boy";
            //        q.Options.Add(opt);
            //        q.Options.Add(opt2);
            //    }
            //    qList.Add(q);
            //}
            //for (int i = 0; i < 2; i++)
            //{
            //    q2.QuestionsLabel = "run run bodywash";
            //    for (int j = 0; j < 2; j++)
            //    {
            //        opt3.SelectivOption = "get off the booze get off the dope";
            //        opt4.SelectivOption = "yogg saron awakens";
            //        opt5.SelectivOption = "my dream ends your nightmare begins";
            //        q2.Options.Add(opt3);
            //        q2.Options.Add(opt4);
            //        q2.Options.Add(opt5);
            //    }
            //    qList.Add(q2);
            //}
            return qList;
        }
    }
}
