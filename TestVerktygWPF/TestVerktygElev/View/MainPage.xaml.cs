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
using TestVerktygElev.ViewModel;

namespace TestVerktygElev
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<Test> m_lxTest;
        public MainPage()
        {
            Repository xRepository = new Repository();
            InitializeComponent();
            m_lxTest = new List<Test>();
            m_lxTest = xRepository.GetTestForStudent(2);
            foreach (var item in m_lxTest)
            {
                Console.WriteLine("Name of Test" + item.Name + " Test ID " + item.ID);
            }
            lbInfo.ItemsSource = m_lxTest;

        }

        private void StartTest(object sender, MouseButtonEventArgs e)
        {

            Test xTest = ((FrameworkElement)e.OriginalSource).DataContext as Test;
            if (xTest != null)
            {
                Console.WriteLine("Test Is Not Null And id is " + xTest.ID);
            }
            
            ElevTestPage xElevTestPage= new ElevTestPage(xTest.ID);
            NavigationService.Navigate(xElevTestPage);

        }
    }
}
