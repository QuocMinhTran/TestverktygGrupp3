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
using TestVerktygElev.ViewModel;

namespace TestVerktygElev
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        private Student m_xStudent;
        private Test m_xTest;
        public StatisticPage(Test p_xTest,int p_iScore,Student p_xStudent,int p_iTime, int p_iTotalPoint)
        {
            InitializeComponent();
            string sGrade;
            double dGrade = (double)p_iScore / (double)p_iTotalPoint ;
            int iTime = (int)p_xTest.TimeStampe - p_iTime;
            m_xStudent = p_xStudent;
            m_xTest = p_xTest;
            TextBlockTestName.Text = p_xTest.Name;
            if (dGrade >= 0.6)
            {
                if (dGrade >= 0.8) sGrade = "VG";
                else sGrade = "G";
            }
            else sGrade = "IG";
            if (iTime < 0) iTime = 0;
            TextBlockTime.Text = iTime.ToString();
            TextBlockGrade.Text = sGrade;

            TestFunctions(p_xStudent);
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainPage xMainPage = new MainPage(m_xStudent);
            ListViewCompletedTest.Items.Clear();
            NavigationService.Navigate(xMainPage);
        }
        private void TestFunctions(Student p_xStudent)
        {
            Repository xRepository = new Repository();
            Test xTest = xRepository.GetTest(m_xTest.ID);
            List<Question> lxQuestions = xRepository.GetQuestions(xTest.ID);
            List<Answer> lxAnswers = xRepository.GetAllAnswers(xTest);
            List<StudentAnswer> lxStudentAnswers = new List<StudentAnswer>();
            lxStudentAnswers = xRepository.GetStudentAnswers(p_xStudent.ID, xTest.ID);
         
            for (int i = 0; i < lxQuestions.Count; i++)
            {
                TextBlock xBlock = new TextBlock();
                xBlock.Text = lxQuestions[i].Name;
                ListViewCompletedTest.Items.Add(xBlock);
                for (int j = 0; j < lxAnswers.Count; j++)
                {
                    foreach (var item in lxStudentAnswers)
                    {
                        if (lxQuestions[i].ID == lxAnswers[j].QuestionFk)
                        {
                            if (item.Answer == lxAnswers[j].ID)
                            {
                                Console.WriteLine("asdasdjalksjdlkajsdklkd");
                                TextBlock xAnswer = new TextBlock();
                                xAnswer.Text = lxAnswers[j].Text;

                                if (lxAnswers[j].RightAnswer && lxQuestions[i].QuestionType != "rangordning")
                                {
                                    xAnswer.Background = Brushes.Green;
                                }
                                else if(!lxAnswers[j].RightAnswer && lxQuestions[i].QuestionType != "rangordning")
                                {
                                    xAnswer.Background = Brushes.Red;
                                }

                                if (lxAnswers[j].OrderPosition == item.OrderPostition && lxQuestions[i].QuestionType == "rangordning")
                                {
                                    xAnswer.Background = Brushes.Green;
                                }
                                else if (lxAnswers[j].OrderPosition != item.OrderPostition && lxQuestions[i].QuestionType == "rangordning")
                                {
                                    xAnswer.Background = Brushes.Red;
                                }
                                ListViewCompletedTest.Items.Add(xAnswer);
                            }
                        }
                    }
                }
            }

        }
    }
}
