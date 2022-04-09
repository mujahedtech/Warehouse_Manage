using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public bool CycleClose { get; set; }
        public string FarmName { get; set; }
        public string FarmSupervisor { get; set; }


    }


    public class FooterTotal: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public double TotalBirdsQty { get; set; }
        public double TotalBirdsCost { get; set; }
        public double TotalSalary { get; set; }
        public double CountEmployeeQty { get; set; }
        public double TotalBirdsDeadQty { get; set; }
        public double TotalFeedersQty { get; set; }
        public double TotalFeedersCost { get; set; }
        public double TotalWaterQTY { get; set; }
        public double TotalWaterCost { get; set; }
        public double TotalCarpentrysQty { get; set; }
        public double TotalCarpentrysCost { get; set; }

        public double TotalElectricityCost { get; set; }
        public double TotalMaintenanceCost { get; set; }
        public double TotalMiscellaneousCost { get; set; }
        public double TotalPharmaceuticalQty { get; set; }
        public double TotalPharmaceuticalCost { get; set; }
        public double TotalGas_CylinderCost { get; set; }
        public double TotalGas_LiquidCost { get; set; }
        public double TotalFuelCost { get; set; }



        //Binding Area


        private DAL.MedNames _selectedMed;
        public DAL.MedNames SelectedMed
        {
            get { return _selectedMed; }

            set { _selectedMed = value; OnPropertyChanged("SelectedMed"); ViewPharmaceuticalList = false; }
        
        }


        private string _s;
        public string Search
        {
            get { return _s;}
            set { _s = value;

                OnPropertyChanged("Search");
                GetResults(_s); }
        }

        private readonly ObservableCollection<DAL.MedNames> _results = new ObservableCollection<DAL.MedNames>();
        public ObservableCollection<DAL.MedNames> Results { get { return _results; } }

        private void GetResults(string s)
        {
            _results.Clear();
            Task.Factory.StartNew(() =>
            {
                //perform the actual search here and return a list with the results...
                return  DAL.Queries.Ts.Where(i=> i.MedName.ToString().Contains(s.Trim()) || i.MedID.ToString().Trim().ToLower().Contains(s.Trim().ToLower()));
            }).ContinueWith(task =>
            {
                //add the results to the source collection
                foreach (DAL.MedNames result in task.Result)
                    _results.Add(result);

            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }


        public bool ViewPharmaceuticalList { get; set; }
        public string MedName { get; set; } = "ac";
        public string MedID { get; set; } = "";
        


       

    }


    /// <summary>
    /// Interaction logic for FarmCycle.xaml
    /// </summary>
    public partial class FarmCycle : UserControl
    {

        FooterTotal FooterTotalClass = new FooterTotal();

        //دالة من خلال يتمم تصفير جميع المجاميع الخاصة بكل جدول
        void ClearTotalFooter()
        {
            FooterTotalClass.TotalBirdsCost = DAL.PassParameter.BirdsList.Sum(i => i.TotalCost);

            FooterTotalClass.TotalBirdsQty = DAL.PassParameter.BirdsList.Sum(i => i.BirdCount);

            FooterTotalClass.CountEmployeeQty = DAL.PassParameter.EmployeesList.Count();


            FooterTotalClass.TotalSalary = DAL.PassParameter.EmployeesList.Sum(i => i.Salary);

            FooterTotalClass.TotalBirdsDeadQty = DAL.PassParameter.BirdsDead.Sum(i => i.BirdsDeadCount);

            FooterTotalClass.TotalFeedersQty = DAL.PassParameter.Feeders.Sum(i => i.FeederCount);

            FooterTotalClass.TotalFeedersCost = DAL.PassParameter.Feeders.Sum(i => i.TotalCost);

            FooterTotalClass.TotalWaterQTY = DAL.PassParameter.Waters.Sum(i => i.WaterCount);

            FooterTotalClass.TotalWaterCost = DAL.PassParameter.Waters.Sum(i => i.TotalCost);

            FooterTotalClass.TotalCarpentrysQty = DAL.PassParameter.Carpentrys.Sum(i => i.CarpentryCount);

            FooterTotalClass.TotalCarpentrysCost = DAL.PassParameter.Carpentrys.Sum(i => i.TotalCost);

            FooterTotalClass.TotalElectricityCost = DAL.PassParameter.Electricity.Sum(i => i.E_Cost);

            FooterTotalClass.TotalMaintenanceCost = DAL.PassParameter.Maintenance.Sum(i => i.MaintenanceCost);

            FooterTotalClass.TotalMiscellaneousCost = DAL.PassParameter.Miscellaneous.Sum(i => i.MiscellaneousCost);

            FooterTotalClass.TotalPharmaceuticalQty = DAL.PassParameter.Pharmaceutical.Sum(i => i.PharmaceuticalQty);

            FooterTotalClass.TotalPharmaceuticalCost = DAL.PassParameter.Pharmaceutical.Sum(i => i.TotalCost);

            FooterTotalClass.TotalGas_CylinderCost = DAL.PassParameter.Gas_Cylinder.Sum(i => i.Gas_CylinderCost);

            FooterTotalClass.TotalGas_LiquidCost = DAL.PassParameter.Gas_Liquid.Sum(i => i.Gas_LiquidCost);

            FooterTotalClass.TotalFuelCost = DAL.PassParameter.Fuel.Sum(i => i.FuelCost);







        }
        public FarmCycle()
        {
            InitializeComponent();

            Farms_LoadedAsync();

            CycleDataview.Visibility = Visibility.Collapsed;

            DataContext = FooterTotalClass;

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
                              DateEnter = (DateTime)FarmsCyclesTBL.DateEnter,
                              DateStart = (DateTime)FarmsCyclesTBL.DateStart,
                              DateEnd = (DateTime)FarmsCyclesTBL.DateEnd,
                              FarmName = FarmsTBL.FarmName,
                              CycleClose = FarmsCyclesTBL.CycleClose,
                              FarmSupervisor = FarmsCyclesTBL.FarmSupervisor

                          };






            DatagridCycle.ItemsSource = results.ToList().OrderBy(i => i.CycleID);


            txtEmployeename.Text = txtBirdNumber.Text = txtBirdDead.Text = txtFeederCount.Text = txtWaterCount.Text = txtCarpentryCount.Text = txtFarmSupervisor.Text = "";

           

           
        }



        void ClearData()
        {

            txtEmployeename.Text = txtBirdNumber.Text = txtBirdDead.Text = txtFeederCount.Text = txtWaterCount.Text = txtCarpentryCount.Text = txtFarmSupervisor.Text = "";


            //txtEmployeeState.SelectedIndex = -1;


            txtEmployeeSalary.Text = txtCostBird.Text = txtCostDead.Text =
                txtCostWater.Text = txtCostFeeder.Text = txtCostCarpentry.Text =
                txtElectricityCost.Text = txtElectricityNote.Text = txtMaintenanceCost.Text =
                txtMaintenanceNote.Text = txtMiscellaneousCost.Text = txtMiscellaneousNote.Text
                = txtFuelCost.Text = txtFuelNote.Text = txtGas_CylinderCost.Text = txtGas_CylinderNote.Text =
                txtGas_LiquidCost.Text = txtGas_LiquidNote.Text = txtPharmaceuticalName.Text =
                txtPharmaceuticalQTY.Text = txtPharmaceuticalCostPrice.Text = txtPharmaceuticalNote.Text

                = "";
        }

        private void AddNewCycle_Click(object sender, RoutedEventArgs e)
        {

            InputLanguageManager.SetInputLanguage(txtFarmSupervisor, System.Globalization.CultureInfo.CreateSpecificCulture("ar"));
            btnCloseCycle.Visibility = Visibility.Collapsed;
            ExtraData.SelectedIndex = 0;

            ClearData();




            CycleDataview.Visibility = Visibility.Visible;

            Header.Text = "بداية دورة جديدة";

            SaveData.Content = "بداية دورة جديدة";
            ExtraData.IsEnabled = false;

            txtCycleStrID.Text = ""; FarmName.SelectedIndex = -1;

            DAL.PassParameter.EmployeesList = new ObservableCollection<Tables.Employees>();
            DAL.PassParameter.BirdsList = new ObservableCollection<Tables.Birds>();
            DAL.PassParameter.BirdsDead = new ObservableCollection<Tables.BirdsDead>();
            DAL.PassParameter.Feeders = new ObservableCollection<Tables.Feeders>();
            DAL.PassParameter.Waters = new ObservableCollection<Tables.Waters>();
            DAL.PassParameter.Carpentrys = new ObservableCollection<Tables.Carpentrys>();
            DAL.PassParameter.Maintenance = new ObservableCollection<Tables.Maintenance>();
            DAL.PassParameter.Electricity = new ObservableCollection<Tables.Electricity>();
            DAL.PassParameter.Miscellaneous = new ObservableCollection<Tables.Miscellaneous>();
            DAL.PassParameter.Fuel = new ObservableCollection<Tables.Fuel>();
            DAL.PassParameter.Gas_Cylinder = new ObservableCollection<Tables.Gas_Cylinder>();
            DAL.PassParameter.Gas_Liquid = new ObservableCollection<Tables.Gas_Liquid>();
            DAL.PassParameter.Pharmaceutical = new ObservableCollection<Tables.Pharmaceutical>();

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

            ExtraData.SelectedIndex = 0;

            btnCloseCycle.Visibility = Visibility.Visible;

            txtFarmSupervisor.Text = Check.FarmSupervisor;

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
            txtDateStartCycle.SelectDate = SelectedFarmsCycle.DateStart;

           


            //عرض رقم الدورة
            txtCycleStrID.Text = SelectedFarmsCycle.FarmStrNumber;

            //عرض اسم المزرعة
            FarmName.Text = SelectedFarmsCycle.FarmName;

            Header.Text = "تعديل بيانات الدورة";

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




            //جلب بيانات الكهرباء المدخلين سابقا على الدورة
            var DataElectricity = await new DAL.Database()._database.Table<Tables.Electricity>().Where(i => i.cycleID == Check.CycleID).OrderBy(i => i.ElectricityID).ToListAsync();

            DAL.PassParameter.Electricity = new ObservableCollection<Tables.Electricity>(DataElectricity);

            //ترتيب بيانات الكهرباء المدخلين سابقا
            ListElectricity.ItemsSource = DAL.PassParameter.Electricity;



            //جلب بيانات الصيانة المدخلين سابقا على الدورة
            var DataMaintenance = await new DAL.Database()._database.Table<Tables.Maintenance>().Where(i => i.cycleID == Check.CycleID).OrderBy(i => i.MaintenanceID).ToListAsync();

            DAL.PassParameter.Maintenance = new ObservableCollection<Tables.Maintenance>(DataMaintenance);

            //ترتيب بيانات الصيانة المدخلين سابقا
            ListMaintenance.ItemsSource = DAL.PassParameter.Maintenance;



            //جلب بيانات المتفرقة المدخلين سابقا على الدورة
            var DataMiscellaneous = await new DAL.Database()._database.Table<Tables.Miscellaneous>().Where(i => i.cycleID == Check.CycleID).OrderBy(i => i.MiscellaneousID).ToListAsync();

            DAL.PassParameter.Miscellaneous = new ObservableCollection<Tables.Miscellaneous>(DataMiscellaneous);

            //ترتيب بيانات المتفرقة المدخلين سابقا
            ListMiscellaneous.ItemsSource = DAL.PassParameter.Miscellaneous;



            //جلب بيانات الديزل المدخلين سابقا على الدورة
            var DataFuel = await new DAL.Database()._database.Table<Tables.Fuel>().Where(i => i.cycleID == Check.CycleID).OrderBy(i => i.FuelID).ToListAsync();

            DAL.PassParameter.Fuel = new ObservableCollection<Tables.Fuel>(DataFuel);

            //ترتيب بيانات الديزل المدخلين سابقا
            ListFuel.ItemsSource = DAL.PassParameter.Fuel;


            //جلب بيانات الغاز السائل المدخلين سابقا على الدورة
            var DataGas_Liquid = await new DAL.Database()._database.Table<Tables.Gas_Liquid>().Where(i => i.cycleID == Check.CycleID).OrderBy(i => i.Gas_LiquidID).ToListAsync();

            DAL.PassParameter.Gas_Liquid = new ObservableCollection<Tables.Gas_Liquid>(DataGas_Liquid);

            //ترتيب بيانات الغاز السائل المدخلين سابقا
            ListGas_Liquid.ItemsSource = DAL.PassParameter.Gas_Liquid;



            //جلب بيانات جرار الغاز المدخلين سابقا على الدورة
            var DataGas_Cylinder = await new DAL.Database()._database.Table<Tables.Gas_Cylinder>().Where(i => i.cycleID == Check.CycleID).OrderBy(i => i.Gas_CylinderID).ToListAsync();

            DAL.PassParameter.Gas_Cylinder = new ObservableCollection<Tables.Gas_Cylinder>(DataGas_Cylinder);

            //ترتيب بيانات جرار الغاز المدخلين سابقا
            ListGas_Cylinder.ItemsSource = DAL.PassParameter.Gas_Cylinder;




            //جلب بيانات الادوية المدخلين سابقا على الدورة
            var DataPharmaceutical = await new DAL.Database()._database.Table<Tables.Pharmaceutical>().Where(i => i.cycleID == Check.CycleID).OrderBy(i => i.PharmaceuticalID).ToListAsync();

            DAL.PassParameter.Pharmaceutical = new ObservableCollection<Tables.Pharmaceutical>(DataPharmaceutical);

            //ترتيب بيانات الادوية المدخلين سابقا
            ListPharmaceutical.ItemsSource = DAL.PassParameter.Pharmaceutical;



            ClearTotalFooter();

            //عرض الواجهة
            CycleDataview.Visibility = Visibility.Visible;

            txtFarmSupervisor.Focus();
        }


      

        private async void SaveData_Click(object sender, RoutedEventArgs e)
        {

            if (FarmName.SelectedItem == null)
            {
                new Pages.MessageBoxWindows("الرجاء اختيار اسم المزرعة").ShowDialog();
                FarmName.IsDropDownOpen = true;

                return;
            }
            if (txtFarmSupervisor.Text == "")
            {
                new Pages.MessageBoxWindows("الرجاء ادخال اسم مشرف المزرعة").ShowDialog();
                InputLanguageManager.SetInputLanguage(txtFarmSupervisor, System.Globalization.CultureInfo.CreateSpecificCulture("ar"));
                txtFarmSupervisor.Focus();
                return;
            }

            if (FarmName.SelectedItem != null)
            {
                Tables.FarmsCycle farmsCycle;




                if (UpdateMode == true)
                {
                    if (FarmName.SelectedItem != null)
                    {
                        var data = (Tables.Farms)FarmName.SelectedItem;

                        DateTime CycleEndDateTime = new DateTime(
                            DateTime.Parse(txtDateEndCycle.SelectDate.ToString()).Year,
                            DateTime.Parse(txtDateEndCycle.SelectDate.ToString()).Month,
                            DateTime.Parse(txtDateEndCycle.SelectDate.ToString()).Day,
                          DateTime.Now.Hour,
                            DateTime.Now.Minute,
                             DateTime.Now.Second);





                        farmsCycle = new Tables.FarmsCycle
                        {
                            CycleID = SelectedFarmsCycle.CycleID,
                            FarmID = data.FarmID,
                            FarmStrNumber = txtCycleStrID.Text,
                            DateStart = DAL.PassParameter.GetDateWithCurrentTime(txtDateStartCycle.SelectDate),
                            CycleClose = (bool)btnCloseCycle.IsChecked ? true : false,
                            DateEnd = (bool)btnCloseCycle.IsChecked ? CycleEndDateTime : new DateTime(1, 1, 1),
                            DateEnter = SelectedFarmsCycle.DateEnter,
                            FarmSupervisor = txtFarmSupervisor.Text
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



                        //حذف بيانات الكهرباء السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteElectricityAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات الكهرباء الجديدة
                        await new DAL.Database("").SaveElectricityAsync(DAL.PassParameter.Electricity.ToList());



                        //حذف بيانات الصيانة السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteMaintenanceAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات الصيانة الجديدة
                        await new DAL.Database("").SaveMaintenanceAsync(DAL.PassParameter.Maintenance.ToList());


                        //حذف بيانات المتفرقة السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteMiscellaneousAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات المتفرقة الجديدة
                        await new DAL.Database("").SaveMiscellaneousAsync(DAL.PassParameter.Miscellaneous.ToList());



                        //حذف بيانات الديزل السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteFuelAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات الديزل الجديدة
                        await new DAL.Database("").SaveFuelAsync(DAL.PassParameter.Fuel.ToList());


                        //حذف بيانات جرار الغاز السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteGas_CylinderAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات جرار الغاز الجديدة
                        await new DAL.Database("").SaveGas_CylinderAsync(DAL.PassParameter.Gas_Cylinder.ToList());



                        //حذف بيانات الغاز السائل السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeleteGas_LiquidAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات الغاز السائل  الجديدة
                        await new DAL.Database("").SaveGas_LiquidAsync(DAL.PassParameter.Gas_Liquid.ToList());




                        //حذف بيانات الادوية السابقة من اجل ادخال البياناتا لجديدة
                        await new DAL.Database("").DeletePharmaceuticalAsync(SelectedFarmsCycle.CycleID);

                        //ادخال بيانات الادوية  الجديدة
                        await new DAL.Database("").SavePharmaceuticalAsync(DAL.PassParameter.Pharmaceutical.ToList());


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
                    DateStart = DAL.PassParameter.GetDateWithCurrentTime(txtDateStartCycle.SelectDate),
                    FarmSupervisor = txtFarmSupervisor.Text
                };





                await new DAL.Database("").SaveCycleAsync(farmsCycle);



                CycleDataview.Visibility = Visibility.Collapsed;



                Farms_LoadedAsync();

            }




        }

        private void EmployeeAdd_Click(object sender, RoutedEventArgs e)
        {



            if (txtEmployeename.Text == "")
            {
                new Pages.MessageBoxWindows("خطا في الادخال", "الرجاء ادخال اسم العامل").ShowDialog();
                txtEmployeename.Focus();
                return;
            }

            else if (txtEmployeeState.SelectedIndex == -1)
            {
                new Pages.MessageBoxWindows("الرجاء اختيار حالة العامل").ShowDialog();
                txtEmployeeState.IsDropDownOpen = true;
                return;
            }




            else if (DAL.Validations.IsDate(txtDateadd.SelectedDate.Value.ToString()) == false)
            {
                new Pages.MessageBoxWindows("الرجاء ادخال تاريخ الاضافة بشكل صحيح بشكل كافي").ShowDialog();


                return;
            }
            else if (DAL.Validations.IsDate(txtDateRemove.SelectedDate.Value.ToString()) == false)
            {
                new Pages.MessageBoxWindows("الرجاء ادخال تاريخ الخروج بشكل صحيح بشكل كافي").ShowDialog();

                return;
            }
            if (txtEmployeeSalary.Text != "")
            {
                if (DAL.Validations.IsDouble(txtEmployeeSalary.Text) == false)
                {
                    new Pages.MessageBoxWindows("الرجاء ادخال راتب العامل بشكل صحيح").ShowDialog();
                    txtEmployeeSalary.Focus();
                    return;
                }
            }


            if (UpdateEmployee)
            {

                DAL.PassParameter.EmployeesList[EditEmployeeIndex] = new Tables.Employees
                {
                    cycleID = SelectedEmployee.cycleID,
                    FarmID = SelectedEmployee.FarmID,
                    EmployeeID = SelectedEmployee.EmployeeID,
                    EmployeeName = txtEmployeename.Text,
                    DateAdd = DAL.PassParameter.GetDateWithCurrentTime(txtDateadd.SelectedDate.Value),
                    DateRemove = DAL.PassParameter.GetDateWithCurrentTime(txtDateRemove.SelectedDate.Value),
                    State = txtEmployeeState.Text,
                    Salary = DAL.Validations.IsDouble(txtEmployeeSalary.Text) ? double.Parse(txtEmployeeSalary.Text) : 0

                };

                EmployeeAdd.Content = "اضافة";

                txtEmployeename.Text = txtEmployeeState.Text = txtEmployeeSalary.Text = "";
               

                EmployeeList.ItemsSource = DAL.PassParameter.EmployeesList.OrderBy(i => i.EmployeeID);
                UpdateEmployee = false;

                ClearTotalFooter();

                return;
            }


            DAL.PassParameter.EmployeesList.Add(new Tables.Employees
            {
                EmployeeID = Guid.NewGuid(),
                EmployeeName = txtEmployeename.Text,
                DateAdd = DateTime.Parse(txtDateadd.Text),
                DateRemove = DateTime.Parse(txtDateRemove.Text),
                State = txtEmployeeState.Text,
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                Salary = DAL.Validations.IsDouble(txtEmployeeSalary.Text) ? double.Parse(txtEmployeeSalary.Text) : 0
            });

            txtEmployeename.Text = txtEmployeeState.Text = txtEmployeeSalary.Text = "";
            txtEmployeeState.SelectedIndex = -1;


            ClearTotalFooter();


        }

        private void btnAddBird_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtBirdNumber.Text == "")
            {
                new Pages.MessageBoxWindows("الرجاء ادخال عدد الصوص").ShowDialog();
                txtBirdNumber.Focus();
                return;
            }
            else if (txtCostBird.Text == "")
            {
                new Pages.MessageBoxWindows("الرجاء ادخال سعر كلفة الصوص").ShowDialog();
                txtCostBird.Focus();
                return;
            }
            else if (DAL.Validations.IsDouble(txtBirdNumber.Text) == false)
            {
                new Pages.MessageBoxWindows("الرجاء ادخال عدد الصوص بشكل صحيح").ShowDialog();
                txtBirdNumber.Focus();

                return;
            }
            else if (DAL.Validations.IsDouble(txtCostBird.Text) == false)
            {
                new Pages.MessageBoxWindows("الرجاء ادخال سعر كلفة الصوص بشكل صحيح").ShowDialog();
                txtCostBird.Focus();

                return;
            }

            DAL.PassParameter.BirdsList.Add(new Tables.Birds
            {
                BirdID = Guid.NewGuid(),
                BirdCount = double.Parse(txtBirdNumber.Text),
                DateAdd = DateTime.Parse(txtBridDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                CostPrice = double.Parse(txtCostBird.Text),
                TotalCost = (double.Parse(txtBirdNumber.Text) * double.Parse(txtCostBird.Text))

            });

            txtBirdNumber.Text = txtCostBird.Text = "";


            BirdList.ItemsSource = DAL.PassParameter.BirdsList;

            ClearTotalFooter();



        }


       
            

        private void btnBirdDead_Click(object sender, RoutedEventArgs e)
        {
            if (txtBirdDead.Text == "")
            {
                MessageBox.Show("الرجاء ادخال عدد الوفيات");
                return;
            }
            else if (txtCostDead.Text == "")
            {
                MessageBox.Show("الرجاء ادخال سعر كلفة الصوص");
                return;
            }
            else if (DAL.Validations.IsDouble(txtBirdDead.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال عدد الوفيات بشكل صحيح");
                return;
            }
            else if (DAL.Validations.IsDouble(txtCostDead.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال سعر كلفة الصوص بشكل صحيح");
                return;
            }
            DAL.PassParameter.BirdsDead.Add(new Tables.BirdsDead
            {
                BirdsDeadID = Guid.NewGuid(),
                BirdsDeadCount = double.Parse(txtBirdDead.Text),
                DateAdd = DateTime.Parse(txtbirddeadDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                CostPrice = double.Parse(txtCostDead.Text),
                TotalCost = (double.Parse(txtBirdDead.Text) * double.Parse(txtCostDead.Text))

            });

            txtBirdDead.Text = txtCostDead.Text = "";


            BirdDeadList.ItemsSource = DAL.PassParameter.BirdsDead;

            ClearTotalFooter();
        }

        private void btnFeederAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtFeederCount.Text == "")
            {
                MessageBox.Show("الرجاء ادخال عدد العلف");
                return;
            }
            if (txtFeederType.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء اختيار نوع العلف");
                return;
            }
            else if (txtCostFeeder.Text == "")
            {
                MessageBox.Show("الرجاء ادخال سعر كلفة العلف");
                return;
            }
            else if (DAL.Validations.IsDouble(txtFeederCount.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال عدد العلف بشكل صحيح");
                return;
            }
            else if (DAL.Validations.IsDouble(txtCostFeeder.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال سعر كلفة العلف بشكل صحيح");
                return;
            }
            DAL.PassParameter.Feeders.Add(new Tables.Feeders
            {
                FeederID = Guid.NewGuid(),
                FeederCount = double.Parse(txtFeederCount.Text),
                DateAdd = DateTime.Parse(txtbirddeadDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                FeederType = txtFeederType.Text,
                CostPrice = double.Parse(txtCostFeeder.Text),
                TotalCost = (double.Parse(txtFeederCount.Text) * double.Parse(txtCostFeeder.Text))

            });

            txtFeederCount.Text = txtCostFeeder.Text = "";
            txtFeederType.SelectedIndex = -1;


            ListFeeders.ItemsSource = DAL.PassParameter.Feeders;

            ClearTotalFooter();
        }

        private void btnAddWater_Click(object sender, RoutedEventArgs e)
        {
            if (txtWaterCount.Text == "")
            {
                MessageBox.Show("الرجاء ادخال عدد المياه");
                return;
            }
            else if (txtCostWater.Text == "")
            {
                MessageBox.Show("الرجاء ادخال سعر كلفة المياه");
                return;
            }
            else if (DAL.Validations.IsDouble(txtWaterCount.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال عدد المياه بشكل صحيح");
                return;
            }
            else if (DAL.Validations.IsDouble(txtCostWater.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال سعر كلفة المياه بشكل صحيح");
                return;
            }
            DAL.PassParameter.Waters.Add(new Tables.Waters
            {
                WaterID = Guid.NewGuid(),
                WaterCount = double.Parse(txtWaterCount.Text),
                DateAdd = DateTime.Parse(txtbirddeadDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                CostPrice = double.Parse(txtCostWater.Text),
                TotalCost = (double.Parse(txtWaterCount.Text) * double.Parse(txtCostWater.Text))

            });

            txtWaterCount.Text = txtCostWater.Text = "";


            ListWaters.ItemsSource = DAL.PassParameter.Waters;

            ClearTotalFooter();
        }

        private void btnCarpentryAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtCarpentryCount.Text == "")
            {
                MessageBox.Show("الرجاء ادخال عدد النجارة");
                return;
            }
            else if (txtCostCarpentry.Text == "")
            {
                MessageBox.Show("الرجاء ادخال سعر كلفة النجارة");
                return;
            }
            else if (DAL.Validations.IsDouble(txtCarpentryCount.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال عدد النجارة بشكل صحيح");
                return;
            }
            else if (DAL.Validations.IsDouble(txtCostCarpentry.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال سعر كلفة النجارة بشكل صحيح");
                return;
            }
            DAL.PassParameter.Carpentrys.Add(new Tables.Carpentrys
            {
                CarpentryID = Guid.NewGuid(),
                CarpentryCount = double.Parse(txtCarpentryCount.Text),
                DateAdd = DateTime.Parse(txtCarpentryDate.Text),
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                CarpentryType = "شوال",
                CostPrice = double.Parse(txtCostCarpentry.Text),
                TotalCost = (double.Parse(txtCarpentryCount.Text) * double.Parse(txtCostCarpentry.Text))

            });

            txtCarpentryCount.Text=txtCostCarpentry.Text = "";


            ListCarpentrys.ItemsSource = DAL.PassParameter.Carpentrys;

            ClearTotalFooter();
        }
        private void btnAddElectricity_Click(object sender, RoutedEventArgs e)
        {
            if (txtElectricityCost.Text == "")
            {
                MessageBox.Show("الرجاء ادخال كلفة الكهرباء");
                return;
            }
            else if (txtElectricityNote.Text == "")
            {
                MessageBox.Show("الرجاء ادخال بيان كلفة الكهرباء");
                return;
            }
            else if (DAL.Validations.IsDouble(txtElectricityCost.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال كلفة الكهرباء بشكل صحيح");
                return;
            }

            DAL.PassParameter.Electricity.Add(new Tables.Electricity
            {
                ElectricityID = Guid.NewGuid(),
                E_Cost = double.Parse(txtElectricityCost.Text),
                Notes = txtElectricityNote.Text,
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                DateAdd = DateTime.Parse(txtElectricityDate.Text)


            });

            txtElectricityCost.Text = txtElectricityNote.Text = "";


            ListElectricity.ItemsSource = DAL.PassParameter.Electricity;

            ClearTotalFooter();
        }

        private void btnAddMaintenance_Click(object sender, RoutedEventArgs e)
        {
            if (txtMaintenanceCost.Text == "")
            {
                MessageBox.Show("الرجاء ادخال كلفة الصيانة");
                return;
            }
            else if (txtMaintenanceNote.Text == "")
            {
                MessageBox.Show("الرجاء ادخال بيان كلفة الصيانة");
                return;
            }
            else if (DAL.Validations.IsDouble(txtMaintenanceCost.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال كلفة الصيانة بشكل صحيح");
                return;
            }

            DAL.PassParameter.Maintenance.Add(new Tables.Maintenance
            {
                MaintenanceID = Guid.NewGuid(),
                MaintenanceCost = double.Parse(txtMaintenanceCost.Text),
                Notes = txtMaintenanceNote.Text,
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                DateAdd = DateTime.Parse(txtMaintenanceDate.Text)


            });

            txtMaintenanceCost.Text = txtMaintenanceNote.Text = "";


            ListMaintenance.ItemsSource = DAL.PassParameter.Maintenance;

            ClearTotalFooter();
        }

        private void btnAddMiscellaneousCost_Click(object sender, RoutedEventArgs e)
        {
            if (txtMiscellaneousCost.Text == "")
            {
                MessageBox.Show("الرجاء ادخال كلفة المتفرقة");
                return;
            }
            else if (txtMiscellaneousNote.Text == "")
            {
                MessageBox.Show("الرجاء ادخال بيان كلفة المتفرقة");
                return;
            }
            else if (DAL.Validations.IsDouble(txtMiscellaneousCost.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال كلفة المتفرقة بشكل صحيح");
                return;
            }

            DAL.PassParameter.Miscellaneous.Add(new Tables.Miscellaneous
            {
                MiscellaneousID = Guid.NewGuid(),
                MiscellaneousCost = double.Parse(txtMiscellaneousCost.Text),
                Notes = txtMiscellaneousNote.Text,
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                DateAdd = DateTime.Parse(txtMiscellaneousDate.Text)


            });

            txtMiscellaneousCost.Text = txtMiscellaneousNote.Text = "";


            ListMiscellaneous.ItemsSource = DAL.PassParameter.Miscellaneous;

            ClearTotalFooter();
        }

        private void FuelCLickManage(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;





            switch (button.FontFamily.ToString())
            {
                #region Fuel
                case "Fuel":

                    if (txtFuelCost.Text == "")
                    {
                        MessageBox.Show("الرجاء ادخال كلفة الديزل");
                        return;
                    }
                    else if (txtFuelNote.Text == "")
                    {
                        MessageBox.Show("الرجاء ادخال بيان كلفة الديزل");
                        return;
                    }
                    else if (DAL.Validations.IsDouble(txtFuelCost.Text) == false)
                    {
                        MessageBox.Show("الرجاء ادخال كلفة الديزل بشكل صحيح");
                        return;
                    }

                    DAL.PassParameter.Fuel.Add(new Tables.Fuel
                    {
                        FuelID = Guid.NewGuid(),
                        FuelCost = double.Parse(txtFuelCost.Text),
                        Notes = txtFuelNote.Text,
                        FarmID = SelectedFarmsCycle.FarmID,
                        cycleID = SelectedFarmsCycle.CycleID,
                        DateAdd = DateTime.Parse(txtFuelDate.Text)


                    });

                    txtFuelCost.Text = txtFuelNote.Text = "";

                    ListFuel.ItemsSource = DAL.PassParameter.Fuel;


                    break;
                #endregion

                #region Gas_Cylinder
                case "Gas_Cylinder":



                    if (txtGas_CylinderCost.Text == "")
                    {
                        MessageBox.Show("الرجاء ادخال كلفة جرار الغاز");
                        return;
                    }
                    else if (txtGas_CylinderNote.Text == "")
                    {
                        MessageBox.Show("الرجاء ادخال بيان كلفة جرار الغاز");
                        return;
                    }
                    else if (DAL.Validations.IsDouble(txtGas_CylinderCost.Text) == false)
                    {
                        MessageBox.Show("الرجاء ادخال كلفة جرار الغاز بشكل صحيح");
                        return;
                    }

                    DAL.PassParameter.Gas_Cylinder.Add(new Tables.Gas_Cylinder
                    {
                        Gas_CylinderID = Guid.NewGuid(),
                        Gas_CylinderCost = double.Parse(txtGas_CylinderCost.Text),
                        Notes = txtGas_CylinderNote.Text,
                        FarmID = SelectedFarmsCycle.FarmID,
                        cycleID = SelectedFarmsCycle.CycleID,
                        DateAdd = DateTime.Parse(txtGas_CylinderDate.Text)


                    });

                    txtGas_CylinderCost.Text = txtGas_CylinderNote.Text = "";

                    ListGas_Cylinder.ItemsSource = DAL.PassParameter.Gas_Cylinder;



                    break;

                #endregion

                #region Gas_Liquid

                case "Gas_Liquid":

                    if (txtGas_LiquidCost.Text == "")
                    {
                        MessageBox.Show("الرجاء ادخال كلفة الغاز السائل");
                        return;
                    }
                    else if (txtGas_LiquidNote.Text == "")
                    {
                        MessageBox.Show("الرجاء ادخال بيان كلفة الغاز السائل");
                        return;
                    }
                    else if (DAL.Validations.IsDouble(txtGas_LiquidCost.Text) == false)
                    {
                        MessageBox.Show("الرجاء ادخال كلفة الغاز السائل بشكل صحيح");
                        return;
                    }

                    DAL.PassParameter.Gas_Liquid.Add(new Tables.Gas_Liquid
                    {
                        Gas_LiquidID = Guid.NewGuid(),
                        Gas_LiquidCost = double.Parse(txtGas_LiquidCost.Text),
                        Notes = txtGas_LiquidNote.Text,
                        FarmID = SelectedFarmsCycle.FarmID,
                        cycleID = SelectedFarmsCycle.CycleID,
                        DateAdd = DateTime.Parse(txtGas_LiquidDate.Text)


                    });

                    txtGas_LiquidCost.Text = txtGas_LiquidNote.Text = "";

                    ListGas_Liquid.ItemsSource = DAL.PassParameter.Gas_Liquid;
                    break;

                    #endregion



            }
            ClearTotalFooter();

        }


        private void btnAddPharmaceutical_Click(object sender, RoutedEventArgs e)
        {
            if (txtPharmaceuticalName.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم الدواء");
                return;
            }
            else if (txtPharmaceuticalQTY.Text == "")
            {
                MessageBox.Show("الرجاء ادخال كمية الدواء");
                return;
            }
            else if (txtPharmaceuticalCostPrice.Text == "")
            {
                MessageBox.Show("الرجاء ادخال كلفة الدواء");
                return;
            }

            else if (DAL.Validations.IsDouble(txtPharmaceuticalQTY.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال كمية الدواء بشكل صحيح");
                return;
            }
            else if (DAL.Validations.IsDouble(txtPharmaceuticalCostPrice.Text) == false)
            {
                MessageBox.Show("الرجاء ادخال كلفة الدواء بشكل صحيح");
                return;
            }


           




            DAL.PassParameter.Pharmaceutical.Add(new Tables.Pharmaceutical
            {
                PharmaceuticalID = Guid.NewGuid(),
                DateAdd = txtPharmaceuticalDate.SelectedDate.Value,
                FarmID = SelectedFarmsCycle.FarmID,
                cycleID = SelectedFarmsCycle.CycleID,
                CostPrice = double.Parse(txtPharmaceuticalCostPrice.Text),
                PharmaceuticalQty = double.Parse(txtPharmaceuticalQTY.Text),
                TotalCost = (double.Parse(txtPharmaceuticalCostPrice.Text) * double.Parse(txtPharmaceuticalQTY.Text)),
                PharmaceuticalNote = txtPharmaceuticalNote.Text,
                MedID = FooterTotalClass.SelectedMed.MedID,
                MedName = FooterTotalClass.SelectedMed.MedName

            });

            txtPharmaceuticalName.Text = txtPharmaceuticalQTY.Text = txtPharmaceuticalCostPrice.Text = txtPharmaceuticalNote.Text = "";

            MedNames = new DAL.MedNames();


            ListPharmaceutical.ItemsSource = DAL.PassParameter.Pharmaceutical;

            ClearTotalFooter();
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


                if (SelectedFarmsCycle != null)
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



        //متغير يتم حفظ بداخله رقم التسلسل للموظف من اجل تعديله
        int EditEmployeeIndex = 0;
        bool UpdateEmployee = false;

        Tables.Employees SelectedEmployee = new Tables.Employees();

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;


            string Message = "هل تريد الحذف ؟";

            if (SelectedFarmsCycle.CycleClose)
            {
                button.IsEnabled = false;
            }

            else if (SelectedFarmsCycle.CycleClose == false)
            {
                switch (button.FontFamily.ToString())
                {
                    case "Employees":
                        var Employees = button.CommandParameter as Tables.Employees;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.EmployeesList.Remove(Employees);

                            EmployeeList.ItemsSource = DAL.PassParameter.EmployeesList.OrderBy(i => i.EmployeeID);

                           

                        }

                        break;
                    case "EditEmployees":
                        Employees = button.CommandParameter as Tables.Employees;

                        EditEmployeeIndex = DAL.PassParameter.EmployeesList.IndexOf(Employees);


                        txtEmployeename.Text = Employees.EmployeeName;
                        txtEmployeeState.Text = Employees.State;
                        txtDateadd.Text = Employees.DateAdd.ToString("M/dd/yyyy");
                        txtDateRemove.Text = Employees.DateAdd.ToString("M/dd/yyyy");
                        txtEmployeeSalary.Text = Employees.Salary.ToString();


                        UpdateEmployee = true;
                        EmployeeAdd.Content = "تعديل";

                        SelectedEmployee = Employees;

                      

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
                    case "Electricity":
                        var Electricity = button.CommandParameter as Tables.Electricity;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Electricity.Remove(Electricity);

                            ListElectricity.ItemsSource = DAL.PassParameter.Electricity;
                        }

                        break;

                    case "Maintenance":
                        var Maintenance = button.CommandParameter as Tables.Maintenance;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Maintenance.Remove(Maintenance);

                            ListMaintenance.ItemsSource = DAL.PassParameter.Maintenance;
                        }

                        break;
                    case "Miscellaneous":
                        var Miscellaneous = button.CommandParameter as Tables.Miscellaneous;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Miscellaneous.Remove(Miscellaneous);

                            ListMiscellaneous.ItemsSource = DAL.PassParameter.Miscellaneous;
                        }

                        break;
                    case "Fuel":
                        var Fuel = button.CommandParameter as Tables.Fuel;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Fuel.Remove(Fuel);

                            ListFuel.ItemsSource = DAL.PassParameter.Fuel;
                        }

                        break;
                    case "Gas_Cylinder":
                        var Gas_Cylinder = button.CommandParameter as Tables.Gas_Cylinder;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Gas_Cylinder.Remove(Gas_Cylinder);

                            ListGas_Cylinder.ItemsSource = DAL.PassParameter.Gas_Cylinder;
                        }

                        break;
                    case "Gas_Liquid":
                        var Gas_Liquid = button.CommandParameter as Tables.Gas_Liquid;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Gas_Liquid.Remove(Gas_Liquid);

                            ListGas_Liquid.ItemsSource = DAL.PassParameter.Gas_Liquid;
                        }
                        break;

                    case "Pharmaceutical":
                        var Pharmaceutical = button.CommandParameter as Tables.Pharmaceutical;
                        if (MessageBox.Show(Message, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            DAL.PassParameter.Pharmaceutical.Remove(Pharmaceutical);

                            ListPharmaceutical.ItemsSource = DAL.PassParameter.Pharmaceutical;
                        }


                        break;


                }

                ClearTotalFooter();
            }








        }

        DAL.MedNames MedNames = new DAL.MedNames();
        private void txtPharmaceuticalName_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());
            //return;
          
            if (e.Key == Key.OemQuestion && Keyboard.IsKeyDown(Key.RightShift))
            {
                
              
                FooterTotalClass.ViewPharmaceuticalList = true;
                e.Handled = true;
            }

            return;
            if (e.Key == Key.Enter)
            {
                if (txtPharmaceuticalName.Text == "")
                {
                    new Pages.MessageBoxWindows("الرجاء ادخال رقم الدواء").ShowDialog();
                    return;
                }

                else if (DAL.Validations.IsDouble(txtPharmaceuticalName.Text) == false)
                {
                    new Pages.MessageBoxWindows("الرجاء ادخال رقم الدواء بشكل صحيح").ShowDialog();
                    return;
                }
                //var query = new DAL.Queries().MedNames.Where(i => i.MedID == double.Parse(txtPharmaceuticalName.Text));
                //if (query.Count() > 0)
                //{
                //    MedNames = query.FirstOrDefault();
                //    txtPharmaceuticalName.Text = MedNames.MedName;
                //    txtPharmaceuticalQTY.Focus();
                //}

            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }
    }
}
