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
using TestVerktygWPF.ViewModel;

namespace TestVerktygWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repo = new Repository();
        public List<User> LsUsers;

        public User SelectedUser = new User();
        public MainWindow()
        {
            InitializeComponent();

            //ViewModel.Repository x = new ViewModel.Repository();
            //Student xStudent = new Student();
            //xStudent.ID = 1;
            //CurrentSelectedTest xCst = new CurrentSelectedTest();
            //xCst.SetCurrentStudent(1);
            //Console.WriteLine(xCst.StudentScore);
            //Test xTest = new Test();
            //xTest.ID = 1;
            //int iX = x.GetTestInfoScore(xStudent, xTest);
            //Console.WriteLine(iX +"SCORE" );
            //foreach (var item in xStudent)
            //{
            //    Console.WriteLine(item.FirstName);
            //}
            AddDataToBase();
            AdminTabs.Visibility = Visibility.Collapsed; // must change to collapsed later
            TeacherTabs.Visibility = Visibility.Collapsed;
            LogoutTabs.Visibility = Visibility.Collapsed;
            //LoginPage.Visibility = Visibility.Collapsed;
            GetAllUsers();

        }

        private void GetAllUsers()
        {
            Repository repo = new Repository();
            LsUsers = repo.GetAllUsers();
        }
        bool matched = false;
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //TODO: send UserName and Password to database and login if there is a match
            foreach (var item in LsUsers)
            {
                if (txtBoxUserNameInput.Text == item.UserName && txtBoxPasswordInput.Password == item.Password)
                {
                    LoginPage.Visibility = Visibility.Collapsed;
                    LogoutTabs.Visibility = Visibility.Visible;
                    SelectedUser = item;
                    if (item.OccupationFk == 2)
                    {
                        AdminTabs.Visibility = Visibility.Visible;
                        _Frame.Navigate(new MainPageAdmin(SelectedUser));
                    }
                    else if (item.OccupationFk == 1)
                    {
                        TeacherTabs.Visibility = Visibility.Visible;
                        _Frame.Navigate(new MainPageTeacher(SelectedUser));
                    }
                    matched = true;
                    break;
                }
            }
            if (!matched)
            { 
                MessageBox.Show("Wrong information");
            }

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                btnLogin_Click(sender, e);
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem btn = sender as MenuItem;
            switch (btn.Header.ToString())
            {
                case "Startsida Admin":
                    _Frame.Navigate(new MainPageAdmin(SelectedUser));
                    break;
                case "Skapa Användare":
                    _Frame.Navigate(new AdminCreateUserPage(SelectedUser));
                    break;
                case "Hantera Användare":
                    _Frame.Navigate(new AdminUserManagementPage(SelectedUser));
                    break;
                case "Statistik":
                    _Frame.Navigate(new StatistikMasterPage(SelectedUser));
                    break;
                case "Skicka ut prov":
                    _Frame.Navigate(new TeacherTestManagementPage(SelectedUser));
                    break;
                case "Rätt prov":
                    _Frame.Navigate(new TeacherEvaluatePage(SelectedUser));
                    break;
                case "Start Lärare":
                    _Frame.Navigate(new MainPageTeacher(SelectedUser));
                    break;
                case "Hantera Prov":
                    _Frame.Navigate(new AdminTestManagementPage(SelectedUser));
                    break;
                case "Skapa Prov":
                    _Frame.Navigate(new TeacherCreateTestPage(SelectedUser));
                    break;
                case "Godkänna Prov":
                    _Frame.Navigate(new AdminTestDetailManagement(SelectedUser));
                    break;
            }
        }
        private void AddDataToBase()
        {
            List<Answer> lxAnswer = AddAnswer();            //Done
            List<Course> lxCourse = AddCourse();            //Done
            List<Occupation> lxOcc = AddOccupation();       //Done
            List<Questions> lxQuestions = AddQuestion();    //Done

            List<Student> lxStudent = AddStudent();                   //Done
            List<StudentAnswer> lxStudentAnswer = AddStudentAwnser(); //Done
            List<StudentClassCourse> lxSGC = AddStudentClassCourse(); //Done
            List<StudentClass> lxSC = AddStudentClass();              //Done
            List<StudentTest> lxStudentTest = AddStudentTest();       //Done

            List<Test> lxTest = AddTest();                  //Done
            List<User> lxUser = AddUser();                  //Done
            List<UserTest> lxUserTest = AddUserTest();      //Done
            #region UsingDB
            using (var db = new DbModel())
            {
                //foreach (var item in lxOcc)
                //{
                //    db.Occupations.Add(item);
                //}
                //foreach (var item in lxCourse)
                //{
                //    db.Courses.Add(item);
                //}
                //foreach (var item in lxSC)
                //{
                //    db.StudentClasses.Add(item);
                //}
                //foreach (var item in lxSGC)
                //{
                //    db.StudentClassCourses.Add(item);
                //}
                //foreach (var item in lxStudent)
                //{
                //    db.Students.Add(item);
                //}

                //foreach (var item in lxUser)
                //{
                //    db.Users.Add(item);
                //}
                ////foreach (var item in lxTest)
                ////{
                ////    db.Tests.Add(item);
                ////}

                //foreach (var item in lxUserTest)
                //{
                //    db.UserTests.Add(item);
                //}

                //foreach (var item in lxQuestions)
                //{
                //    db.Questions.Add(item);
                //}

                //foreach (var item in lxAnswer)
                //{
                //    db.Answers.Add(item);
                //}
                //foreach (var item in lxStudentTest)
                //{
                //    db.StudentTests.Add(item);
                //}
                //foreach (var item in lxStudentAnswer)
                //{
                //    Console.WriteLine(item.Answer);
                //    db.StudentAnswers.Add(item);
                //}
                db.SaveChanges();
            }
            #endregion

        }

        private List<UserTest> AddUserTest()
        {
            List<UserTest> lxUserTest = new List<UserTest>();

            UserTest xUserTets = new UserTest()
            {
                UserFk = 13,
                TestFk = 1,
            };
            UserTest xUserTets1 = new UserTest()
            {
                UserFk = 1,
                TestFk = 1,
            };
            UserTest xUserTets2 = new UserTest()
            {
                UserFk = 13,
                TestFk = 2,
            };
            UserTest xUserTets3 = new UserTest()
            {
                UserFk = 17,
                TestFk = 1,
            };

            lxUserTest.Add(xUserTets);
            lxUserTest.Add(xUserTets1);
            lxUserTest.Add(xUserTets2);
            lxUserTest.Add(xUserTets3);

            return lxUserTest;
        }
        private List<StudentTest> AddStudentTest()
        {
            List<StudentTest> lxStudentTest = new List<StudentTest>();
            StudentTest xStudentTest = new StudentTest()
            {
                StudentRefFk = 1,
                TestRefFk = 1,
                WritenTime = 10,
                IsTestDone = true,
                Score = 2,
                ID = 1,
            };
            StudentTest xStudentTest2 = new StudentTest()
            {
                StudentRefFk = 2,
                TestRefFk = 1,
                WritenTime = 0,
                IsTestDone = false,
                Score = 0,
                ID = 2,
            };
            StudentTest xStudentTest3 = new StudentTest()
            {
                StudentRefFk = 3,
                TestRefFk = 1,
                WritenTime = 0,
                IsTestDone = false,
                Score = 0,
                ID = 3,
            };
            StudentTest xStudentTest4 = new StudentTest()
            {
                StudentRefFk = 1,
                TestRefFk = 2,
                WritenTime = 0,
                IsTestDone = false,
                Score = 0,
                ID = 4,
            };

            StudentTest xStudentTest5 = new StudentTest()
            {
                StudentRefFk = 2,
                TestRefFk = 2,
                WritenTime = 0,
                IsTestDone = false,
                Score = 0,
                ID = 5,
            };
            lxStudentTest.Add(xStudentTest);
            lxStudentTest.Add(xStudentTest2);
            lxStudentTest.Add(xStudentTest3);
            lxStudentTest.Add(xStudentTest4);
            lxStudentTest.Add(xStudentTest5);
            return lxStudentTest;
        }
        private List<StudentClassCourse> AddStudentClassCourse()
        {
            List<StudentClassCourse> lxStudentClassCo = new List<StudentClassCourse>();
            StudentClassCourse xSCC = new StudentClassCourse()
            {
                CouseRefID = 1,
                StudentClassRefID = 2,
            };
            StudentClassCourse xSCC6 = new StudentClassCourse()
            {
                CouseRefID = 1,
                StudentClassRefID = 3,
            };


            StudentClassCourse xSCC2 = new StudentClassCourse()
            {
                CouseRefID = 2,
                StudentClassRefID = 2,
            };
            StudentClassCourse xSCC3 = new StudentClassCourse()
            {
                CouseRefID = 2,
                StudentClassRefID = 3,
            };


            StudentClassCourse xSCC4 = new StudentClassCourse()
            {
                CouseRefID = 3,
                StudentClassRefID = 2,
            };
            StudentClassCourse xSCC5 = new StudentClassCourse()
            {
                CouseRefID = 3,
                StudentClassRefID = 3,
            };
            lxStudentClassCo.Add(xSCC);
            lxStudentClassCo.Add(xSCC2);
            lxStudentClassCo.Add(xSCC3);
            lxStudentClassCo.Add(xSCC4);
            lxStudentClassCo.Add(xSCC5);
            lxStudentClassCo.Add(xSCC6);
            return lxStudentClassCo;

        }
        private List<StudentClass> AddStudentClass()
        {
            List<StudentClass> lxStudentClass = new List<StudentClass>();
            StudentClass xStudent = new StudentClass()
            {
                ID = 1,
                Name = "admin",
            };
            StudentClass xStudent2 = new StudentClass()
            {
                ID = 2,
                Name = "Programmerare"
            };
            StudentClass xStudent3 = new StudentClass()
            {
                ID = 3,
                Name = "Databas"
            };
            lxStudentClass.Add(xStudent);
            lxStudentClass.Add(xStudent2);
            lxStudentClass.Add(xStudent3);
            return lxStudentClass;
        }
        private List<StudentAnswer> AddStudentAwnser()
        {
            List<StudentAnswer> lxStudAnwer = new List<StudentAnswer>();
            StudentAnswer xStudA = new StudentAnswer()
            {
                StudentTestFk = 1,
                Question = 1,
                Answer = 1,
            };
            StudentAnswer xStudA2 = new StudentAnswer()
            {
                StudentTestFk = 1,
                Question = 2,
                Answer = 1,
            };
            StudentAnswer xStudA3 = new StudentAnswer()
            {
                StudentTestFk = 1,
                Question = 3,
                Answer = 1,
            };
            StudentAnswer xStudA4 = new StudentAnswer()
            {
                StudentTestFk = 1,
                Question = 3,
                Answer = 2,
            };
            lxStudAnwer.Add(xStudA);
            lxStudAnwer.Add(xStudA2);
            lxStudAnwer.Add(xStudA3);
            lxStudAnwer.Add(xStudA4);

            return lxStudAnwer;
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
            Answer xOptions1 = new Answer()
            {
                Text = "Djur",
                RightAnswer = true,
                QuestionFk = 1
            };
            Answer xOptions2 = new Answer()
            {

                Text = "Stolpe",
                RightAnswer = false,
                QuestionFk = 1
            };
            Answer xOptions3 = new Answer()
            {

                Text = "Röd",
                RightAnswer = false,
                QuestionFk = 2
            };
            Answer xOptions4 = new Answer()
            {

                Text = "Bil",
                RightAnswer = true,
                QuestionFk = 2
            };
            Answer xOptions5 = new Answer()
            {

                Text = "Bi",
                RightAnswer = false,
                QuestionFk = 2
            };
            Answer xOptions6 = new Answer()
            {

                Text = "8/4",
                RightAnswer = true,
                QuestionFk = 3
            };
            Answer xOptions7 = new Answer()
            {
                Text = "2*1",
                RightAnswer = true,
                QuestionFk = 3
            };
            Answer xOptions8 = new Answer()
            {
                Text = "9-5",
                RightAnswer = false,
                QuestionFk = 3
            };
            Answer xOptions9 = new Answer()
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
            Answer xOptions11 = new Answer()
            {
                Text = "6",
                RightAnswer = false,
                QuestionFk = 4
            };
            Answer xOptions12 = new Answer()
            {
                Text = "5*1+4",
                RightAnswer = true,
                QuestionFk = 5,
                OrderPosition = 1
            };
            Answer xOptions13 = new Answer()
            {
                Text = "4+2+5/5",
                RightAnswer = true,
                QuestionFk = 5,
                OrderPosition = 2
            };
            Answer xOptions14 = new Answer()
            {
                Text = "4+2+8*0",
                RightAnswer = true,
                QuestionFk = 5,
                OrderPosition = 3
            };
            Answer xOptions15 = new Answer()
            {
                Text = "Röd",
                RightAnswer = false,
                QuestionFk = 6
            };
            Answer xOptions16 = new Answer()
            {
                Text = "Blå",
                RightAnswer = true,
                QuestionFk = 6
            };
            Answer xOptions17 = new Answer()
            {
                Text = "Gul",
                RightAnswer = true,
                QuestionFk = 6
            };
            Answer xOptions18 = new Answer()
            {
                Text = "Blåval",
                RightAnswer = false,
                QuestionFk = 7,
                OrderPosition = 1
            };
            Answer xOptions19 = new Answer()
            {
                Text = "Elefant",
                RightAnswer = false,
                QuestionFk = 7,
                OrderPosition = 2
            };
            Answer xOptions20 = new Answer()
            {
                Text = "Bil",
                RightAnswer = false,
                QuestionFk = 7,
                OrderPosition = 3
            };
            Answer xOptions21 = new Answer()
            {
                Text = "Människa",
                RightAnswer = false,
                QuestionFk = 7,
                OrderPosition = 4
            };

            lxAnswer.Add(xOptions);
            lxAnswer.Add(xOptions2);
            lxAnswer.Add(xOptions3);
            lxAnswer.Add(xOptions4);
            lxAnswer.Add(xOptions5);
            lxAnswer.Add(xOptions6);
            lxAnswer.Add(xOptions7);
            lxAnswer.Add(xOptions8);
            lxAnswer.Add(xOptions9);
            lxAnswer.Add(xOptions10);
            lxAnswer.Add(xOptions11);
            lxAnswer.Add(xOptions12);
            lxAnswer.Add(xOptions13);
            lxAnswer.Add(xOptions14);
            lxAnswer.Add(xOptions15);
            lxAnswer.Add(xOptions16);
            lxAnswer.Add(xOptions17);
            lxAnswer.Add(xOptions18);
            lxAnswer.Add(xOptions19);
            lxAnswer.Add(xOptions20);
            lxAnswer.Add(xOptions21);
            return lxAnswer;
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
        private List<Course> AddCourse()
        {
            List<Course> lxCourse = new List<Course>();
            Course xCourse = new Course()
            {
                CourseName = "Programmering"
            };
            Course xCourse2 = new Course()
            {
                CourseName = "Matte"
            };
            Course xCourse3 = new Course()
            {
                CourseName = "Databas"
            };
            lxCourse.Add(xCourse);
            lxCourse.Add(xCourse2);
            lxCourse.Add(xCourse3);
            return lxCourse;
        }
        private List<Occupation> AddOccupation()
        {
            List<Occupation> lxOccupation = new List<Occupation>();
            Occupation xOccup = new Occupation()
            {
                ID = 1,
                Occupations = "lärare",
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
        private List<Test> AddTest()
        {
            List<Test> lxTest = new List<Test>();
            Test xTest = new Test()
            {
                ID = 1,
                Name = "FirstTest",
                TimeStampe = 10.0d,
                IsAutoCorrect = true
            };
            Test xTest2 = new Test()
            {
                ID = 2,
                Name = "FirstTest",
                TimeStampe = 10.0d,
                IsAutoCorrect = true
            };
            Test xTest3 = new Test()
            {
                ID = 3,
                Name = "FirstTest",
                TimeStampe = 10.0d,
                IsAutoCorrect = true
            };
            Test xTest4 = new Test()
            {
                ID = 4,
                Name = "FirstTest",
                TimeStampe = 10.0d,
                IsAutoCorrect = true
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
                ID = 1,
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
                ID = 2,
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

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            _Frame.Visibility = Visibility.Collapsed;
            AdminTabs.Visibility = Visibility.Collapsed; 
            TeacherTabs.Visibility = Visibility.Collapsed;
            LogoutTabs.Visibility = Visibility.Collapsed;
            LoginPage.Visibility = Visibility.Visible;
            SelectedUser = null;
            txtBoxPasswordInput.Password = "";
        }
    }
}
