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
using System.Windows.Threading;

namespace TestVerktygElev
{
    /// <summary>
    /// Interaction logic for ElevTestPage.xaml
    /// </summary>
    public partial class ElevTestPage : Page
    {
        private Test m_xTest;
        private List<Question> m_lxQuestions;
        private Repository m_xRepository;

        
        private int m_iTime;

        public ElevTestPage(int p_IDTest)
        {
            InitializeComponent();
            m_xRepository = new Repository();
            m_xTest = m_xRepository.GetTest(p_IDTest);
            m_iTime = (int)m_xTest.TimeStampe;
            txtBlockTestName.Text = m_xTest.Name;
            m_lxQuestions = m_xRepository.GetQuestions(p_IDTest);
            foreach (var item in m_lxQuestions)
            {
                Console.WriteLine("Questions In the Questions" + item.Name);
            }
            StartTimer();

        }

        //private void InitTest()
        //{

        //    //foreach (var item in test)
        //    //{
        //    //    Console.WriteLine(item.ID + item.Name);
        //    //}
        //    ProcessQuestion();

        //}

        private void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += OnTimedEvent;
            timer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            lblTimer.Content = m_iTime;
            m_iTime -= 1;
        }

        private void ProcessQuestion()
        {
            //splAnswers.Children.Clear();
            //Console.WriteLine(lxQuestionList[iIndex].Name);


            //foreach (var item in lxQuestionList[iIndex].Answers)
            //{
            //    Console.WriteLine(item.Text + " " + item.RightAnswer);
            //    Label xLable = new Label();
            //    xLable.Content = item.Text;
            //    splAnswers.Children.Add(xLable);
            //    switch (lxQuestionList[iIndex].QuestionType)
            //    {

            //        case "envalsfråga":
            //            RadioButton radioBtn = new RadioButton();
            //            splAnswers.Children.Add(radioBtn);
            //            break;
            //        case "flervalsfråga":
            //            CheckBox chkBox = new CheckBox();
            //            splAnswers.Children.Add(chkBox);
            //            break;
            //        case "rangordning":
            //            ComboBox cbBox = new ComboBox();
            //            splAnswers.Children.Add(cbBox);
            //            break;
            //    }

                //foreach (var item in listCheckedAnswers)
                //{
                //    item.Visibility = Visibility.Collapsed;
                //}
                //txtBlockQuestions.Text = (qIndex + 1).ToString() + "/" + questionList.Count.ToString();
                //txtBlockQuestionName.Text = questionList[qIndex].Name;
                //listCheckedAnswers[qIndex].Visibility = Visibility.Visible;

                //ProcessAnswers();
            //}
        }
        //private void AddAnswer()
        //{
            
        //}

        private void RenderQuestions()
        {
            //for (int i = 0; i < questionList.Count; i++)
            //{
            //    StackPanel answerControl = new StackPanel();
            //    answerControl.Visibility = Visibility.Collapsed;
            //    foreach (var item in questionList[i].Answers)
            //    {
            //        TextBlock txtBlock = new TextBlock();

            //        txtBlock.Text = item.Text;
            //        answerControl.Children.Add(txtBlock);

            //        switch (questionList[i].QuestionType)
            //        {
            //            case "envalsfråga":
            //                RadioButton radioBtn = new RadioButton();
            //                answerControl.Children.Add(radioBtn);
            //                break;
            //            case "flervalsfråga":
            //                CheckBox chkBox = new CheckBox();
            //                answerControl.Children.Add(chkBox);
            //                break;
            //            case "rangordning":
            //                ComboBox cbBox = new ComboBox();
            //                List<string> answerStringList = new List<string>();
            //                Random rnd = new Random();
            //                answerControl.Children.Add(cbBox);

            //                foreach (var item2 in questionList[i].Answers)
            //                {
            //                    answerStringList.Add(item2.Text);
            //                }
            //                int n = answerStringList.Count;
            //                while (n > 1)
            //                {
            //                    n--;
            //                    int k = rnd.Next(n + 1);
            //                    string value = answerStringList[k];
            //                    answerStringList[k] = answerStringList[n];
            //                    answerStringList[n] = value;
            //                }
            //                cbBox.ItemsSource = answerStringList;
            //                break;
            //            default:
            //                break;
            //        }

            //    }
            //    listCheckedAnswers.Add(answerControl);
            //    splAnswers.Children.Add(answerControl);
            //}
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            //iIndex--;
            //ProcessQuestion();
            //if (iIndex == 0)
            //    btnPrevious.IsEnabled = false;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            //StudentAnswer xStudentAnswer = new StudentAnswer();
            //if (iIndex + 1 >= lxQuestionList.Count)
            //{
            //    CorrectTest();
            //}

            //else
            //{
            //    iIndex++;
            //    btnPrevious.IsEnabled = true;
            //    foreach (var item in splAnswers.Children)
            //    {
            //        Label y = item as Label;
            //        if (y != null)
            //        {
            //            Console.WriteLine(" CONTENT = "+y.Content);
            //        }
            //        Console.WriteLine(item.GetType());
            //        RadioButton x = item as RadioButton;
            //        if (x != null)
            //        {
            //          Console.WriteLine("Is Checked =" + x.IsChecked);

            //            if (x.IsChecked == true)
            //            {
                            
            //            }
            //        }
            //        xStudentAnswer.Question = iIndex;
            //        lxStudAnwers.Add(xStudentAnswer);
            //    }

            //    ProcessQuestion();
            //}
        }

        private void CorrectTest()
        {
            //for (int i = 0; i < lxQuestionList.Count; i++)
            //{
            //    Console.WriteLine(lxQuestionList[i].Answers);
            //    RightAnswer(lxQuestionList[i].Answers, lxQuestionList[i].Name);

            //}
        }
        private void RightAnswer(ICollection<Answer> xAnswer, string sQuestion)
        {
            //foreach (var item in xAnswer)
            //{
            //    Console.WriteLine(sQuestion + " " + item.Question + " " + item.RightAnswer + " svar: "  /*lxStudAnwers[].Answer*/);

            //}
        }
    }
}
