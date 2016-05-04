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
using TestVerktygElev.ViewModel;

namespace TestVerktygElev
{
    /// <summary>
    /// Interaction logic for ElevTestPage.xaml
    /// </summary>
    public partial class ElevTestPage : Page
    {
        List<Question> questionList = new List<Question>();
        Question currentQuestion = new Question();
        List<StackPanel> listCheckedAnswers = new List<StackPanel>();
        Test test = new Test();
        int qIndex = 0;
        
        public ElevTestPage()
        {
            InitializeComponent();
            InitTest();
            //CreateDummyTest();
            //currentQuestion = questionList.FirstOrDefault();
            //UpdateQuestionsCounter();
            //txtBlockTestName.Text = test.Name;
            //StartTimer();
        }

        private void InitTest()
        {
            Repository repo = new Repository();
            test = repo.GetTest();
            txtBlockTestName.Text = test.Name;
            questionList = repo.GetQuestion();
            RenderQuestions();
            ProcessQuestion();
        }

        private void StartTimer()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            //TODO: update timer
        }

        private void ProcessQuestion()
        {
            foreach (var item in listCheckedAnswers)
            {
                item.Visibility = Visibility.Collapsed;
            }
            txtBlockQuestions.Text = (qIndex + 1).ToString() + "/" + questionList.Count.ToString();
            txtBlockQuestionName.Text = questionList[qIndex].QuestionsLabel;
            listCheckedAnswers[qIndex].Visibility = Visibility.Visible;
            //ProcessAnswers();
        }

        private void RenderQuestions()
        {
            for (int i = 0; i < questionList.Count; i++)
            {
                StackPanel answerControl = new StackPanel();
                foreach (var item in questionList[i].Options)
                {
                    TextBlock txtBlock = new TextBlock();
                    txtBlock.Text = item.SelectivOption;
                    CheckBox box = new CheckBox();
                    answerControl.Children.Add(txtBlock);
                    answerControl.Children.Add(box);
                    answerControl.Orientation = Orientation.Horizontal;
                    answerControl.Visibility = Visibility.Collapsed;
                }

                listCheckedAnswers.Add(answerControl);
                splAnswers.Children.Add(answerControl);
            }
            //foreach (var item in questionList[qIndex].Options)
            //{
            //    TextBlock txtBlock = new TextBlock();
            //    txtBlock.Text = item.SelectivOption;
            //    CheckBox box = new CheckBox();
            //    StackPanel answerControl = new StackPanel();
            //    answerControl.Children.Add(txtBlock);
            //    answerControl.Children.Add(box);
            //    answerControl.Orientation = Orientation.Horizontal;
            //    splAnswers.Children.Add(answerControl);
            //    listCheckedAnswers.Add(answerControl);
            //}
        }

        private void ProcessAnswers()
        {
            foreach (var item in questionList[qIndex].Options)
            {
                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = item.SelectivOption;
                CheckBox box = new CheckBox();
                StackPanel answerControl = new StackPanel();
                answerControl.Children.Add(txtBlock);
                answerControl.Children.Add(box);
                answerControl.Orientation = Orientation.Horizontal;
                splAnswers.Children.Add(answerControl);
                listCheckedAnswers.Add(answerControl);
            }
        }

        private void CreateDummyTest()
        {
            Teacher teacher = new Teacher();
            teacher.FirstName = "fuck";
            teacher.LasttName = "fuckerson";

            Student student = new Student();

            test.Name = "honk honk motherfucker";
            test.StartDate = DateTime.Today;
            test.EndDate = DateTime.Today.AddDays(1);
            test.TeacherRefFK = teacher.TeacherID;
            
            QuestionType type1 = new QuestionType();
            type1.Option = "Envalsfråga";

            QuestionType type2 = new QuestionType();
            type2.Option = "Flervalsfråga";

            Question question = new Question();
            question.QuestionsLabel = "What the fuck did you just fucking say about me, you little bitch?";
            question.QuestTypeRefFK = type1.QuestionTypeID;

            Option option = new Option();
            option.SelectivOption = "Gorilla Warfare";
            option.RightAnswer = true;

            Option option2 = new Option();
            option2.SelectivOption = "united nations space command";
            option2.RightAnswer = false;

            Question question2 = new Question();
            question2.QuestionsLabel = "what is shitposting";
            question2.QuestTypeRefFK = type2.QuestionTypeID;

            Option option3 = new Option();
            option3.SelectivOption = "The failure to make a constructive post ";
            option3.RightAnswer = true;

            Option option4 = new Option();
            option4.SelectivOption = "The inability to add useful information to a forum";
            option4.RightAnswer = true;

            Option option5 = new Option();
            option5.SelectivOption = "Worthless overly offensive posts written in a manner which aggravates others";
            option5.RightAnswer = true;

            Question q3 = new Question();
            q3.QuestionsLabel = "whats the difference between a shit and a turd";
            questionList.Add(q3);

            TestQuestion tstqst = new TestQuestion();
            tstqst.TestRefFk = test.TestID;
            tstqst.QuestionRefFk = question.QuestionID;
            TestQuestion tstqst2 = new TestQuestion();
            tstqst2.TestRefFk = test.TestID;
            tstqst2.QuestionRefFk = question2.QuestionID;

            List<Option> optionsList = new List<Option>();
            questionList.Add(question);
            questionList.Add(question2);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            qIndex--;
            ProcessQuestion();
            if (qIndex == 0)
                btnPrevious.IsEnabled = false;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (qIndex + 1 >= questionList.Count)
            {
                MessageBox.Show("wow you completed the test so good");
            }

            else
            {
                qIndex++;
                btnPrevious.IsEnabled = true;
                ProcessQuestion();
            }
        }
    }
}
