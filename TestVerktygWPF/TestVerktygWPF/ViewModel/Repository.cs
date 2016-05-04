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

       
        public User GetUser()
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

        public Test GetTest(int iD)
        {
            Test xTest = new Test();
            using (var db = new DbModel())
            {
                var querry = from test in db.Tests
                             where test.ID == iD
                             select test;
                xTest = querry as Test;
            }

            return xTest;
        }

        //internal List<Option> GetOptions(int questionID)
        //{
        //    throw new NotImplementedException();
        //}

        internal List<Questions> GetQuestion(int testID)
        {
            throw new NotImplementedException();
        }


        public Questions GetQuestion()
        {
            return null;
        }

       

        public List<Student> GetAllStudents()
        {
            List<Student> liAllStudents = new List<Student>();
            using (var db = new DbModel())
            {
                var selectStudents = from student in db.Students
                                     select student;

                foreach (var item in selectStudents)
                {
                    liAllStudents.Add(item);
                }
            }

            return liAllStudents;
        }

        public List<User> GetAllTeachers()
        {
            List<User> liAllTeachers = new List<User>();
            using (var db = new DbModel())
            {
                var selectTeachers = from teacher in db.Users
                    where teacher.OccupationFk == 1 
                    select teacher;
                foreach (var item in selectTeachers)
                {
                    liAllTeachers.Add(item);

                }
            }
            return liAllTeachers;
        }

        public List<User> GetAllAdmins()
        {
            List<User> liAllAdmins = new List<User>();
            using (var db = new DbModel())
            {
                var selectAdmins = from admin in db.Users
                                   where admin.OccupationFk ==2
                                   select admin;
                foreach (var item in selectAdmins)
                {
                    liAllAdmins.Add(item);

                }
            }

            return liAllAdmins;
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

        public void SaveUser(User xUser)
        {
            using (var db = new DbModel())
            {
                db.Users.Add(xUser);
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

        public void Removetudent(Student xStudent)
        {
            using (var db = new DbModel())
            {
                var deleteStudent = from student in db.Students
                                    where student.ID == xStudent.ID
                                    select student;
                foreach (var student in deleteStudent)
                {
                    db.Students.Remove(student);
                }
                db.SaveChanges();
            }
        }

        public void RemoveUser(User xUser)
        {
            using (var db = new DbModel())
            {
                var deleteUser = from user in db.Users
                                    where user.ID == xUser.ID
                                    select user;
                foreach (var user in deleteUser)
                {
                    db.Users.Remove(user);
                }
                db.SaveChanges();
            }
        }

       
        public void RemoveTest() { }


        //Edit
        public void EditQuestion() { }

        public void Edittudent(Student xStudent)
        {
            using (var db = new DbModel())
            {
                var selectedstudent = from student in db.Students
                                      where student.ID == xStudent.ID
                                      select student;
                foreach (var item in selectedstudent)
                {
                    item.FirstName = xStudent.FirstName;
                    item.LastName = xStudent.LastName;
                    item.Email = xStudent.Email;
                    item.Password = xStudent.Password;
                    item.UserName = xStudent.UserName;
                    item.Occupations = xStudent.Occupations;
                    item.ID = xStudent.ID;


                }
                db.SaveChanges();
            }
        }

       public void EditUser(User xUser)
        {
            using (var db = new DbModel())
            {
                var selectedUser = from user in db.Users
                                    where user.ID == xUser.ID
                                    select user;
                foreach (var item in selectedUser)
                {
                    item.FirstName = xUser.FirstName;
                    item.LastName = xUser.LastName;
                    item.Email = xUser.Email;
                    item.Password = xUser.Password;
                    item.UserName = xUser.UserName;
                }
                db.SaveChanges();
            }
        }
        public void EditTest() { }

 

    }
}
