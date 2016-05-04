﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestVerktygWPF.Model;
using TestVerktygWPF.View;

namespace TestVerktygWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _Frame.Navigate(new View.AdminUserManagementPage());

           // AddDataToBase();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //TODO: send UserName and Password to database and login if there is a match
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                btnLogin_Click(sender, e);
        }



        //private void AddData()
        //{
        //    using (var db = new DbModel())
        //    {
        //        Student xStudent = new Student();
        //        xStudent.FirstName = "Hej";
        //        xStudent.LasttName = "Glensson";
        //        xStudent.Email = "Glenn";
        //        xStudent.UserName = "ASDGF";
        //        db.Students.Add(xStudent);
        //        db.SaveChanges();
        //    }
        //}

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem btn = sender as MenuItem;
            switch (btn.Header.ToString())
            {
                case "Hantera Prov":
                    _Frame.Navigate(new TeacherTestManagementPage());
                    break;
                case "GöraProv":
                    _Frame.Navigate(new TeacherCreateTestPage());
                    break;

            }
        }
        private void AddDataToBase()
        {
            List<Admin> lxAdmin = AddAdmin();
            List<Student> lxStudent = AddStudent();
            List<Teacher> lxTeacher = AddTeacher();

            List<Course> lxCourse = AddCourse();
            List<CourseGradeClass> lxCGC = AddCoruseGradeClass();
            List<GradeClass> lxGC = AddGradeClass();
            List<Occupation> lxOcc = AddOccupation();
            List<Option> lxOp = AddOptions();
            List<Test> lxTest = AddTest();
            List<TestQuestion> lxTestQues = AddTestQuest();
            List<WritenTest> lxWT = AddWritenTest();

            List<Questions> lxQuest = AddQuestion();

            using (var db = new DbModel())
            {
                foreach (var item in lxAdmin)
                {
                    db.Admins.Add(item);
                }
                foreach (var item in lxTeacher)
                {
                    db.Teachers.Add(item);
                }
                foreach (var item in lxStudent)
                {
                    db.Students.Add(item);
                }

            }

        }
        private List<Questions> AddQuestion() { return null; }

        private List<Course> AddCourse() { return null; }
        private List<CourseGradeClass> AddCoruseGradeClass() { return null; }
        private List<GradeClass> AddGradeClass() { return null; }
        private List<Occupation> AddOccupation() { return null; }
        private List<Option> AddOptions() { return null; }

        private List<Test> AddTest() { return null; }
        private List<TestQuestion> AddTestQuest() { return null; }
        private List<WritenTest>AddWritenTest () { return null; }
        private List<Admin> AddAdmin()
        {
            List<Admin> lxAdmin = new List<Admin>();
            Occupation xOcc = new Occupation();
            xOcc.OccupationID = 1;
            Admin xAdmin = new Admin()
            {
                FirstName = "Jan",
                UserName = "JanBen01",
                Password = "ASd",
                Email = "Asd",
                LasttName = "Benson",
                Occupations = xOcc,
               

            };

            Admin xAdmin2 = new Admin()
            {
                FirstName = "Glenn",
                UserName = "GlenBen01",
                Password = "ASd",
                Email = "Asd",
                LasttName = "Benson",
            };
            lxAdmin.Add(xAdmin2);
            lxAdmin.Add(xAdmin);
            return lxAdmin;
        }
        private List<Teacher> AddTeacher()
        {
            List<Teacher> lxTeacher = new List<Teacher>();
            Occupation xOcc = new Occupation();
            xOcc.OccupationID = 2;
            Teacher xTeacher = new Teacher()
            {
                FirstName = "TJÖTA",
                UserName = "TJöBen01",
                Password = "wadww",
                Email = "Asd",
                LasttName = "Åkersson",
                Occupations = xOcc,
            };

            Teacher xTeacher2 = new Teacher()
            {
                FirstName = "HullaBallo",
                UserName = "GlenBen01",
                Password = "ASd",
                Email = "Asd",
                LasttName = "Huvudvärk",
            };
            lxTeacher.Add(xTeacher2);
            lxTeacher.Add(xTeacher);
           
            return lxTeacher;
        }
        private List<Student> AddStudent()
        {
            List<Student> lxStudent = new List<Student>();
            Occupation xOcc = new Occupation();
            xOcc.OccupationID = 3;
            Student xStudent = new Student()
            {
                FirstName = "TJÖTA",
                UserName = "TJöBen01",
                Password = "wadww",
                Email = "Asd",
                LasttName = "Åkersson",
                Occupations = xOcc,
            };

            Student xStudent2 = new Student()
            {
                FirstName = "HullaBallo",
                UserName = "GlenBen01",
                Password = "ASd",
                Email = "Asd",
                LasttName = "Huvudvärk",
            };
            lxStudent.Add(xStudent);
            lxStudent.Add(xStudent2);

            return lxStudent;
        }
        
    }
}
