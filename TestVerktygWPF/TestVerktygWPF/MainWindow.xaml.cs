using System;
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
            List<Answer> lxAnswer = AddAnswer();
            List<Course> lxCourse = AddCourse();
            List<Occupation> lxOcc = AddOccupation();       //Done
            List<Questions> lxQuestions = AddQuestion();    //Done

            List<Student> lxStudent = AddStudent();         //Done
            List<StudentAnswer> lxStudentAnswer = AddStudentAwnser();
            List<StudentClassCourse> lxSGC = AddStudentClassCourse();
            List<StudentClass> lxSC = AddStudentClass();
            List<StudentTest> lxStudentTest = AddStudentTest();

            List<Test> lxTest = AddTest();                  //Done
            List<User> lxUser = AddUser();                  //Done
            List<UserTest> lxUserTest = AddUserTest();
            #region UsingDB
            using (var db = new DbModel())
            {
                foreach (var item in lxAnswer)
                {
                    db.Answers.Add(item);
                }
                foreach (var item in lxCourse)
                {
                    db.Courses.Add(item);
                }
                foreach (var item in lxOcc)
                {
                    db.Occupations.Add(item);
                }
                foreach (var item in lxQuestions)
                {
                    db.Questions.Add(item);
                }
                /////////////////START////////////////////STUDENT////////////////////START////////////////////////
                foreach (var item in lxStudent)
                {
                    db.Students.Add(item);
                }
                foreach (var item in lxStudentAnswer)
                {
                    db.StudentAnswers.Add(item);
                }
                foreach (var item in lxSGC)
                {
                    db.StudentClassCourses.Add(item);
                }

                foreach (var item in lxSC)
                {
                    db.StudentClasses.Add(item);
                }
                foreach (var item in lxStudentTest)
                {
                    db.StudentTests.Add(item);
                }
                //////////////END///////////////////////STUDENT///////////////////////////END/////////////////
                foreach (var item in lxTest)
                {
                    db.Tests.Add(item);
                }

                foreach (var item in lxUser)
                {
                    db.Users.Add(item);
                }
                foreach (var item in lxUserTest)
                {
                    db.UserTests.Add(item);
                }

            }
            #endregion

        }

        private List<UserTest> AddUserTest()
        {
            throw new NotImplementedException();
        }

        private List<StudentTest> AddStudentTest()
        {
            throw new NotImplementedException();
        }

        private List<StudentClassCourse> AddStudentClassCourse()
        {
            throw new NotImplementedException();
        }

        private List<StudentClass> AddStudentClass()
        {
            throw new NotImplementedException();
        }

        private List<StudentAnswer> AddStudentAwnser()
        {
            throw new NotImplementedException();
        }

        private List<Answer> AddAnswer()
        {
            List<Answer> lxAnswer = new List<Answer>();
            Answer xOptions = new Answer()
            {
                Text = "Röd",
                RightAnswer = false,
                QuestionFk = 1
              
            };
            Answer xOptions11 = new Answer()
            {
                Text = "Djur",
                RightAnswer = true,
                QuestionFk = 1
        };
            Answer xOptions12 = new Answer()
            {

                Text = "Stolpe",
                RightAnswer = false,
                QuestionFk = 1
            };
            Answer xOptions13 = new Answer()
            {

                Text = "Röd",
                RightAnswer = false,
                QuestionFk = 2
            };
            Answer xOption14 = new Answer()
            {

                Text = "Bil",
                RightAnswer = true,
                QuestionFk = 2
            };
            Answer xOptions115= new Answer()
            {

                Text = "Bi",
                RightAnswer = false,
                QuestionFk = 2
            };
            Answer xOptions16 = new Answer()
            {

                Text = "8/4",
                RightAnswer = true,
                QuestionFk = 3
            };
            Answer xOptions17 = new Answer()
            {
                Text = "2*1",
                RightAnswer = true,
                QuestionFk = 3
            };
            Answer xOptions18 = new Answer()
            {
                Text = "9-5",
                RightAnswer = false,
                QuestionFk = 3
            };
            Answer xOptions19 = new Answer()
            {
                Text = "4",
                RightAnswer = true,
                QuestionFk = 4
            };
            Answer xOptions10 = new Answer()
            {
                Text = "5",
                RightAnswer = false,
                QuestionFk = 4
            };
            Answer xOptions1 = new Answer()
            {
                Text = "6",
                RightAnswer = false,
                QuestionFk = 4
            };
            Answer xOptions2 = new Answer()
            {
                Text = "5*1+4",
                RightAnswer = true,
                QuestionFk = 5,
               // OrderPosistion = 1
            };
            Answer xOptions3 = new Answer()
            {
                Text = "4+2+5/5",
                RightAnswer = true,
                QuestionFk = 5,
                // OrderPosistion = 2
            };
            Answer xOption4 = new Answer()
            {
                Text = "4+2+8*0",
                RightAnswer = true,
                QuestionFk = 5,
                // OrderPosistion = 3
            };
            Answer xOptions15 = new Answer()
            {
                Text = "Röd",
                RightAnswer = false,
                QuestionFk = 6
            };
            Answer xOptions6 = new Answer()
            {
                Text = "Blå",
                RightAnswer = true,
                QuestionFk = 6
            };
            Answer xOptions7 = new Answer()
            {
                Text = "Gul",
                RightAnswer = true,
                QuestionFk = 6
            };
            Answer xOptions8 = new Answer()
            {
                Text = "Blåval",
                RightAnswer = false,
                QuestionFk = 7
                // OrderPosistion = 1
            };
            Answer xOptions9 = new Answer()
            {
                Text = "Elefant",
                RightAnswer = false,
                QuestionFk = 7
                // OrderPosistion = 2
            };
            Answer xOptions28 = new Answer()
            {
                Text = "Bil",
                RightAnswer = false,
                QuestionFk = 7
                // OrderPosistion = 3
            };
            Answer xOptions29 = new Answer()
            {
                Text = "Människa",
                RightAnswer = false,
                QuestionFk = 7
                // OrderPosistion = 4
            };
            return null;
        }

        private List<Questions> AddQuestion()
        {
            List<Questions> lxQuestion = new List<Questions>();
            Questions xQuest = new Questions()
            {
                Name = "Vad är kanin en kanin?",
                QuestionType = "envalsfråga",
                TestFk = 1,
                AppData = "",
            };
            Questions xQuest2 = new Questions()
            {
                Name = "Vad är en Bil",
                QuestionType = "envalsfråga",
                TestFk = 1,
                AppData = "",
            };
            Questions xQuest3 = new Questions()
            {
                Name = "1+5*0+3",
                QuestionType = "Flervalsfråga",
                TestFk = 1,
                AppData = "",
            };
            Questions xQuest4 = new Questions()
            {
                Name = "2+2",
                QuestionType = "envalsfråga",
                TestFk = 2,
                AppData = "",
            };
            Questions xQuest5 = new Questions()
            {
                Name = "Vilken Är störst",
                QuestionType = "rangordning",
                TestFk = 3,
                AppData = "",
            };
            Questions xQuest6 = new Questions()
            {
                Name = "Vilka färger ser du?",
                QuestionType = "Flervalsfråga",
                TestFk = 4,
                AppData = "",
            };
            Questions xQuest7 = new Questions()
            {
                Name = "Vilken är längst?",
                QuestionType = "rangordning",
                TestFk = 4,
                AppData = "",
            };
            lxQuestion.Add(xQuest);
            lxQuestion.Add(xQuest2);
            lxQuestion.Add(xQuest3);
            lxQuestion.Add(xQuest4);
            lxQuestion.Add(xQuest5);
            lxQuestion.Add(xQuest6);
            lxQuestion.Add(xQuest7);
            

            return lxQuestion;
        }

        private List<Course> AddCourse() {
            return null;
        }
        private List<StudentClassCourse> AddCoruseGradeClass() {
            return null;
        }
        private List<StudentClass> AddGradeClass() {
            return null;
        }
        private List<Occupation> AddOccupation()
        {
            List<Occupation> lxOccupation = new List<Occupation>();
            Occupation xOccup = new Occupation()
            {
                ID = 1, Occupations = "lärare",     
            };
            Occupation xOccup2 = new Occupation()
            {
                ID = 2,
                Occupations = "admin",
            };
            Occupation xOccup3 = new Occupation()
            {
                ID = 3,
                Occupations = "elev",
            };
            lxOccupation.Add(xOccup);
            lxOccupation.Add(xOccup2);
            lxOccupation.Add(xOccup3);

            return lxOccupation;
        }
        private List<Answer> AddOptions()
        {
            return null;
        }

        private List<Test> AddTest()
        {
            List<Test> lxTest = new List<Test>();
            Test xTest = new Test()
            {
                Name = "FirstTest",
                TimeStampe = 10.0d,
            };
            Test xTest2 = new Test()
            {
                Name = "FirstTest",
                TimeStampe = 10.0d,
            };
            Test xTest3 = new Test()
            {
                Name = "FirstTest",
                TimeStampe = 10.0d,
            };
            Test xTest4 = new Test()
            {
                Name = "FirstTest",
                TimeStampe = 10.0d,
            };
            lxTest.Add(xTest);
            lxTest.Add(xTest2);
            lxTest.Add(xTest3);
            lxTest.Add(xTest4);
            return lxTest;
        }
        private List<User> AddUser()
        {
            List<User> lxAdmin = new List<User>();

            User xAdmin = new User()
            {
                FirstName = "Jan",
                UserName = "JanBen01",
                Password = "ASd",
                Email = "Asd",
                LastName = "Benson",
                OccupationFk = 2,
                StudentClassFk = 1,
            };

            User xAdmin2 = new User()
            {
                FirstName = "Glenn",
                UserName = "GlenBen01",
                Password = "ASd",
                Email = "Asd",
                LastName = "Obro",
                OccupationFk = 2,
                StudentClassFk = 1,
            };

            User xTeacher = new User()
            {
                FirstName = "Tjöta",
                UserName = "TJöBen01",
                Password = "wadww",
                Email = "Asd",
                LastName = "Årersson",
                OccupationFk = 1,
                StudentClassFk = 3,
                
            };

            User xTeacher2 = new User()
            {
                FirstName = "HullaBallo",
                UserName = "GlenBen01",
                Password = "ASd",
                Email = "Asd",
                LastName = "Huvudvärk",
                OccupationFk = 1,
                StudentClassFk = 2,
            };
            lxAdmin.Add(xTeacher2);
            lxAdmin.Add(xTeacher);
            lxAdmin.Add(xAdmin2);
            lxAdmin.Add(xAdmin);


            return lxAdmin;
        }
        private List<Student> AddStudent()
        {
            List<Student> lxStudent = new List<Student>();
            Student xStudent = new Student()
            {
                FirstName = "Döniken",
                UserName = "TJöBen01",
                Password = "wadww",
                Email = "Asd",
                LastName = "Åkersson",
                OccupationFk = 3,
                StudentClassFk = 3,
               
            };

            Student xStudent2 = new Student()
            {
                FirstName = "Huhuran",
                UserName = "GlenBen01",
                Password = "ASd",
                Email = "Asd",
                LastName = "DanskSkappe",
                OccupationFk = 3,
                StudentClassFk = 3,
            };
            Student xStudent3 = new Student()
            {
                FirstName = "Blaj",
                UserName = "asd",
                Password = "wadww",
                Email = "Asd",
                LastName = "Åkersson",
                OccupationFk = 3,
                StudentClassFk = 3,
            };

            Student xStudent4 = new Student()
            {
                FirstName = "HullaBallo",
                UserName = "das",
                Password = "ASd",
                Email = "Asd",
                LastName = "Långben",
                OccupationFk = 3,
                StudentClassFk = 3,
            };
            Student xStudent5 = new Student()
            {
                FirstName = "Linus",
                UserName = "zdxc",
                Password = "wadww",
                Email = "Asd",
                LastName = "Linjen",
                OccupationFk = 3,
                StudentClassFk = 2,
            };

            Student xStudent6 = new Student()
            {
                FirstName = "BaloVo",
                UserName = "ds",
                Password = "ASd",
                Email = "Asd",
                LastName = "Volsunk",
                OccupationFk = 3,
                StudentClassFk = 2,
            };
            lxStudent.Add(xStudent);
            lxStudent.Add(xStudent2);
            lxStudent.Add(xStudent3);
            lxStudent.Add(xStudent4);
            lxStudent.Add(xStudent5);
            lxStudent.Add(xStudent6);

            return lxStudent;
        }

    }
}
