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
    /// Interaction logic for StatistikMasterPage.xaml
    /// </summary>
    public partial class StatistikMasterPage : Page
    {
        List<WritenTest> liWrittenTests = new List<WritenTest>(); 
        public StatistikMasterPage()
        {
            InitializeComponent();
            GetTestList();
            ListViewTests.ItemsSource = liWrittenTests;
        }

        private void GetTestList()
        {
            Repository repo = new Repository();
            liWrittenTests = repo.GetAllWrittenTests();
        }
    }
}
