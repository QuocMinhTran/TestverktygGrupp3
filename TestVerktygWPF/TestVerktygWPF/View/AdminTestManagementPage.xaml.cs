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

namespace TestVerktygWPF.View
{
    /// <summary>
    /// Interaction logic for AdminTestManagementPage.xaml
    /// </summary>
    public partial class AdminTestManagementPage : Page
    {
        //IList<Test> Tests = new List<Test>();
        public AdminTestManagementPage()
        {
            InitializeComponent();
            using (var db = new DbModel())
            {
                var query = from t in db.Tests
                            where t.EndDate > new DateTime()
                _DataGrid.ItemsSource = db.Tests.ToList();

            }


        }
    }
}
