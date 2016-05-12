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
        public Student m_xStudent;
        public List<Test> m_lxTest;
        Repository xRepository;
        public MainPage(Student p_xStudent)
        {
            InitializeComponent();
            m_xStudent = p_xStudent;
            xRepository = new Repository();
            TextBlockUserWelcome.Text = "Välkommen " + m_xStudent.FirstName + " " + m_xStudent.LastName;
            m_lxTest = new List<Test>();
            m_lxTest = xRepository.GetTestForStudent(m_xStudent.ID);
            lbInfo.ItemsSource = m_lxTest;
        }

        private void StartTest(object sender, MouseButtonEventArgs e)
        {
            Test xTest = ((FrameworkElement)e.OriginalSource).DataContext as Test;
            if (xTest != null)
            {
                Console.WriteLine("Test Is Not Null And id is " + xTest.ID);

                ElevTestPage xElevTestPage = new ElevTestPage(xTest.ID, xRepository.GetStudentTestID(m_xStudent.ID, xTest.ID), m_xStudent);
                NavigationService.Navigate(xElevTestPage);
            }

        }
    }
}
