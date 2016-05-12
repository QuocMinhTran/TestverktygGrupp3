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
    /// Interaction logic for StatistikDetailPage.xaml
    /// </summary>
    public partial class StatistikDetailPage : Page
    {
        public List<Questions> liQuestionses = new List<Questions>();
        public static Test SelectedTest = new Test();
        public static Student SelectedStudent = new Student();
        public StatistikDetailPage()
        {
            InitializeComponent();

            CurrentSelectedTest csTest = new CurrentSelectedTest();
            csTest.SetCurrentTest(SelectedTest.ID);

            liQuestionses = csTest.CurrentQuestions;

            Repository xRepository = new Repository();
            Test xTest = xRepository.GetTest(SelectedTest.ID);
            List<Answer> lxAnswers = xRepository.GetAllAnswers(xTest);
            List<StudentAnswer> lxStudentAnswers = new List<StudentAnswer>();
            lxStudentAnswers = xRepository.GetStudentAnswers(SelectedStudent.ID, xTest.ID);

            for (int i = 0; i < liQuestionses.Count; i++)
            {
                TextBlock xBlock = new TextBlock();
                xBlock.Text = liQuestionses[i].Name;
                lvDetails.Items.Add(xBlock);
                for (int j = 0; j < lxAnswers.Count; j++)
                {
                    foreach (var item in lxStudentAnswers)
                    {
                        if (liQuestionses[i].ID == lxAnswers[j].QuestionFk)
                        {
                            if (item.Answer == lxAnswers[j].ID)
                            {
                                Console.WriteLine("asdasdjalksjdlkajsdklkd");
                                TextBlock xAnswer = new TextBlock();
                                xAnswer.Text = lxAnswers[j].Text;

                                if (lxAnswers[j].RightAnswer && liQuestionses[i].QuestionType != "rangordning")
                                {
                                    xAnswer.Background = Brushes.Green;
                                }
                                else if (!lxAnswers[j].RightAnswer && liQuestionses[i].QuestionType != "rangordning")
                                {
                                    xAnswer.Background = Brushes.Red;
                                }

                                if (lxAnswers[j].OrderPosition == item.OrderPostition && liQuestionses[i].QuestionType == "rangordning")
                                {
                                    xAnswer.Background = Brushes.Green;
                                }
                                else if (lxAnswers[j].OrderPosition != item.OrderPostition && liQuestionses[i].QuestionType == "rangordning")
                                {
                                    xAnswer.Background = Brushes.Red;
                                }
                                lvDetails.Items.Add(xAnswer);
                            }
                        }
                    }
                }
            }





            //Answer _studentsAnswers = new Answer();

            //foreach (var item in Questionses)
            //{

            //    lvDetails.Items.Add("Fråga: " + item.Name);
            //    foreach (var studentsAnswer in csTest.GetStudentsAnswers(item.ID))
            //    {
            //        Console.WriteLine(studentsAnswer.Text);
            //        lvDetails.Items.Add("Elevens svar :" + studentsAnswer.Text);
            //    }
            //    foreach (var answer in csTest.GetCorrectAnswer(item.ID))
            //    {
            //        lvDetails.Items.Add("Korrekt svar: " + answer.Text);
            //    }

            //}



        }

    }
}
