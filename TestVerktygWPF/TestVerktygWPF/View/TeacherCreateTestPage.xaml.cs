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
        public TeacherCreateTestPage()
        {
            InitializeComponent();
            m_lxQuestions = new List<Questions>();
            SelectionBox.SelectedIndex = 0;
            for (int i = 0; i < 3; i++)
            {
                _StackPanel.Children.Add(CreateQuestion());
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

            //Questions xQuest = new Questions();
            //xQuest.QuestionsLabel = txtBoxQuestion.Text;
            //foreach (var StackPanelItem in _StackPanel.Children)
            //{
            //    Answer xOption = new Answer();
            //    Console.WriteLine(StackPanelItem.ToString());
            //    var temp = StackPanelItem as StackPanel;
            //    foreach (var Item in temp.Children)
            //    {

            //        TextBox xTextBox = Item as TextBox;
            //        if (xTextBox != null)
            //        {
            //            xOption.SelectivOption = xTextBox.Text;
            //        }
            //        CheckBox xCheckBox = Item as CheckBox;
            //        if (xCheckBox != null)
            //        {
            //            if (xCheckBox.IsChecked == true) xOption.RightAnswer = true;
            //            else xOption.RightAnswer = false;

            //        }
            //        RadioButton xRadioButton = Item as RadioButton;
            //        if (xRadioButton != null)
            //        {
            //            if (xRadioButton.IsChecked == true) xOption.RightAnswer = true;
            //            else xOption.RightAnswer = false;

            //        }
            //    }
            //    xQuest.Options.Add(xOption);
            //}
            //m_lxQuestions.Add(xQuest);
            //listViewAddedQuestions.Items.Add(xQuest.QuestionsLabel);

        }

        private void SaveTest(object sender, RoutedEventArgs e)
        {
       
            //Test xTest = new Test();
            //Repository xRepository = new Repository();
            //xTest.Name = txtBoxTestName.Text;
            //xTest.StartDate = DateTime.Today;
            //xTest.EndDate = DateTime.Today.AddDays(1);
            //xTest.TeacherRefFK = 2;
            //xRepository.SaveTest(xTest);
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

                    xStackPanel.Children.Add(AddItemComboBox());
                    break;
                case 2:
                    xStackPanel.Children.Add(AddItemCheckBox());
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
                    if (xStackPanel.Children[i].GetType() != typeof(TextBox) )
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
    }
}
