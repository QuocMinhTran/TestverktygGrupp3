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
        
        public static List<Questions> Questionses = new List<Questions>(); 
        public StatistikDetailPage()
        {
            InitializeComponent();
            CurrentSelectedTest csTest = new CurrentSelectedTest();
         
            //Questionses = csTest.CurrentQuestions;
         
            foreach (var item in Questionses)
            {
                Console.WriteLine("Qurrrentqustion detailstat :"+ item.Name);
               lvDetails.Items.Add("Fråga:" + item.Name);
                lvDetails.Items.Add(csTest.GetCorrectAnswer(item.ID).Text);
            }
        }
    }
}
