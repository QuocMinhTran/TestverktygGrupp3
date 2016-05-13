using Microsoft.Win32;
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
    /// Interaction logic for TeacherCreateTestPage.xaml
    /// </summary>
    public partial class TeacherCreateTestPage : Page
    {

        private List<Questions> m_lxQuestions;
        private List<Answer> m_lxAnswer;
        static int iID;
        User theTeacher;
        public TeacherCreateTestPage(User user)
        {
            theTeacher = user;
            iID = 0;
            InitializeComponent();
            m_lxQuestions = new List<Questions>();
            m_lxAnswer = new List<Answer>();
            SelectionBox.SelectedIndex = 0;
            for (int i = 0; i < 3; i++)
            {
                _StackPanel.Children.Add(CreateQuestion());
            }

        }
        private void NewStackPanel(List<Answer> lxAnswers)
        {
            int iIndex = 0;
            //for (int i = 0; i < lxAnswers.Count; i++)
            //{
            //    _StackPanel.Children.Add(CreateQuestion());
            //}
            foreach (var item in lxAnswers)
            {
                Answer ans = item as Answer;
                _StackPanel.Children.Add(CreateQuestion(ans.RightAnswer));
            }
            foreach (var item in _StackPanel.Children)
            {
                StackPanel temp = item as StackPanel;
                foreach (var item2 in temp.Children )
                {
                    TextBox x = item2 as TextBox;
                    if (x != null)
                    {
                        x.Text = lxAnswers[iIndex].Text;
                        iIndex++;
                    }
                }
            }
        }
        private void AddAlternatives(object sender, RoutedEventArgs e)
        {
            StackPanel xStackPanel = CreateQuestion();
            _StackPanel.Children.Add(xStackPanel);
        }

        private void RemoveAlternatives(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(_StackPanel.Children.Count);

            if (_StackPanel.Children.Count > 3)
            {
                _StackPanel.Children.RemoveAt(_StackPanel.Children.Count - 1);
            }
        }

        private void btnSaveQuestion_Click(object sender, RoutedEventArgs e)
        {
            txtBlockWarning.Text = "";
            bool oneOrMoreAlternativesEmpty = false;
            bool isThereACorrectAnswer = false;
            foreach (var item in _StackPanel.Children)
            {
                Console.WriteLine(item.ToString());
                StackPanel stackPanelAlternatives = item as StackPanel;
                foreach (var item2 in stackPanelAlternatives.Children)
                {
                    Console.WriteLine(item2.ToString());
                    if (item2.GetType() == typeof(TextBox))
                    {
                        Console.WriteLine("objektet är en textbox");
                        TextBox txtBoxAlternative = item2 as TextBox;

                        if (String.IsNullOrEmpty(txtBoxAlternative.Text) == true)
                        {
                            oneOrMoreAlternativesEmpty = true;
                            txtBoxAlternative.BorderBrush = Brushes.Red;
                            Console.WriteLine("alternativet måste ha text");
                            txtBlockWarning.Text = "Varje alternativ måste en text.\n";
                        }

                        else
                        {
                            txtBoxAlternative.ClearValue(TextBox.BorderBrushProperty);
                        }
                    }

                    else if (item2.GetType() == typeof(RadioButton))
                    {
                        RadioButton rbCorrectAlternative = item2 as RadioButton;
                        if (!isThereACorrectAnswer)
                            if (rbCorrectAlternative.IsChecked == true)
                                isThereACorrectAnswer = true;
                    }

                    else if (item2.GetType() == typeof(CheckBox))
                    {
                        CheckBox chkBoxCorrectAlternative = item2 as CheckBox;
                        if (!isThereACorrectAnswer)
                            if (chkBoxCorrectAlternative.IsChecked == true)
                                isThereACorrectAnswer = true;
                    }
                }
            }

            if (String.IsNullOrEmpty(txtBoxQuestion.Text) == false)
            {
                txtBoxQuestion.ClearValue(TextBox.BorderBrushProperty);

                if (oneOrMoreAlternativesEmpty == false && isThereACorrectAnswer == true && SelectionBox.SelectedIndex != 2)
                    AddQuestionToTest();

                else if (oneOrMoreAlternativesEmpty == false && SelectionBox.SelectedIndex == 2)
                    AddQuestionToTest();

                else if (isThereACorrectAnswer == false && SelectionBox.SelectedIndex != 2)
                    txtBlockWarning.Text = "Markera ett korrekt svar";

                else if (oneOrMoreAlternativesEmpty = true && isThereACorrectAnswer == false)
                    txtBlockWarning.Text = "Fyll i de markerade fälten och ett korrekt svar";
            }

            else
            {
                txtBoxQuestion.BorderBrush = Brushes.Red;
                txtBlockWarning.Text += "Frågan måste ha ett namn innan du sparar den.\n";
            }
        }

        private void AddQuestionToTest()
        {
            Questions xQuest = new Questions();
            xQuest.Name = txtBoxQuestion.Text;
            xQuest.QuestionType = GetQuestionType(SelectionBox.SelectedIndex);
            xQuest.ID = iID;
            try
            {
                if (!String.IsNullOrEmpty(imgQuestion.Source.ToString()))
                    xQuest.AppData = imgQuestion.Source.ToString();
            }
            catch (Exception)
            {
            }
            
            SaveAnwers(xQuest);
            m_lxQuestions.Add(xQuest);
            iID++;
            listViewAddedQuestions.Items.Add(xQuest.Name);
            btnSaveTest.IsEnabled = true;
            Clear(false);
        }

        private string GetQuestionType(int Selected)
        {
            string xName = "";
            switch (Selected)
            {
                case 0:
                    xName = "envalsfråga";
                    break;
                case 1:
                    xName = "Flervalsfråga";
                    break;
                case 2:
                    xName = "rangordning";
                    break;
                case 3:
                    xName = "Ditto";
                    break;
                default:
                    break;
            }
            return xName;
        }
        private void SetQuestionType(string sName)
        {
            switch (sName)
            {
                case "envalsfråga":
                    SelectionBox.SelectedIndex = 0;
                    break;
                case "Flervalsfråga":
                    SelectionBox.SelectedIndex = 1;
                    break;
                case "rangordning":
                    SelectionBox.SelectedIndex = 2;
                    break;
                case "Ditto":
                    SelectionBox.SelectedIndex = 3;
                    break;
                default:
                    break;
            }
        }
        private void SaveAnwers(Questions xQuest)
        {
            foreach (var StackPanelItem in _StackPanel.Children)
            {
                Answer xAnswer = new Answer();
                var temp = StackPanelItem as StackPanel;
                foreach (var Item in temp.Children)
                {
                    TextBox xTextBox = Item as TextBox;
                    if (xTextBox != null)
                    {
                        xAnswer.Text = xTextBox.Text;
                    }
                    RadioButton xRadioButton = Item as RadioButton;
                    if (xRadioButton != null)
                    { 
                        if (xRadioButton.IsChecked == true) xAnswer.RightAnswer = true;
                        else xAnswer.RightAnswer = false;
                    }
                    CheckBox xCheckbox = Item as CheckBox;
                    if (xCheckbox != null)
                    {
                        if (xCheckbox.IsChecked == true) xAnswer.RightAnswer = true;
                        else xAnswer.RightAnswer = false;
                    }
                    TextBlock xTextBlock = Item as TextBlock;
                    if (xTextBlock != null)
                    {
                        xAnswer.OrderPosition = int.Parse(xTextBlock.Text);
                    }
                }
                xAnswer.QuestionFk = xQuest.ID;
                m_lxAnswer.Add(xAnswer);
            }
            btnSaveQuestion.IsEnabled = true;
        }

        private void btnSaveTest_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxTestName.Text) == false)
            {
                txtBoxTestName.ClearValue(TextBox.BorderBrushProperty);
                txtBlockWarning.Text = "";
                SaveTest();
            }
            else
            {
                txtBlockWarning.Text = "Testet måste ha ett namn innan du sparar den.";
                txtBoxTestName.BorderBrush = Brushes.Red;
            }

        }

        private void SaveTest()
        {
            TestHandler xTestHandler = new TestHandler();
            Test xTest = new Test();

            if (chkBoxAutoCorrectTest.IsEnabled)
                xTest.IsAutoCorrect = true;
            else
                xTest.IsAutoCorrect = false;

            xTest.Name = txtBoxTestName.Text;
            
            xTestHandler.CreateTest(xTest, m_lxQuestions, m_lxAnswer, theTeacher.ID);

            Clear(true);
        }

        private StackPanel CreateQuestion(bool correctAnswer = false)
        {
            StackPanel xStackPanel = new StackPanel();
            TextBox xTextBox = new TextBox();
            xTextBox.Text = "";
            xTextBox.Width = 200;
            xStackPanel.Children.Add(xTextBox);
            

            switch (SelectionBox.SelectedIndex)
            {
                case 0:
                    xStackPanel.Children.Add(AddItemRadioButton(correctAnswer));
                    lblQTypeInstructions.Content = "Markera det korrekta svaret";
                    break;
                case 1:
                    xStackPanel.Children.Add(AddItemCheckBox(correctAnswer));
                    lblQTypeInstructions.Content = "Markera ett eller fler korrekta svar";
                    break;
                case 2:
                    int newQuestionIndex = 0;
                    for (int i = 0; i < _StackPanel.Children.Count; i++)
                        newQuestionIndex++;
                    xStackPanel.Children.Add(AddItemRanking(newQuestionIndex));
                    lblQTypeInstructions.Content = "Skriv frågorna i stigande ordning";
                    break;
                default:
                    break;
            }
            xStackPanel.Orientation = Orientation.Horizontal;
            return xStackPanel;       
        }

        private void SelectedQuestionType(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Hej");
            int j = -1;
            foreach (var item in _StackPanel.Children)
            {
                j++;
                StackPanel xStackPanel = item as StackPanel;
                for (int i = 0; i < xStackPanel.Children.Count; i++)
                {
                    Console.WriteLine(j + "question type loop");
                    if (xStackPanel.Children[i].GetType() != typeof(TextBox))
                    {
                        xStackPanel.Children.RemoveAt(i);
                        switch (SelectionBox.SelectedIndex)
                        {
                            case 0:
                                xStackPanel.Children.Add(AddItemRadioButton());
                                lblQTypeInstructions.Content = "Markera det korrekta svaret";
                                break;
                            case 1:
                                xStackPanel.Children.Add(AddItemCheckBox());
                                lblQTypeInstructions.Content = "Markera ett eller fler korrekta svar";
                                break;
                            case 2:
                                xStackPanel.Children.Add(AddItemRanking(j));
                                lblQTypeInstructions.Content = "Skriv frågorna i stigande ordning";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private CheckBox AddItemCheckBox(bool correctAnswer = false)
        {
            Thickness xThickness = new Thickness();
            CheckBox xCheckBox = new CheckBox();
            xThickness.Left = 10;
            if (correctAnswer)
                xCheckBox.IsChecked = true;

            xCheckBox.Margin = xThickness;
            return xCheckBox;
        }
        private RadioButton AddItemRadioButton(bool correctAnswer = false)
        {
            Thickness xThickness = new Thickness();
            xThickness.Left = 10;
            RadioButton xRadioButton = new RadioButton();
            xRadioButton.GroupName = "Question";
            xRadioButton.Margin = xThickness;
            if (correctAnswer)
                xRadioButton.IsChecked = true;
            return xRadioButton;
        }
        private TextBlock AddItemRanking(int i)
        {
            Thickness xThickness = new Thickness();
            xThickness.Left = 10;
            TextBlock xTxtBlock = new TextBlock();
            xTxtBlock.Margin = xThickness;
            xTxtBlock.Text = (i + 1).ToString();
            return xTxtBlock;
        }
        private void Clear(bool All)
        {
            btnSaveQuestion.IsEnabled = true;
            txtBoxQuestion.Text = "";
            if (All)
            {
                txtBoxTestName.Text = "";
                listViewAddedQuestions.Items.Clear();
                m_lxQuestions.Clear();
                m_lxAnswer.Clear();
            }
            _StackPanel.Children.Clear();
            imgQuestion.Source = null;
            SelectionBox.SelectedIndex = 0;
            for (int i = 0; i < 3; i++)
            {
                _StackPanel.Children.Add(CreateQuestion());
            }
        }
        private void RemoveStackPanel()
        {
            _StackPanel.Children.Clear();
        }

        private void EditQ(object sender, RoutedEventArgs e)
        {
            if (listViewAddedQuestions.SelectedIndex != -1)
            {
                Clear(false);
                List<Answer> lxAwnser = new List<Answer>();
                Console.WriteLine(listViewAddedQuestions.SelectedIndex);
                txtBoxQuestion.Text = m_lxQuestions[listViewAddedQuestions.SelectedIndex].Name;
                if (!String.IsNullOrEmpty(m_lxQuestions[listViewAddedQuestions.SelectedIndex].AppData))
                {
                    Uri imgUri = new Uri(m_lxQuestions[listViewAddedQuestions.SelectedIndex].AppData);
                    BitmapImage imgBitMap = new BitmapImage(imgUri);
                    imgQuestion.Source = imgBitMap;
                }

                foreach (var item in m_lxAnswer)
                {
                    if (item.QuestionFk == m_lxQuestions[listViewAddedQuestions.SelectedIndex].ID)
                    {
                        lxAwnser.Add(item);

                        RemoveStackPanel();
                        SetQuestionType(m_lxQuestions[listViewAddedQuestions.SelectedIndex].QuestionType);
                    }
                }
                foreach (var item in lxAwnser)
                {
                    m_lxAnswer.Remove(item);
                }
                listViewAddedQuestions.Items.Remove(listViewAddedQuestions.Items[listViewAddedQuestions.SelectedIndex]);
                NewStackPanel(lxAwnser);
            }
        }

        private void listViewAddedQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(listViewAddedQuestions.SelectedIndex);
            if (listViewAddedQuestions.SelectedItem != null)
            {
                btnEditQuestion.IsEnabled = true;
                btnRemoveQuestion.IsEnabled = true;
            }
            else
            {
                btnEditQuestion.IsEnabled = false;
                btnRemoveQuestion.IsEnabled = false;
            }
        }

        private void btnRemoveQuestion_Click(object sender, RoutedEventArgs e)
        {
            listViewAddedQuestions.Items.Remove(listViewAddedQuestions.SelectedItem);
        }

        private void btnRemoveImg_Click(object sender, RoutedEventArgs e)
        {
            imgQuestion.Source = null;
        }

        private void btnFindImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            if (openFileDialog.ShowDialog() == true)
            {
                String stringPath = openFileDialog.FileName;
                Console.WriteLine(stringPath);
                Uri imgUri = new Uri(stringPath);
                BitmapImage imgBitMap = new BitmapImage(imgUri);
                imgQuestion.Source = imgBitMap;
            }
        }
    }
}
