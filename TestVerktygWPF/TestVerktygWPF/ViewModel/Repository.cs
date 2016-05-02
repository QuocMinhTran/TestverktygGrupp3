using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVerktygWPF.Model;

namespace TestVerktygWPF.ViewModel
{
    class Repository
    {
        public Teacher GetTeacher()
        {
            return null;
        }
        public Admin GetAdmin()
        {
            return null;
        }
        public Student GetStudent()
        {
            return null;
        }
        public Test GetTest()
        {
            return null;
        }
        public Occupation GetQuestion()
        {
            return null;
        }
        //Save
        public void SaveStudent() { }
        public void SaveTeacher() { }
        public void SaveAdmin() { }
        public void SaveTest(Test xTest)
        {
            using (var db = new DbModel())
            {
                db.Tests.Add(xTest);
                db.SaveChanges();

            }
        }
        public void SaveQuestion() { }


        //Delete
        public void RemoveQuestion() { }
        public void Removetudent() { }
        public void RemoveTeacher() { }
        public void RemoveAdmin() { }
        public void RemoveTest() { }


        //Edit
        public void EditQuestion() { }
        public void Edittudent() { }
        public void EditTeacher() { }
        public void EditAdmin() { }
        public void EditTest() { }

 

    }
}
