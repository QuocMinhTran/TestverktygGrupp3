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
        public void SaveStudent(Student xStudent)
        {
            using (var db = new DbModel())
            {
                db.Students.Add(xStudent);
                db.SaveChanges();
            }
        }

        public void SaveTeacher(Teacher xTeacher)
        {
            using (var db = new DbModel())
            {
                db.Teachers.Add(xTeacher);
                db.SaveChanges();
            }
        }

        public void SaveAdmin(Admin xAdmin)
        {
            using (var db = new DbModel())
            {
                db.Admins.Add(xAdmin);
                db.SaveChanges();
            }
        }
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
