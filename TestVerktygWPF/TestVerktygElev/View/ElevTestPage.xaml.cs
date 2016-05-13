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
        private int m_iTime, m_iAmountOfQuestions;
        private int m_iTempID;
        private int m_iStudentTestID;
        private Student m_xStudent;
        //private int m_iScore = 0;

        public ElevTestPage(int p_IDTest, int p_iStudentTestID, Student p_xStudent)
        {
            InitializeComponent();
            m_iStudentTestID = p_iStudentTestID;
            m_xStudent = p_xStudent;
            m_liIndexes = new List<int>();
            m_xRepository = new Repository();
            m_lxStudentAnswer = new List<StudentAnswer>();
            m_xTest = m_xRepository.GetTest(p_IDTest);
            m_iTime = (int)m_xTest.TimeStampe;
            txtBlockTestName.Text = m_xTest.Name;
            m_lxQuestions = m_xRepository.GetQuestions(p_IDTest);
            m_iAmountOfQuestions = m_lxQuestions.Count;
            m_lxAnswer = m_xRepository.GetAllAnswers(m_xTest);
            StartTimer();
            SpawnQuestion();

        }
        private void SpawnQuestion()
        {
            List<int> liAnswers = new List<int>();
            List<Answer> lxAnswer;
            txtBlockQuestions.Text = m_lxQuestions[m_iIndex].Name;
            m_iTempID = m_lxQuestions[m_iIndex].ID;
            lxAnswer = m_xRepository.GetAnwsers(m_iTempID);
            int iCount = m_iIndex + 1;
            txtBlockQuestionNumber.Text = iCount.ToString() + "/" + m_iAmountOfQuestions.ToString();
            if (imageImage.Source != null)
            {
                imageImage.Source = null;

            }
            if (!string.IsNullOrEmpty(m_lxQuestions[m_iIndex].AppData))
            {
                ImageSourceConverter xImageSourceConverter = new ImageSourceConverter();
                imageImage.MaxHeight = 200;
                imageImage.MaxWidth = 200;
                imageImage.Source = (ImageSource)xImageSourceConverter.ConvertFromString(m_lxQuestions[m_iIndex].AppData);

                Console.WriteLine("THERE SHOULD BE A FINE PICUTEREAS");
            }
            foreach (var item in lxAnswer)
            {
                m_liIndexes.Add(item.ID);
            }
            for (int i = 0; i < lxAnswer.Count; i++)
            {
                Thickness xThickness = new Thickness();
                xThickness.Top = 10;
                TextBlock xTextBlock = new TextBlock();
                xTextBlock.Text = lxAnswer[i].Text;
                xTextBlock.Margin = xThickness;
                lbAnswer.Items.Add(xTextBlock);

                switch (m_lxQuestions[m_iIndex].QuestionType)
                {
                    case "envalsfråga":
                        RadioButton xRadio = new RadioButton();
                        foreach (var item in m_lxStudentAnswer)
                        {
                            if (item.Answer == lxAnswer[i].ID)
                            {
                                xRadio.IsChecked = true;
                            }
                        }
                        lbAnswer.Items.Add(xRadio);
                        break;
                    case "Flervalsfråga":
                        CheckBox xCheck = new CheckBox();
                        foreach (var item in m_lxStudentAnswer)
                        {
                            if (item.Answer == lxAnswer[i].ID)
                            {
                                xCheck.IsChecked = true;
                            }
                        }
                        lbAnswer.Items.Add(xCheck);
                        break;
                    case "rangordning":
                        ComboBox xCombo = new ComboBox();
                        for (int j = 0; j < lxAnswer.Count; j++)
                        {
                            xCombo.Items.Add(j + 1);
                        }
                        foreach (var item in m_lxStudentAnswer)
                        {
                            if (item.Answer == lxAnswer[i].ID)
                            {
                                xCombo.SelectedIndex = item.OrderPostition.Value;
                            }
                        }
                        lbAnswer.Items.Add(xCombo);
                        break;
                    default:
                        break;
                }
            }
        }
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
            if (lblTimer.Content.Equals(0))
            {
                CorrectTest();
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            m_iIndex--;
            if (m_iIndex == 0) btnPrevious.IsEnabled = false;
            int iTemp = 0;
            bool bRemoveQuestion = false;
            foreach (var item in lbAnswer.Items)
            {
                if (!bRemoveQuestion)
                {
                    bRemoveQuestion = RemoveQuestionAnswer();
                }
                RadioButton xRadio = item as RadioButton;
                if (xRadio != null)
                {
                    if (xRadio.IsChecked == true)
                    {
                        AddAnswer(iTemp, 0);
                    }
                    iTemp++;
                }
                CheckBox xCheck = item as CheckBox;
                if (xCheck != null)
                {
                    if (xCheck.IsChecked == true)
                    {
                        AddAnswer(iTemp, 0);
                    }
                    iTemp++;
                }
                ComboBox xComboBox = item as ComboBox;
                if (xComboBox != null)
                {
                    AddAnswer(iTemp, xComboBox.SelectedIndex);
                    iTemp++;
                }
            }
            lbAnswer.Items.Clear();
            m_liIndexes.Clear();
            SpawnQuestion();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int iTemp = 0;
            btnPrevious.IsEnabled = true;
            bool bRemoveQuestion = false;

            foreach (var item in lbAnswer.Items)
            {
                if (!bRemoveQuestion)
                {
                    bRemoveQuestion = RemoveQuestionAnswer();
                }
                RadioButton xRadio = item as RadioButton;
                if (xRadio != null)
                {
                    if (xRadio.IsChecked == true)
                    {
                        AddAnswer(iTemp, 0);
                    }
                    iTemp++;
                }
                CheckBox xCheck = item as CheckBox;
                if (xCheck != null)
                {
                    if (xCheck.IsChecked == true)
                    {
                        AddAnswer(iTemp, 0);
                    }
                    iTemp++;
                }
                ComboBox xComboBox = item as ComboBox;
                if (xComboBox != null)
                {
                    AddAnswer(iTemp, xComboBox.SelectedIndex);
                    iTemp++;
                }
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
        private bool RemoveQuestionAnswer()
        {
            List<StudentAnswer> lxStudentAnswers = m_lxStudentAnswer;
            List<StudentAnswer> Removable = new List<StudentAnswer>();
            if (lxStudentAnswers.Count != 0)
            {
                foreach (var item in lxStudentAnswers)
                {
                    if (item.Question == m_iTempID)
                    {
                        Removable.Add(item);
                    }
                }
                foreach (var item in Removable)
                {
                    m_lxStudentAnswer.Remove(item);
                }
            }
            return true;
        }

        private void AddAnswer(int p_iIndex, int p_iOrderPos)
        {
            StudentAnswer xStudentAnswer = new StudentAnswer();
            xStudentAnswer.StudentTestFk = m_iStudentTestID;
            xStudentAnswer.Answer = m_liIndexes[p_iIndex];
            xStudentAnswer.OrderPostition = p_iOrderPos + 1;
            xStudentAnswer.Question = m_iTempID;
            m_lxStudentAnswer.Add(xStudentAnswer);
        }
        private void CorrectTest()
        {
            if (NavigationService != null)
            {
                int iSeIfRight = 0;
                int iScore = 0;
                int iForScore = 0;
                for (int i = 0; i < m_lxQuestions.Count; i++)
                {
                    for (int j = 0; j < m_lxAnswer.Count; j++)
                    {
                        foreach (var item in m_lxStudentAnswer)
                        {
                            if (item.Answer == m_lxAnswer[j].ID && item.Question == m_lxQuestions[i].ID)
                            {
                                if (m_lxAnswer[j].RightAnswer && m_lxQuestions[i].QuestionType == "envalsfråga") iScore++;
                                if (m_lxAnswer[j].RightAnswer && m_lxQuestions[i].QuestionType == "Flervalsfråga")
                                {
                                    Console.WriteLine("Rätt SVAR PÅ FRÅGAN");
                                    iForScore++;
                                    iSeIfRight++;
                                }
                                if (!m_lxAnswer[j].RightAnswer && m_lxQuestions[i].QuestionType == "Flervalsfråga")
                                {
                                    Console.WriteLine("FEL SVAR PÅ FRÅGAN");
                                    iForScore++;
                                   // iSeIfRight--;
                                }
                                Console.WriteLine(m_lxAnswer[j].OrderPosition + " Mera " + item.OrderPostition);
                                if (m_lxAnswer[j].OrderPosition == (int)item.OrderPostition && m_lxQuestions[i].QuestionType == "rangordning")
                                {
                                    Console.WriteLine("HALLJSAN");
                                    iForScore++;
                                    iSeIfRight++;
                                }
                                else if (m_lxAnswer[j].OrderPosition != (int)item.OrderPostition && m_lxQuestions[i].QuestionType == "rangordning")
                                {
                                    Console.WriteLine("NEJSAN");

                                    iForScore++;
                                   // iSeIfRight--;
                                }
                            }
                        }
                    }
                    Console.WriteLine("IForScore : " + iForScore + " Rätt svar " + iSeIfRight);
                    if (iForScore == iSeIfRight && iForScore != 0)
                    {
                        iScore++;
                    }
                    iSeIfRight = 0;
                    iForScore = 0;
                }
                //TODO SAVE TO DATABASE
                int iTime = (int)m_xTest.TimeStampe - m_iTime - 1;
                m_xRepository.SaveTest(m_lxStudentAnswer, m_iAmountOfQuestions, iTime);
                StatisticPage xStatisticPage = new StatisticPage(m_xTest, iScore, m_xStudent, m_iTime, m_iAmountOfQuestions);
                NavigationService.Navigate(xStatisticPage);
            }

        }
    }
}
