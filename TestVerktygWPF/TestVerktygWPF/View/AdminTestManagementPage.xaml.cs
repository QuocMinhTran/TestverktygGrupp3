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
using TestVerktygWPF.ViewModel;

namespace TestVerktygWPF.View
{
    /// <summary>
    /// Interaction logic for AdminTestManagementPage.xaml
    /// </summary>
    public partial class AdminTestManagementPage : Page
    {
        //IList<Test> Tests = new List<Test>();
        Test selectedTest = new Test();
        User theAdmin;
        public AdminTestManagementPage(User user)
        {
            theAdmin = user;
            InitializeComponent();
            Updatelist();
        }

        private void _ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            splSelectedTest.Children.Clear();
            selectedTest = _ListView.SelectedItem as Test;
            if (selectedTest != null)
            {
                using (var db = new DbModel())
                {
                    //var query = from t in db.Tests
                    //            join q in db.Questions on t.ID equals q.TestFk
                    //            join a in db.Answers on q.ID equals a.QuestionFk
                    //            where t.ID == test.ID
                    //            select new { QuestionText = q.Name, QuestionType = q.QuestionType, Answer = a.Text };
                    foreach (var item in db.Questions.ToList())
                    {
                        int i = 0;
                        if (item.TestFk == selectedTest.ID)
                        {
                            i++;
                            TextBlock txtBlock = new TextBlock();
                            txtBlock.Text = "Fråga " + i;
                            splSelectedTest.Children.Add(txtBlock);
                            TextBlock txt = new TextBlock();
                            txt.Text = item.Name;
                            if (!String.IsNullOrEmpty(item.AppData))
                            {
                                Image imgQuestion = new Image();
                                string imgPath = item.AppData;
                                Uri imgUri = new Uri(imgPath);
                                BitmapImage imgBitMap = new BitmapImage(imgUri);
                                imgQuestion.Source = imgBitMap;
                                imgQuestion.MaxHeight = 200;
                                imgQuestion.MaxWidth = 200;
                                splSelectedTest.Children.Add(imgQuestion);
                            }
                            splSelectedTest.Children.Add(txt);

                            foreach (var a in db.Answers.ToList())
                            {
                                if (a.QuestionFk == item.ID)
                                {

                                    switch (item.QuestionType)
                                    {
                                        case "envalsfråga":
                                            RadioButton ans = new RadioButton();
                                            ans.Content = a.Text;
                                            splSelectedTest.Children.Add(ans);
                                            break;
                                        case "Flervalsfråga":
                                            CheckBox ans2 = new CheckBox();
                                            ans2.Content = a.Text;
                                            splSelectedTest.Children.Add(ans2);
                                            break;
                                        case "rangordning":
                                            TextBlock ans3 = new TextBlock();
                                            ans3.Text = a.Text;
                                            splSelectedTest.Children.Add(ans3);
                                            break;
                                        default:
                                            break;
                                    }

                                }
                            }

                        }
                    }

                    Button sendbtn = new Button();
                    Button sendBackbtn = new Button();
                    StackPanel splSendTestControl = new StackPanel();
                    splSendTestControl.Orientation = Orientation.Horizontal;
                    sendbtn.Content = "Skicka till studenter";
                    sendBackbtn.Content = "Skicka till lärare";
                    splSendTestControl.Children.Add(sendbtn);
                    splSendTestControl.Children.Add(sendBackbtn);
                    splSelectedTest.Children.Add(splSendTestControl);
                    sendbtn.Click += Sendbtn_Click;
                    sendBackbtn.Click += SendBackbtn_Click;
                }
            }
        }
        private void SendBackbtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DbModel())
            {
                var xUserTest = from xu in db.UserTests
                                join u in db.Users on xu.UserFk equals u.ID
                                where u.OccupationFk == 2
                                select xu;
                foreach (var item in xUserTest.ToList())
                {
                    db.UserTests.Remove(item);
                }
                db.SaveChanges();
                Updatelist();
            }
        }

        private void Updatelist()
        {
            using (var db = new DbModel())
            {
                var query = from t in db.Tests
                            join ut in db.UserTests on t.ID equals ut.TestFk
                            join u in db.Users on ut.UserFk equals u.ID
                            //join sc in db.StudentClasses on u.StudentClassFk equals sc.ID
                            //join scc in db.StudentClassCourses on sc.ID equals scc.StudentClassRefID
                            //join c in db.Courses on scc.CouseRefID equals c.ID
                            where u.ID == theAdmin.ID

                            select t;
                List<Test> listTest = new List<Test>();
                foreach (var item in query.ToList())
                {
                    listTest.Add(item);
                }
                _ListView.ItemsSource = listTest;
                _ListView.DisplayMemberPath = "Name";

            }
        }

        private void Sendbtn_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new DbModel())
            {
                var xtests = from ut in db.UserTests
                             where ut.TestFk == selectedTest.ID
                             select ut;

                foreach (var item in xtests.ToList())
                {
                    db.UserTests.Remove(item);
                }
                var stutests = from st in db.StudentTests
                               where st.TestRefFk == selectedTest.ID
                               select st;
                foreach (var item in stutests.ToList())
                {
                    item.IsChecked = true;
                }
                db.SaveChanges();
            }
            Updatelist();
        }
    }
}
