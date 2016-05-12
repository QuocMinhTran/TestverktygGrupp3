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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
             
            csTest.SetCurrentTest(SelectedTest.ID);
            Test testnamn = csTest.CurrentTest;
            liQuestionses = csTest.CurrentQuestions;

            Repository xRepository = new Repository();
            Test xTest = xRepository.GetTest(SelectedTest.ID);
            List<Answer> lxAnswers = xRepository.GetAllAnswers(xTest);
            List<StudentAnswer> lxStudentAnswers = new List<StudentAnswer>();
            lxStudentAnswers = xRepository.GetStudentAnswers(SelectedStudent.ID, xTest.ID);
            TextBlock txtbStudentName = new TextBlock();
            txtbStudentName.Text = SelectedStudent.FirstName + " " + SelectedStudent.LastName + " Prov: " + testnamn.Name ;
            lvDetails.Items.Add(txtbStudentName);
            for (int i = 0; i < liQuestionses.Count; i++)
            {
                TextBlock xQuestion = new TextBlock();
                xQuestion.Text = "Fråga : ";
                TextBlock xBlock = new TextBlock();
                xBlock.Text = liQuestionses[i].Name;
                xBlock.FontWeight = FontWeights.Bold;
                xBlock.FontSize = 18;
                lvDetails.Items.Add(xQuestion);
                lvDetails.Items.Add(xBlock);
                for (int j = 0; j < lxAnswers.Count; j++)
                {
                    foreach (var item in lxStudentAnswers)
                    {
                        if (liQuestionses[i].ID == lxAnswers[j].QuestionFk)
                        {
                            if (item.Answer == lxAnswers[j].ID)
                            {
                                TextBlock xAnswer = new TextBlock();
                                xAnswer.Text = "Svar: "+lxAnswers[j].Text;
                                xAnswer.FontSize = 16;

                                TextBlock xCorrectAnswer = new TextBlock();

                                if (lxAnswers[j].RightAnswer && liQuestionses[i].QuestionType != "rangordning")
                                {
                                    xAnswer.Background = Brushes.Green;
                                }
                                else if (!lxAnswers[j].RightAnswer && liQuestionses[i].QuestionType != "rangordning")
                                {
                                    xAnswer.Background = Brushes.Red;
                                    foreach (var correctAns in lxAnswers)
                                    {
                                        if (correctAns.RightAnswer == true && correctAns.QuestionFk == liQuestionses[i].ID)
                                        {
                                            xCorrectAnswer.Text = "Korrekt svar: " + correctAns.Text;
                                        }
                                    }
                                }

                                if (lxAnswers[j].OrderPosition == item.OrderPostition && liQuestionses[i].QuestionType == "rangordning")
                                {
                                    xAnswer.Background = Brushes.Green;
                                   
                                }
                                else if (lxAnswers[j].OrderPosition != item.OrderPostition && liQuestionses[i].QuestionType == "rangordning")
                                {
                                    xAnswer.Background = Brushes.Red;
                                    foreach (var correctAns in lxAnswers)
                                    {
                                      
                                        if (correctAns.RightAnswer == true && correctAns.QuestionFk == liQuestionses[i].ID )
                                        {
                                            xCorrectAnswer.Text = "Korrekt svar: " + correctAns.Text;
                                        }
                                    }
                                }

                                lvDetails.Items.Add(xAnswer);
                                lvDetails.Items.Add(xCorrectAnswer);
                            }
                        }
                    }
                }
            }
           
            
        }

        private void BtnSaveToPdf_OnClick(object sender, RoutedEventArgs e)
        {
            System.IO.FileStream fs = new FileStream("Test.pdf", FileMode.Create);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            // Create an instance to the PDF file by creating an instance of the PDF 
            // Writer class using the document and the filestrem in the constructor.
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();
            // Add a simple and wellknown phrase to the document in a flow layout manner
           
            List<string> list = lvDetails.Items.Cast<TextBlock>().Select(x => x.Text).ToList();

            foreach (var item in list)
            {
               
                document.Add(new iTextSharp.text.Paragraph(item));
                
            }

            // Close the document
            document.Close();
            // Close the writer instance
            writer.Close();
            // Always close open filehandles explicity
            fs.Close();

        }
    }
}
