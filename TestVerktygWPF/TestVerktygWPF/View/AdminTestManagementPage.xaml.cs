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
        public AdminTestManagementPage()
        {
            InitializeComponent();
            using (var db = new DbModel())
            {
                var query = from t in db.Tests
                            join ut in db.UserTests on t.ID equals ut.TestFk
                            join u in db.Users on ut.UserFk equals u.ID
                            join sc in db.StudentClasses on u.StudentClassFk equals sc.ID
                            join scc in db.StudentClassCourses on sc.ID equals scc.StudentClassRefID
                            join c in db.Courses on scc.CouseRefID equals c.ID
                            where t.EndDate >= DateTime.Now && u.OccupationFk == 1
                            select new { Provnamn = t.Name, Lärare = u.FirstName, Kurs = c.CourseName, StartDatum = t.StartDate, SlutDatum = t.EndDate, Tid = t.TimeStampe };
                _DataGrid.ItemsSource = query.ToList();

            }


        }

        private void _DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Test test = sender as Test;
            StackPanel stkPanel = new StackPanel();
            using (var db = new DbModel())
            {
                var query = from t in db.Tests
                            join q in db.Questions on t.ID equals q.TestFk
                            join a in db.Answers on q.ID equals a.QuestionFk
                            where t.ID == test.ID
                            select new { QuestionText = q.Name, QuestionType = q.QuestionType, Answer = a.Text };
                pup.Child = stkPanel;
                foreach (var item in db.Questions.ToList())
                {
                    if (item.TestFk == test.ID)
                    {
                        TextBlock txt = new TextBlock();
                        txt.Text = item.Name;
                        stkPanel.Children.Add(txt);
                        foreach (var a in db.Answers.ToList())
                        {
                            if (a.QuestionFk == item.ID)
                            {
                                switch (item.QuestionType)
                                {
                                    case "envalfråga":
                                        RadioButton ans = new RadioButton();
                                        ans.Content = a.Text;
                                        break;
                                    case "flervalfråga":
                                        CheckBox ans2 = new CheckBox();
                                        ans2.Content = a.Text;
                                        break;
                                    case "rangordningfråga":
                                        TextBlock ans3 = new TextBlock();
                                        ans3.Text = a.Text;
                                        break;
                                    default:
                                        break;
                                }
                                
                            }
                        }

                    }
                }
            }
        }
    }
}
