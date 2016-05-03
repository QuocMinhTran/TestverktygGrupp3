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

        public List<WritenTest> GetAllWrittenTests()
        {
            List<WritenTest> liAllWritenTests = new List<WritenTest>();
            using (var db = new DbModel())
            {
                var getAllTests = from test in db.WritenTests
                    select test;
                foreach (var allTest in getAllTests)
                {
                    liAllWritenTests.Add(allTest);
                }

            }
            return liAllWritenTests;
        } 
        public Occupation GetQuestion()
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

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> liAllTeachers = new List<Teacher>();
            using (var db = new DbModel())
            {
                var selectTeachers = from teacher in db.Teachers
                                     select teacher;
                foreach (var item in selectTeachers)
                {
                    liAllTeachers.Add(item);

                }
            }
            return liAllTeachers;
        }

        public List<Admin> GetAllAdmins()
        {
            List<Admin> liAllAdmins = new List<Admin>();
            using (var db = new DbModel())
            {
                var selectAdmins = from admin in db.Admins
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

        public void Removetudent(Student xStudent)
        {
            using (var db = new DbModel())
            {
                var deleteStudent = from student in db.Students
                    where student.StudentID == xStudent.StudentID
                    select student;
                foreach (var student in deleteStudent)
                {
                    db.Students.Remove(student);
                }
                db.SaveChanges();
            }
        }

        public void RemoveTeacher(Teacher xTeacher)
        {
            using (var db = new DbModel())
            {
                var deleteTeacher = from teacher in db.Teachers
                                    where teacher.TeacherID == xTeacher.TeacherID
                                    select teacher;
                foreach (var teacher in deleteTeacher)
                {
                    db.Teachers.Remove(teacher);
                }
                db.SaveChanges();
            }
        }

        public void RemoveAdmin(Admin xAdmin)
        {
            using (var db = new DbModel())
            {
                var deleteAdmin = from admin in db.Admins
                                    where admin.AdminID == xAdmin.AdminID
                                    select admin;
                foreach (var admin in deleteAdmin)
                {
                    db.Admins.Remove(admin);
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
                                      where student.StudentID == xStudent.StudentID
                                      select student;
                foreach (var item in selectedstudent)
                {
                    item.FirstName = xStudent.FirstName;
                    item.LasttName = xStudent.LasttName;
                    item.Email = xStudent.Email;
                    item.Password = xStudent.Password;
                    item.UserName = xStudent.UserName;
                    item.Occupations = xStudent.Occupations;
                    item.StudentID = xStudent.StudentID;


                }
                db.SaveChanges();
            }
        }

        public void EditTeacher(Teacher xTeacher)
        {
            using (var db = new DbModel())
            {
                var selectedTeacher = from teacher in db.Teachers
                                      where teacher.TeacherID == xTeacher.TeacherID
                                      select teacher;
                foreach (var item in selectedTeacher)
                {
                    item.FirstName = xTeacher.FirstName;
                    item.LasttName = xTeacher.LasttName;
                    item.Email = xTeacher.Email;
                    item.Password = xTeacher.Password;
                    item.UserName = xTeacher.UserName;

                }
                db.SaveChanges();
            }
        }

        public void EditAdmin(Admin xAdmin)
        {
            using (var db = new DbModel())
            {
                var selectedAdmin = from admin in db.Admins
                                    where admin.AdminID == xAdmin.AdminID
                                    select admin;
                foreach (var item in selectedAdmin)
                {
                    item.FirstName = xAdmin.FirstName;
                    item.LasttName = xAdmin.LasttName;
                    item.Email = xAdmin.Email;
                    item.Password = xAdmin.Password;
                    item.UserName = xAdmin.UserName;
                }
                db.SaveChanges();
            }
        }
        public void EditTest() { }

 

    }
}
