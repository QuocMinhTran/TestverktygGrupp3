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

namespace TestVerktygElev
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        public StatisticPage(Test p_xTest,int p_iScore)
        {
            InitializeComponent();
            TextBlockTestName.Text = p_xTest.Name;
            TextBlockTime.Text = p_xTest.TimeStampe.ToString();
            TextBlockGrade.Text = p_iScore.ToString();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Student Stuent = new Student();
            Stuent.ID = 1;
            MainPage xMainPage = new MainPage(Stuent);
            NavigationService.Navigate(xMainPage);
        }
        private void InitData()
        {
            TextBlock xTextBlock = new TextBlock();
            xTextBlock.Text = "Hej";
            ListViewCompletedTest.Items.Add(xTextBlock);
        }
    }
}
