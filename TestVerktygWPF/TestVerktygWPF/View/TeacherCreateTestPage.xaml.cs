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
        public TeacherCreateTestPage()
        {
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
            for (int i = 0; i < lxAnswers.Count; i++)
            {
                _StackPanel.Children.Add(CreateQuestion());
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

        private void SaveQuestion(object sender, RoutedEventArgs e)
        {
            Questions xQuest = new Questions();
            xQuest.Name = txtBoxQuestion.Text;
            xQuest.QuestionType = GetQuestionType(SelectionBox.SelectedIndex);
            xQuest.ID = iID;
            SaveAnwers(xQuest);
            m_lxQuestions.Add(xQuest);
            iID++;
            listViewAddedQuestions.Items.Add(xQuest.Name);
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
                }
                xAnswer.QuestionFk = xQuest.ID;
                m_lxAnswer.Add(xAnswer);
            }
            btnSaveQuestion.IsEnabled = true;
        }

        private void SaveTest(object sender, RoutedEventArgs e)
        {
            TestHandler xTestHandler = new TestHandler();
            Test xTest = new Test();
            xTest.Name = txtBoxTestName.Text;
            xTestHandler.CreateTest(xTest,m_lxQuestions,m_lxAnswer);

            Clear(true);
        }
        private StackPanel CreateQuestion()
        {
            StackPanel xStackPanel = new StackPanel();
            TextBox xTextBox = new TextBox();
            xTextBox.Text = "";
            xTextBox.Width = 170;
            xStackPanel.Children.Add(xTextBox);

            switch (SelectionBox.SelectedIndex)
            {
                case 0:
                    xStackPanel.Children.Add(AddItemRadioButton());
                    break;
                case 1:
                    xStackPanel.Children.Add(AddItemCheckBox());
                    break;
                case 2:
                    xStackPanel.Children.Add(AddItemComboBox());
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
            foreach (var item in _StackPanel.Children)
            {
                StackPanel xStackPanel = item as StackPanel;
                for (int i = 0; i < xStackPanel.Children.Count; i++)
                {
                    if (xStackPanel.Children[i].GetType() != typeof(TextBox))
                    {
                        xStackPanel.Children.RemoveAt(i);
                        switch (SelectionBox.SelectedIndex)
                        {
                            case 0:
                                xStackPanel.Children.Add(AddItemRadioButton());
                                break;
                            case 1:
                                xStackPanel.Children.Add(AddItemCheckBox());
                                break;
                            case 2:
                                xStackPanel.Children.Add(AddItemComboBox());
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        private CheckBox AddItemCheckBox()
        {
            Thickness xThickness = new Thickness();
            CheckBox xCheckBox = new CheckBox();
            xThickness.Left = 10;

            xCheckBox.Margin = xThickness;
            return xCheckBox;
        }
        private ComboBox AddItemComboBox()
        {
            Thickness xThickness = new Thickness();
            ComboBox xComboBox = new ComboBox();
            xThickness.Left = 10;

            xComboBox.Margin = xThickness;
            return xComboBox;
        }
        private RadioButton AddItemRadioButton()
        {
            Thickness xThickness = new Thickness();
            xThickness.Left = 10;
            RadioButton xRadioButton = new RadioButton();
            xRadioButton.GroupName = "Question";
            xRadioButton.Margin = xThickness;
            return xRadioButton;
        }
        private void Clear(bool All)
        {
            btnSaveQuestion.IsEnabled = false;
            txtBoxQuestion.Text = "";
            if (All)
            {
                txtBoxTestName.Text = "";
                listViewAddedQuestions.Items.Clear();
                m_lxQuestions.Clear();
                m_lxAnswer.Clear();
            }
            _StackPanel.Children.Clear();
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
            Clear(false);
            List<Answer> lxAwnser = new List<Answer>();
            Console.WriteLine(listViewAddedQuestions.SelectedIndex);
            txtBoxQuestion.Text = m_lxQuestions[listViewAddedQuestions.SelectedIndex].Name;
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
}
