using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVerktygWPF.Model;

namespace TestVerktygWPF.ViewModel
{
    public class TestHandler
    {
        private Test xTest;
        private List<Questions> xQuestions;
        private List<Answer> xAnswer;

        public TestHandler()
        {
            xAnswer = new List<Answer>();
            xQuestions = new List<Questions>();
            xTest = new Test();
        }
        public void RemoveTest()
        {

        }
        public void AddTest()
        {

        }
        public void EditTest()
        {

        }
        public void Init()
        {
            //Todo GetList From Reposatory
        }
        public void SaveTestToDatabase()
        {

        }
        public Test GetTest()
        {
            return null;
        }

    }
}
