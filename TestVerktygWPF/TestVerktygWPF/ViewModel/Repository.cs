﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using TestVerktygWPF.Model;

namespace TestVerktygWPF.ViewModel
{
    class Repository
    {
        public User GetUser()
        {
            return null;
        }
        public Student GetStudent(int ID)
        {
            Student xStudent = new Student();
            using (var db = new DbModel())
            {
                var querry = from studnet in db.Students
                             where studnet.ID == ID
                             select studnet;
                foreach (var item in querry)
                {
                    xStudent = item;
                }

            }
            return xStudent;
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
                var querry = from Qtest in db.Tests
                             where Qtest.ID == iD
                             select Qtest;
                foreach (var item in querry)
                {
                    Console.WriteLine("insent id: " + iD);
                    Console.WriteLine("Repo get test : " + item.ID + item.Name);
                    xTest = item;
                }
                //xTest = querry as Test;
            }
            return xTest;
        }

        internal void SaveAnwnser(Answer itemAnswer)
        {
            Console.WriteLine(itemAnswer.OrderPosition);
            using (var db = new DbModel())
            {
                Console.WriteLine(itemAnswer + "SAVING ANWNSER");
                db.Answers.Add(itemAnswer);
                db.SaveChanges();
            }
        }

        public List<Test> GetAllTests()
        {
            List<Test> lxTests = new List<Test>();
            using (var db = new DbModel())
            {
                var selectTest = from test in db.Tests
                                 select test;

                foreach (var item in selectTest)
                {
                    lxTests.Add(item);
                }
            }
            return lxTests;
        }
        public List<int> GetWritenTestsID()
        {
            List<StudentTest> lxTests = new List<StudentTest>();
            List<int> liList = new List<int>();
            using (var db = new DbModel())
            {
                var selectTest = from test in db.StudentTests
                                 select test;

                foreach (var item in selectTest)
                {
                    lxTests.Add(item);
                }
                foreach (var item in lxTests)
                {
                    liList.Add(item.TestRefFk);
                }
            }
            return liList;
        }

        public List<StudentTest> GetTestDone(int iD)
        {
            List<StudentTest> lxStudent = new List<StudentTest>();
            using (var db = new DbModel())
            {
                var selected = from studentTest in db.StudentTests
                               where studentTest.TestRefFk == iD
                               select studentTest;

                foreach (var item in selected)
                {
                    lxStudent.Add(item);
                }
            }
            return lxStudent;
        }
        public List<StudentTest> GetStudentsTests(int iD)
        {
            List<StudentTest> lxStudent = new List<StudentTest>();
            using (var db = new DbModel())
            {
                var selected = from studentTest in db.StudentTests
                               where studentTest.StudentRefFk == iD
                               select studentTest;

                foreach (var item in selected)
                {
                    lxStudent.Add(item);
                }
            }
            return lxStudent;
        }

        public List<Student> GetAllStudents(Test xTest)
        {
            List<Student> lxStudent = new List<Student>();

            using (var db = new DbModel())
            {
                var selected = from studentTest in db.StudentTests
                               join student in db.Students on studentTest.StudentRefFk equals student.ID
                               where xTest.ID == studentTest.TestRefFk
                               select student;

                foreach (var item in selected)
                {
                    lxStudent.Add(item);
                }
            }
            return lxStudent;
        }

        public Test GetTest(string sName)
        {
            Test xTest = new Test();
            using (var db = new DbModel())
            {
                var selectTest = from test in db.Tests
                                 where test.Name == sName
                                 select test;

                foreach (var item in selectTest)
                {
                    xTest = item;
                }
            }
            return xTest;
        }

        //internal List<Option> GetOptions(int questionID)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Questions> GetQuestion(int testID)
        {
            List<Questions> lxQuestion = new List<Questions>();
            using (var db = new DbModel())
            {
                var selectTest = from question in db.Questions
                                 where question.TestFk == testID
                                 select question;

                foreach (var item in selectTest)
                {
                    lxQuestion.Add(item);
                }
            }
            return lxQuestion;
        }


        //public Questions GetQuestion()
        //{
        //    return null;
        //}

        public List<StudentClass> GetClasses()
        {
            List<StudentClass> liAllClasses = new List<StudentClass>();
            using (var db = new DbModel())
            {
                var selectClass = from xclass in db.StudentClasses
                                  select xclass;

                foreach (var item in selectClass)
                {
                    liAllClasses.Add(item);
                }
            }

            return liAllClasses;
        }


        public Student GetStudent(string sName)
        {
            Student xTest = new Student();
            using (var db = new DbModel())
            {
                var selectStudent = from student in db.Students
                                    where student.FirstName == sName
                                    select student;

                xTest = selectStudent as Student;
            }
            return xTest;
        }
        public Student GetStudent(string sName, string sLastName)
        {
            Student xTest = new Student();
            using (var db = new DbModel())
            {
                var selectStudent = from student in db.Students
                                    where student.FirstName == sName
                                    where student.LastName == sLastName
                                    select student;

                xTest = selectStudent as Student;
            }
            return xTest;
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

        public int GetTestInfoScore(Student xStudent, Test xText)
        {
            StudentTest xTest = new StudentTest();
            using (var db = new DbModel())
            {
                Console.WriteLine(xStudent.ID + " STUDENT ID " + xTest.ID + " TEST ID");
                var querry = from qTime in db.StudentTests
                             where qTime.StudentRefFk == xStudent.ID
                             where qTime.TestRefFk == xText.ID
                             select qTime;

                foreach (var item in querry)
                {
                    xTest = item;
                }


            }
            return xTest.Score;
        }

        internal int GetTestInfoTime(Student xStudent, Test xText)
        {
            StudentTest xTest = new StudentTest();
            using (var db = new DbModel())
            {
                var querry = from Time in db.StudentTests
                             where Time.StudentRefFk == xStudent.ID
                             where Time.TestRefFk == xText.ID
                             select Time;
                foreach (var item in querry)
                {
                    xTest = item;
                }

            }
            return xTest.WritenTime;
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
                                   where admin.OccupationFk == 2
                                   select admin;
                foreach (var item in selectAdmins)
                {
                    liAllAdmins.Add(item);

                }
            }

            return liAllAdmins;
        }
        public List<User> GetAllUsers()
        {
            List<User> liAllUsers = new List<User>();
            using (var db = new DbModel())
            {
                var selectUsers = from users in db.Users
                                  select users;
                foreach (var item in selectUsers)
                {
                    liAllUsers.Add(item);
                }
            }
            return liAllUsers;
        }

        public List<Answer> GetCorrectAnswer(int id)
        {
            List<Answer> correctAnswer = new List<Answer>();
            using (var db = new DbModel())
            {
                var getAnswer = from theAnswer in db.Answers
                                where theAnswer.QuestionFk == id
                                where theAnswer.RightAnswer == true
                                select theAnswer;
                foreach (var item in getAnswer)
                {
                    correctAnswer.Add(item);
                }
            }
            return correctAnswer;
        }
        //Svikans
        //public List<Answer> GetStudetAnswers(int p_iID)
        //{
        //    List<Answer> lxAnswer = new List<Answer>();
        //    using (var db = new DbModel())
        //    {
        //        var querry =
        //            from p in db.StudentTests
        //                //where p.TestRefFk == p_iID
        //            join pc in db.StudentAnswers on p.TestRefFk equals p_iID
        //            join c in db.Answers on pc.Answer equals c.ID
        //            select c;

        //        //var querry = from x in db.StudentTests
        //        //             join xSudent in db.StudentTests on x.ID equals  xSudent.TestRefFk into Group
        //        //             from y in Group
        //        //             join xtest in db.Tests on x.TestRefFk equals p_iID
        //        //             join xQuestion in db.Questions on xtest.ID equals xQuestion.TestFk
        //        //             join answer in db.Answers on xQuestion.ID equals answer.QuestionFk
        //        //             select answer;

        //        Console.WriteLine("Querry körs" + querry.Count());

        //        for (int i = 0; i < querry.Count(); i++)
        //        {
        //            Console.WriteLine("for loop " + i);
        //        }
        //        foreach (var item in querry)
        //        {
        //            lxAnswer.Add(item);
        //            Console.WriteLine("item :" + item.Text);
        //        }

        //    }
        //    return lxAnswer;
        //}
        //Gurras
        public List<StudentAnswer> GetStudentAnswers(int p_iStudentiD, int p_iTestiD)
        {
            List<StudentAnswer> lxStudentAnswer = new List<StudentAnswer>();
            using (var db = new DbModel())
            {
                var querry = from xTest in db.StudentTests
                             join xStudent in db.Students on xTest.StudentRefFk equals xStudent.ID
                             join xAnswers in db.StudentAnswers on xTest.ID equals xAnswers.StudentTestFk
                             where xTest.TestRefFk == p_iTestiD
                             //where xStudent.ID == p_iStudentiD
                             select xAnswers;

                //var querry = from x in db.StudentAnswers
                //             select x;

                Console.WriteLine(querry.ToString());
                foreach (var item in querry)
                {
                    lxStudentAnswer.Add(item);
                }
            }

            return lxStudentAnswer;
        }
        internal List<Answer> GetAllAnswers(Test m_xTest)
        {
            List<Answer> lxAnwsers = new List<Answer>();
            using (var db = new DbModel())
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
        //public List<Answer> GetStudentAnswers(int id)
        //{
        //    using (var db = new DbModel())
        //    {
        //        var getAnswer = from studentAnswers in db.StudentTests
        //                        where studentAnswers.TestRefFk == id
        //                        where studentAnswers.IsTestDone == true
        //    }
        //    return null;
        //}
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

        public void SaveUserTest(UserTest userTest)
        {
            using (var db = new DbModel())
            {
                db.UserTests.Add(userTest);
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

        public int SaveQuestion(Questions xQuestion)
        {
            Questions xQuest = new Questions();
            using (var db = new DbModel())
            {

                db.Questions.Add(xQuestion);
                db.SaveChanges();

                var selectedTest = from test in db.Questions
                                   where test.ID == xQuestion.ID
                                   select test;
                foreach (var item in selectedTest)
                {
                    xQuest = item;
                }
                Console.WriteLine(xQuest.ID + "SaveQuestion ID");
            }
            return xQuest.ID;

        }


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
