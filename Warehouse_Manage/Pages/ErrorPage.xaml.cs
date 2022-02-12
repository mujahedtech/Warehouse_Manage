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

namespace Warehouse_Manage.Pages
{
    /// <summary>
    /// Interaction logic for ErrorPage.xaml
    /// </summary>
    public partial class ErrorPage : UserControl
    {
        public ErrorPage(string Message="")
        {
            InitializeComponent();
            txtError.Text = Message;
        }

        private void btnCLose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
