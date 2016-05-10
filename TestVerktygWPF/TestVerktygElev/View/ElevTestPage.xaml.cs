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
        private List<Answer> m_lxAnswer;
        private List<StudentAnswer> m_lxStudentAnswer;
        private List<int> m_liIndexes;
        private int m_iIndex = 0;
        private int m_iTime;
         private int m_iTempID;

        public ElevTestPage(int p_IDTest)
        {

            InitializeComponent();
            m_liIndexes = new List<int>();
            m_xRepository = new Repository();
            m_lxStudentAnswer = new List<StudentAnswer>();
            m_xTest = m_xRepository.GetTest(p_IDTest);
            m_iTime = (int)m_xTest.TimeStampe;
            txtBlockTestName.Text = m_xTest.Name;
            m_lxQuestions = m_xRepository.GetQuestions(p_IDTest);
            m_lxAnswer = m_xRepository.GetAllAnswers(m_xTest);
            //foreach (var item in m_lxAnswer)
            //{
            //    Console.WriteLine("Answer In the Questions" + item.Text);
            //}
            StartTimer();
            SpawnQuestion();

        }
        private void SpawnQuestion()
        {
            List<Answer> lxAnswer;
            
            tbQuestion.Text = m_lxQuestions[m_iIndex].Name;
            m_iTempID = m_lxQuestions[m_iIndex].ID;
            lxAnswer = m_xRepository.GetAnwsers(m_iTempID);
            foreach (var item in lxAnswer)
            {
                m_liIndexes.Add(item.ID);
              //  Console.WriteLine("IdexOfXasner" + item.ID);
            }
            for (int i = 0; i < lxAnswer.Count; i++)
            {
                TextBlock xTextBlock = new TextBlock();
                Thickness xThickness = new Thickness();
                xThickness.Top = 10;
                xTextBlock.Text = lxAnswer[i].Text;
                xTextBlock.Margin = xThickness;
                lbAnswer.Items.Add(xTextBlock);
                switch (m_lxQuestions[m_iIndex].QuestionType)
                {
                    case "envalsfråga":
                        RadioButton xRadio = new RadioButton();
                        lbAnswer.Items.Add(xRadio);
                        break;
                    case "Flervalsfråga":
                        CheckBox xCheck = new CheckBox();
                        lbAnswer.Items.Add(xCheck);
                        break;
                    case "rangordning":
                        ComboBox xCombo = new ComboBox();
                        lbAnswer.Items.Add(xCombo);
                        break;
                    default:
                        break;
                }


            }
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
            //if (lblTimer.Content.Equals(0))
            //{
            //    CorrectTest();
            //}
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
            int iTemp = 0;
            foreach (var item in lbAnswer.Items)
            {
                RadioButton xRadio = item as RadioButton;
                if (xRadio != null)
                {
                    if (xRadio.IsChecked == true)
                    {
                        StudentAnswer xStudentAnswer = new StudentAnswer();
                        xStudentAnswer.Answer = m_liIndexes[iTemp];
                        xStudentAnswer.Question = m_iTempID;

                        m_lxStudentAnswer.Add(xStudentAnswer);
                    }
                    iTemp++;
                }
                CheckBox xCheck = item as CheckBox;
                if (xCheck != null)
                {
                    if (xCheck.IsChecked == true)
                    {
                        StudentAnswer xStudentAnswer = new StudentAnswer();
                        xStudentAnswer.Answer = m_liIndexes[iTemp];
                        xStudentAnswer.Question = m_iTempID;
                        m_lxStudentAnswer.Add(xStudentAnswer);
                    }
                    iTemp++;
                }
            }
            foreach (var item in m_lxStudentAnswer)
            {
                Console.WriteLine("Answers In student : " + item.Answer + " FRÅGA:" + item.Question);
            }
            m_iIndex++;
            lbAnswer.Items.Clear();
            m_liIndexes.Clear();
            if (m_iIndex < m_lxQuestions.Count)
            {
                SpawnQuestion();
            }
            else
                CorrectTest();

        }

        private void CorrectTest()
        {
            Console.WriteLine("finnish");
            for (int i = 0; i < m_lxQuestions.Count; i++)
            {
                for (int j = 0; j < m_lxAnswer.Count; j++)
                {
                    foreach (var item in m_lxStudentAnswer)
                    {
                        if (item.Answer == m_lxAnswer[j].ID && item.Question == m_lxQuestions[i].ID)
                        {

                            Console.WriteLine("Frågra: " + m_lxQuestions[i].ID + " " + m_lxQuestions[i].Name);
                            Console.WriteLine("Alternativ :" + m_lxAnswer[j].ID + " " + m_lxAnswer[j].Text + " Rätt svar :" + m_lxAnswer[j].RightAnswer);
                            Console.WriteLine(" Svar" +item.Answer + "RättSvar?" + m_lxAnswer[j].RightAnswer);
                            
                        }
                    }
                }                
            }
        }
    }
}
