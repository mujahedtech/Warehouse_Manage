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


    public class JoinCycle
    {

        public int CycleID { get; set; }
        public int FarmID { get; set; }
        public string FarmStrNumber { get; set; }
        public DateTime DateEnter { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool CycleClose  { get; set; }
        public string FarmName { get; set; }


    }


    /// <summary>
    /// Interaction logic for FarmCycle.xaml
    /// </summary>
    public partial class FarmCycle : UserControl
    {
        public FarmCycle()
        {
            InitializeComponent();

            Farms_LoadedAsync();

           
        }


       

        private async void Farms_LoadedAsync()
        {
            FarmName.ItemsSource = await new DAL.Database("").GetFarms();





            //DatagridCycle.ItemsSource = await new DAL.Database("").GetFarmsCycles();




            var results = from FarmsTBL in await new DAL.Database("").GetFarms()
                          join FarmsCyclesTBL in await new DAL.Database("").GetFarmsCycles() on FarmsTBL.FarmID equals FarmsCyclesTBL.FarmID 
                          select new JoinCycle
                          {
                              CycleID = FarmsCyclesTBL.CycleID,
                              FarmID = FarmsTBL.FarmID,


                              FarmStrNumber = FarmsCyclesTBL.FarmStrNumber,
                              DateEnter =(DateTime) FarmsCyclesTBL.DateEnter,
                              DateStart= (DateTime)FarmsCyclesTBL.DateStart,
                              DateEnd = (DateTime)FarmsCyclesTBL.DateEnd,
                              FarmName = FarmsTBL.FarmName,
                              CycleClose= FarmsCyclesTBL.CycleClose

                          };






            DatagridCycle.ItemsSource = results.ToList().OrderBy(i=>i.CycleID);


            txtEmployeename.Text = txtBirdNumber.Text = txtBirdDead.Text = txtFeederCount.Text = txtWaterCount.Text = txtCarpentryCount.Text = "";
        }

      

        private void AddNewCycle_Click(object sender, RoutedEventArgs e)
        {
            txtEmployeename.Text = txtBirdNumber.Text = txtBirdDead.Text = txtFeederCount.Text = txtWaterCount.Text = txtCarpentryCount.Text = "";
            CycleDataview.Visibility = Visibility.Visible;

            SaveData.Content = "بداية دورة جديدة";
            ExtraData.IsEnabled = false;

            txtCycleStrID.Text = "";FarmName.SelectedIndex = -1;

            DAL.PassParameter.EmployeesList =new ObservableCollection<Tables.Employees>();
            DAL.PassParameter.BirdsList = new ObservableCollection<Tables.Birds>();
            DAL.PassParameter.BirdsDead = new ObservableCollection<Tables.BirdsDead>();
            DAL.PassParameter.Feeders = new ObservableCollection<Tables.Feeders>();
            DAL.PassParameter.Waters = new ObservableCollection<Tables.Waters>();
            DAL.PassParameter.Carpentrys = new ObservableCollection<Tables.Carpentrys>();

            GridHideControll.Visibility = Visibility.Collapsed;
            SaveData.Visibility = Visibility.Visible;
            StackControl.IsEnabled = true;

            btnCloseCycle.IsEnabled = true;
            btnCloseCycle.IsChecked = false;


            UpdateMode = false;
            SelectedFarmsCycle = null;

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            CycleDataview.Visibility = Visibility.Hidden;
        }


        bool UpdateMode { get; set; } = false;
        JoinCycle SelectedFarmsCycle = new JoinCycle();

      

        private async void EditCycle_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as JoinCycle;

           

            GridHideControll.Visibility = Visibility.Collapsed;
            SaveData.Visibility = Visibility.Visible;
            StackControl.IsEnabled = true;
            btnCloseCycle.IsEnabled = true;
            btnCloseCycle.IsChecked = false;


            if (Check.CycleClose)
            {
                btnCloseCycle.IsEnabled = false;
                btnCloseCycle.IsChecked = true;

                StackControl.IsEnabled = false;

                GridHideControll.Visibility = Visibility.Visible;

                SaveData.Visibility = Visibility.Collapsed;
            }

           

            UpdateMode = true;


            SelectedFarmsCycle = Check;

            //عرض تاريخ بداية الدورة
            txtDateStartCycle.Text = SelectedFarmsCycle.DateStart.ToString("M/dd/yyyy");


            //عرض رقم الدورة
            txtCycleStrID.Text = SelectedFarmsCycle.FarmStrNumber;

            //عرض اسم المزرعة
            FarmName.Text = SelectedFarmsCycle.FarmName;

            SaveData.Content = "تعديل البيانات";

            //تفعيل ادخال بيانات اضافية
            ExtraData.IsEnabled = true;

           
            //جلب بيانات العمال المدخلين سابقا على الدورة
            var DataEmployees = await new DAL.Database()._database.QueryAsync<Tables.Employees>("select * from Employees");

            DataEmployees = DataEmployees.ToList().Where(i => i.cycleID == Check.CycleID).ToList();

            DAL.PassParameter.EmployeesList = new ObservableCollection<Tables.Employees>(DataEmployees);

            //عرض بيانات العمال المدخلين سابقا
            EmployeeList.ItemsSource = DAL.PassParameter.EmployeesList.OrderBy(i => i.EmployeeID);




            //جلب بيانات الصوص المدخلين سابقا على الدورة
            var DataBirds = await new DAL.Database()._database.QueryAsync<Tables.Birds>("select * from Birds");

            DataBirds = DataBirds.ToList().Where(i => i.cycleID == Check.CycleID).ToList();

            DAL.PassParameter.BirdsList = new ObservableCollection<Tables.Birds>(DataBirds);

            //عرض بيانات الصوص المدخلين سابقا
            BirdList.ItemsSource = DAL.PassParameter.BirdsList.OrderBy(i => i.BirdID);





            //جلب بيانات الوفيات المدخلين سابقا على الدورة
            var DataBirdsDead = await new DAL.Database()._database.QueryAsync<Tables.BirdsDead>("select * from BirdsDead");

            DataBirdsDead = DataBirdsDead.ToList().Where(i => i.cycleID == Check.CycleID).ToList();

            DAL.PassParameter.BirdsDead = new ObservableCollection<Tables.BirdsDead>(DataBirdsDead);

            //عرض بيانات الصوص المدخلين سابقا
            BirdDeadList.ItemsSource = DAL.PassParameter.BirdsDead.OrderBy(i => i.BirdsDeadID);




            //جلب بيانات العلف المدخلين سابقا على الدورة
            var DataFeeders = await new DAL.Database()._database.QueryAsync<Tables.Feeders>("select * from Feeders");

            DataFeeders = DataFeeders.ToList().Where(i => i.cycleID == Check.CycleID).ToList();

            DAL.PassParameter.Feeders = new ObservableCollection<Tables.Feeders>(DataFeeders);

            //عرض بيانات العلف المدخلين سابقا
            ListFeeders.ItemsSource = DAL.PassParameter.Feeders.OrderBy(i => i.FeederID);



            //جلب بيانات المياه المدخلين سابقا على الدورة
            var DataWaters = await new DAL.Database()._database.QueryAsync<Tables.Waters>("select * from Waters");

            DataWaters = DataWaters.ToList().Where(i => i.cycleID == Check.CycleID).ToList();

            DAL.PassParameter.Waters = new ObservableCollection<Tables.Waters>(DataWaters);

            //عرض بيانات المياه المدخلين سابقا
            ListWaters.ItemsSource = DAL.PassParameter.Waters.OrderBy(i => i.WaterID);


            //جلب بيانات النجارة المدخلين سابقا على الدورة
            var DataCarpentrys = await new DAL.Database()._database.QueryAsync<Tables.Carpentrys>("select * from Carpentrys");

            DataCarpentrys = DataCarpentrys.ToList().Where(i => i.cycleID == Check.CycleID).ToList();

            DAL.PassParameter.Carpentrys = new ObservableCollection<Tables.Carpentrys>(DataCarpentrys);

            //عرض بيانات النجارة المدخلين سابقا
            ListCarpentrys.ItemsSource = DAL.PassParameter.Carpentrys.OrderBy(i => i.CarpentryID);




            //عرض الواجهة
            CycleDataview.Visibility = Visibility.Visible;
        }

        private async void SaveData_Click(object sender, RoutedEventArgs e)
        {
            if (FarmName.SelectedItem != null)
            {
                Tables.FarmsCycle farmsCycle;


                DateTime CycleStartDateTime = new DateTime(
                         DateTime.Parse(txtDateStartCycle.SelectedDate.ToString()).Year,
                         DateTime.Parse(txtDateStartCycle.SelectedDate.ToString()).Month,
                         DateTime.Parse(txtDateStartCycle.SelectedDate.ToString()).Day,
                       DateTime.Now.Hour,
                         DateTime.Now.Minute,
                          DateTime.Now.Second);

                if (UpdateMode==true)
                {
                    if (FarmName.SelectedItem!=null)
                    {
                        var data = (Tables.Farms)FarmName.SelectedItem;

                        DateTime CycleEndDateTime = new DateTime(
                            DateTime.Parse(txtDateEndCycle.SelectedDate.ToString()).Year,
                            DateTime.Parse(txtDateEndCycle.SelectedDate.ToString()).Month,
                            DateTime.Parse(txtDateEndCycle.SelectedDate.ToString()).Day,
                          DateTime.Now.Hour,
                            DateTime.Now.Minute,
                             DateTime.Now.Second);


                       


                        farmsCycle = new Tables.FarmsCycle
                        {
                            CycleID = SelectedFarmsCycle.CycleID,
                            FarmID = data.FarmID,
                            FarmStrNumber = txtCycleStrID.Text,
                            DateStart = CycleStartDateTime,
                            CycleClose= (bool)btnCloseCycle.IsChecked?true:false,
                            DateEnd= (bool)btnCloseCycle.IsChecked ? CycleEndDateTime : new DateTime(1,1,1),
                            DateEnter= SelectedFarmsCycle.DateEnter
                        };

                       

                        //تحديث بيانات الدورة
                        await new DAL.Database("").UpdateFarmsCycleAsync(farmsCycle);




                        //حذف بيانات العمال السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteEmployeeAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات العمال الجديدة
                        await new DAL.Database("").SaveEmployeeAsync(DAL.PassParameter.EmployeesList.ToList());





                        //حذف بيانات الصوص السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteBirdAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات الصوص الجديدة
                        await new DAL.Database("").SaveBirdAsync(DAL.PassParameter.BirdsList.ToList());




                        //حذف بيانات الوفيات السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteBirdsDeadAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات الوفيات الجديدة
                        await new DAL.Database("").SaveBirdsDeadAsync(DAL.PassParameter.BirdsDead.ToList());




                        //حذف بيانات العلف السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteFeedersAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات العلف الجديدة
                        await new DAL.Database("").SaveFeedersAsync(DAL.PassParameter.Feeders.ToList());




                         //حذف بيانات المياه السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteWatersAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات المياه الجديدة
                        await new DAL.Database("").SaveWatersAsync(DAL.PassParameter.Waters.ToList());



                        //حذف بيانات النجارة السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteCarpentrysAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات النجارة الجديدة
                        await new DAL.Database("").SaveCarpentrysAsync(DAL.PassParameter.Carpentrys.ToList());


                        CycleDataview.Visibility = Visibility.Collapsed;
                       
                        Farms_LoadedAsync();
                        return;
                    }

                   
                }


                var SelectedFarm = (Tables.Farms)FarmName.SelectedItem;

                 farmsCycle = new Tables.FarmsCycle
                {
                    CycleIDGuid = Guid.NewGuid(),
                    FarmID = SelectedFarm.FarmID,
                    FarmStrNumber = txtCycleStrID.Text,
                    DateEnter = DateTime.Now,
                    DateStart = CycleStartDateTime
                 };





                await new DAL.Database("").SaveCycleAsync(farmsCycle);



                CycleDataview.Visibility = Visibility.Collapsed;

              

                Farms_LoadedAsync();

            }

              


        }

        private void EmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmployeename.Text ==""||txtEmployeeState.Text == ""|| txtEmployeeState.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء ادخال البيانات بشكل كافي");
                return;
            }
            DAL.PassParameter.EmployeesList.Add(new Tables.Employees { EmployeeID=Guid.NewGuid(),
                EmployeeName=txtEmployeename.Text,
                DateAdd=DateTime.Parse(txtDateadd.Text),
                DateRemove= DateTime.Parse(txtDateRemove.Text) ,
                State=txtEmployeeState.Text,
                FarmID= SelectedFarmsCycle.FarmID,
                cycleID= SelectedFarmsCycle.CycleID
            });

            txtEmployeename.Text = txtEmployeeState.Text = "";
            txtEmployeeState.SelectedIndex = -1;




            EmployeeList.ItemsSource = DAL.PassParameter.EmployeesList;
        }

        private void btnAddBird_Click(object sender, RoutedEventArgs e)
        {


            if (txtBirdNumber.Text == "" )
            {
                MessageBox.Show("الرجاء ادخال عدد الصوص");
                return;
            }
            DAL.PassParameter.BirdsList.Add(new Tables.Birds
            {
                BirdID = Guid.NewGuid(),
                BirdCount =double.Parse( txtBirdNumber.Text),
                DateAdd = DateTime.Parse(txtBridDate.Text),FarmID=SelectedFarmsCycle.FarmID,cycleID= SelectedFarmsCycle.CycleID

            });

            txtBirdNumber.Text  = "";
           

            BirdList.ItemsSource = DAL.PassParameter.BirdsList;
        }

        private void btnBirdDead_Click(object sender, RoutedEventArgs e)
        {
            if (txtBirdDead.Text == "")
            {
                MessageBox.Show("الرجاء ادخال عدد الوفيات");
                return;
            }
            DAL.PassParameter.BirdsDead.Add(new Tables.BirdsDead
            {
                BirdsDeadID = Guid.NewGuid(),
                BirdsDeadCount = double.Parse(txtBirdDead.Text),
                DateAdd = DateTime.Parse(txtbirddeadDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID

            });

            txtBirdDead.Text = "";


            BirdDeadList.ItemsSource = DAL.PassParameter.BirdsDead;
        }

        private void btnFeederAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtFeederCount.Text == "")
            {
                MessageBox.Show("الرجاء ادخال عدد العلف");
                return;
            }
            DAL.PassParameter.Feeders.Add(new Tables.Feeders
            {
                FeederID = Guid.NewGuid(),
                FeederCount = double.Parse(txtFeederCount.Text),
                DateAdd = DateTime.Parse(txtbirddeadDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID

            });

            txtFeederCount.Text = "";


            ListFeeders.ItemsSource = DAL.PassParameter.Feeders;
        }

        private void btnAddWater_Click(object sender, RoutedEventArgs e)
        {
            if (txtWaterCount.Text == "")
            {
                MessageBox.Show("الرجاء ادخال عدد المياه");
                return;
            }
            DAL.PassParameter.Waters.Add(new Tables.Waters
            {
                WaterID = Guid.NewGuid(),
                WaterCount = double.Parse(txtWaterCount.Text),
                DateAdd = DateTime.Parse(txtbirddeadDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID

            });

            txtWaterCount.Text = "";


            ListWaters.ItemsSource = DAL.PassParameter.Waters;
        }

        private void btnCarpentryAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtCarpentryCount.Text == "")
            {
                MessageBox.Show("الرجاء ادخال عدد النجارة");
                return;
            }
            DAL.PassParameter.Carpentrys.Add(new Tables.Carpentrys
            {
                CarpentryID = Guid.NewGuid(),
                CarpentryCount = double.Parse(txtCarpentryCount.Text),
                DateAdd = DateTime.Parse(txtCarpentryDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID

            });

            txtCarpentryCount.Text = "";


            ListCarpentrys.ItemsSource = DAL.PassParameter.Carpentrys;
        }

        private async void FarmName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FarmName.SelectedItem != null)
            {


                var data = (Tables.Farms)FarmName.SelectedItem;




                var Data = await new DAL.Database()._database.QueryAsync<Tables.FarmsCycle>("select * from FarmsCycle");

                Data = Data.ToList().Where(i => i.FarmID == data.FarmID).ToList();

                int Count = 1;

                if (Data.Count > 0)
                {
                    Count = Data.Count + 1;
                }

                string View = $"{DateTime.Now.Year}/{Count}";


                if (SelectedFarmsCycle!=null)
                {
                    if (FarmName.Text == SelectedFarmsCycle.FarmName)
                    {
                        txtCycleStrID.Text = SelectedFarmsCycle.FarmStrNumber;
                        return;
                    }
                }
                   
               

                txtCycleStrID.Text = View;


            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
           

            string Message = "هل تريد الحذف ؟";

            if (SelectedFarmsCycle.CycleClose)
            {
                button.IsEnabled = false;
            }

           else if (SelectedFarmsCycle.CycleClose==false)
            {
                switch (button.FontFamily.ToString())
                {
                    case "Employees":
                        var Employees = button.CommandParameter as Tables.Employees;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.EmployeesList.Remove(Employees);

                            EmployeeList.ItemsSource = DAL.PassParameter.EmployeesList;
                        }

                        break;
                    case "Birds":
                        var Birds = button.CommandParameter as Tables.Birds;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.BirdsList.Remove(Birds);

                            BirdList.ItemsSource = DAL.PassParameter.BirdsList;
                        }

                        break;
                    case "BirdDead":
                        var BirdsDead = button.CommandParameter as Tables.BirdsDead;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.BirdsDead.Remove(BirdsDead);

                            BirdDeadList.ItemsSource = DAL.PassParameter.BirdsDead;
                        }

                        break;
                    case "Feeders":
                        var Feeders = button.CommandParameter as Tables.Feeders;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Feeders.Remove(Feeders);

                            ListFeeders.ItemsSource = DAL.PassParameter.Feeders;
                        }

                        break;
                    case "Waters":
                        var Waters = button.CommandParameter as Tables.Waters;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Waters.Remove(Waters);

                            ListWaters.ItemsSource = DAL.PassParameter.Waters;
                        }

                        break;
                    case "Carpentrys":
                        var Carpentrys = button.CommandParameter as Tables.Carpentrys;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Carpentrys.Remove(Carpentrys);

                            ListCarpentrys.ItemsSource = DAL.PassParameter.Carpentrys;
                        }

                        break;

                }
            }

          



           

           
        }

        private void btnCloseCycle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
