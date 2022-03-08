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
using System.Windows.Shapes;

namespace Warehouse_Manage.Pages
{
    /// <summary>
    /// Interaction logic for MessageBoxWindows.xaml
    /// </summary>
    public partial class MessageBoxWindows : Window
    {
        public MessageBoxWindows( string Message,string Header= "خطا في الادخال")
        {
            InitializeComponent();

           

            txtHeader.Text = Header;txtMessage.Text = Message;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
