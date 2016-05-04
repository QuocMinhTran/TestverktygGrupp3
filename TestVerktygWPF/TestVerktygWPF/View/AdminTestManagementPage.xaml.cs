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
                            join ut in db.UserTests on t.ID equals ut.TestFk
                            join u in db.Users on ut.UserFk equals u.ID
                            join sc in db.StudentClasses on u.StudentClassFk equals sc.ID
                            join scc in db.StudentClassCourses on sc.ID equals scc.StudentClassRefID
                            join c in db.Courses on scc.CouseRefID equals c.ID
                            where t.EndDate >= DateTime.Now
                            select t;
                _DataGrid.ItemsSource = query.ToList();

            }


        }
    }
}
