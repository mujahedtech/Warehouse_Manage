using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Farms.xaml
    /// </summary>
    public partial class Farms : UserControl
    {
        public Farms()
        {
            InitializeComponent();

            Farms_LoadedAsync();




        }


      


        private async void Farms_LoadedAsync()
        {
            DatagridFarm.ItemsSource = await new DAL.Database("").GetFarms();
            return;

          

        }

        private void AddFarm_Click(object sender, RoutedEventArgs e)
        {
            AddFarmPop.IsOpen = true;
            txtMessage.Text = ""; txtFarmName.Text = "";

            lblHeader.Text = "اضافة مزرعة جديدة";
            btnAddFarm.Content = "تخزين";

            txtFarmName.Focus();
           
        }

        private void CloseAddFarm_Click(object sender, RoutedEventArgs e)
        {
            AddFarmPop.IsOpen = false;
        }

        private async void btnAddFarm_Click(object sender, RoutedEventArgs e)
        {
            if (txtFarmName.Text=="")
            {
                txtMessage.Text = "الرجاء ادخال اسم المزرعة";
                return;
            }



            if (SelectedFarm!=null)
            {
                SelectedFarm.FarmName = txtFarmName.Text;
                await new DAL.Database("").UpdateFarmAsync(SelectedFarm);

            }
           else if (SelectedFarm == null)
            {
                await new DAL.Database("").SaveFarmAsync(new Tables.Farms { FarmIDGuid = Guid.NewGuid(), FarmName = txtFarmName.Text, DateEnter = DateTime.Now });





            }
            txtMessage.Text = "تم الاضافة بنجاح";
            txtFarmName.Text = "";
            Farms_LoadedAsync();
            SelectedFarm = null;

            AddFarmPop.IsOpen = false;


        }



        Tables.Farms SelectedFarm = null;
        private void EditFarm_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as Tables.Farms;

            lblHeader.Text = "تعديل مزرعة";
            btnAddFarm.Content = "تعديل";

            SelectedFarm = Check;

            txtFarmName.Text = SelectedFarm.FarmName;

            

            txtMessage.Text = "";

            AddFarmPop.IsOpen = true;

           
            
            txtFarmName.Focus();
        }

        private void txtFarmName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //var uie = e.OriginalSource as UIElement;
                //uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

                btnAddFarm.Focus();
               

            }
        }

       
    }
}
