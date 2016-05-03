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
            Option opt = new Option();
            Option opt2 = new Option();
            for (int i = 0; i < 4; i++)
            {
                q.QuestionsLabel = "wow";
                for (int j = 0; j < 4; j++)
                {
                    opt.SelectivOption = "answer";
                    opt2.SelectivOption = "get your ass back down here now boy";
                    q.Options.Add(opt);
                    q.Options.Add(opt2);
                }
                qList.Add(q);
            }
            return qList;
        }
    }
}
