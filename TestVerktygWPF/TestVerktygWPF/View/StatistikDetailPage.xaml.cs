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

        public List<Questions> Questionses = new List<Questions>();
        public static Test SelectedTest = new Test();
        public StatistikDetailPage()
        {
            InitializeComponent();

            CurrentSelectedTest csTest = new CurrentSelectedTest();
            csTest.SetCurrentTest(SelectedTest.ID);

            Questionses = csTest.CurrentQuestions;

            foreach (var item in Questionses)
            {
               
                lvDetails.Items.Add("Fråga: " + item.Name);
                foreach (var answer in csTest.GetCorrectAnswer(item.ID))
                {
                    lvDetails.Items.Add(answer.Text);
                }
               
            }



        }

    }
}
