using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestVerktygElev
{
    /// <summary>
    /// Interaction logic for ElevTestPage.xaml
    /// </summary>
    public partial class ElevTestPage : Page
    {
        List<Question> questionList = new List<Question>();
        Question currentQuestion = new Question();
        Test test = new Test();
        int qIndex = 1;
        public ElevTestPage()
        {
            InitializeComponent();
            CreateDummyTest();
            btnPrevious.IsEnabled = false;
            txtBlockTestName.Text = test.Name;
            txtBlockQuestions.Text = qIndex + "/" + questionList.Count.ToString();
            ProcessQuestion(qIndex);
        }

        private void ProcessQuestion(int index)
        {
            index--;
            currentQuestion = questionList[index];
            txtBlockQuestionName.Text = currentQuestion.QuestionsLabel;
        }

        private void CreateDummyTest()
        {
            test.Name = "la li lo le lu";
            test.StartDate = DateTime.Today;
            test.EndDate = DateTime.Today.AddDays(1);
            CreateTimer();
            
            Question q = new Question();
            q.QuestionsLabel = "honk hnk honkhnohknokhonkohknokhon";
            questionList.Add(q);

            Question q2 = new Question();
            q2.QuestionsLabel = "NOT THE BEES";
            questionList.Add(q2);

            Question q3 = new Question();
            q3.QuestionsLabel = "deranged hermit";
            questionList.Add(q3);

            Question q4 = new Question();
            q4.QuestionsLabel = "What the fuck did you just fucking say about me, you little bitch?";
            questionList.Add(q4);
        }

        private void CreateTimer()
        {
            Timer t = new Timer();
            //TimeSpan ts = test.EndDate - test.StartDate;
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            qIndex--;
            ProcessQuestion(qIndex);
            txtBlockQuestions.Text = qIndex + "/" + questionList.Count.ToString();
            if (qIndex <= 1)
                btnPrevious.IsEnabled = false;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (qIndex >= questionList.Count)
            {
                MessageBox.Show("test complete wow so good");
            }
            else
            {
                qIndex++;
                ProcessQuestion(qIndex);
                txtBlockQuestions.Text = qIndex + "/" + questionList.Count.ToString();
                btnPrevious.IsEnabled = true;
            }
        }
    }
}
