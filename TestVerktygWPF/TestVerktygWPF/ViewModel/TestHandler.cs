using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVerktygWPF.Model;

namespace TestVerktygWPF.ViewModel
{
    class TestHandler
    {
        private List<Test> lxTest;
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
        public Test GetTest(int testId)
        {
            Test selectedTest = new Test();
            using (var db = new DbModel())
            {
                var getSelectTest = from theTest in db.Tests
                    where theTest.TestID == testId
                    select theTest;
                return selectedTest = getSelectTest as Test;
            }
            
        }

    }
}
