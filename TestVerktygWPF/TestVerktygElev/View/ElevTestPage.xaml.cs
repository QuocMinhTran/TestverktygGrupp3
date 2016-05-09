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
            StartTimer();
        }

        private void StartTimer()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Hej");
            //TODO: update timer
        }

        private void ProcessQuestion()
        {
            foreach (var item in listCheckedAnswers)
            {
                item.Visibility = Visibility.Collapsed;
            }
            txtBlockQuestions.Text = (qIndex + 1).ToString() + "/" + questionList.Count.ToString();
            txtBlockQuestionName.Text = questionList[qIndex].Name;
            listCheckedAnswers[qIndex].Visibility = Visibility.Visible;

            //ProcessAnswers();
        }

        private void RenderQuestions()
        {
            for (int i = 0; i < questionList.Count; i++)
            {
                StackPanel answerControl = new StackPanel();
                answerControl.Visibility = Visibility.Collapsed;
                foreach (var item in questionList[i].Answers)
                {
                    TextBlock txtBlock = new TextBlock();

                    txtBlock.Text = item.Text;
                    answerControl.Children.Add(txtBlock);

                    switch (questionList[i].QuestionType)
                    {
                        case "envalsfråga":
                            RadioButton radioBtn = new RadioButton();
                            answerControl.Children.Add(radioBtn);
                            break;
                        case "flervalsfråga":
                            CheckBox chkBox = new CheckBox();
                            answerControl.Children.Add(chkBox);
                            break;
                        case "rangordning":
                            ComboBox cbBox = new ComboBox();
                            List<string> answerStringList = new List<string>();
                            Random rnd = new Random();
                            answerControl.Children.Add(cbBox);
                            //foreach (var item2 in questionList[i].Answers)
                            //{
                            //    answerArray[]
                            //}
                            foreach (var item2 in questionList[i].Answers)
                            {
                                answerStringList.Add(item2.Text);
                            }
                            int n = answerStringList.Count;
                            while (n > 1)
                            {
                                n--;
                                int k = rnd.Next(n + 1);
                                string value = answerStringList[k];
                                answerStringList[k] = answerStringList[n];
                                answerStringList[n] = value;
                            }
                            cbBox.ItemsSource = answerStringList;
                            break;
                        default:
                            break;
                    }

                }
                listCheckedAnswers.Add(answerControl);
                splAnswers.Children.Add(answerControl);
            }
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
                CorrectTest();
            }

            else
            {
                qIndex++;
                btnPrevious.IsEnabled = true;
                ProcessQuestion();
            }
        }

        private void CorrectTest()
        {
            
        }
    }
}
