using System;
using System.Collections.Generic;
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

using System.Runtime.CompilerServices;
using System.Printing;

namespace Warehouse_Manage.Reports
{

    public class ReportContent
    {
        public int index { get; set; }
        public string Header { get; set; }
        public double QTY { get; set; }
        public double Cost { get; set; }
        public double Total { get; set; }
        public double Percent { get; set; }

    }

    public class MVVMReport:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FarmName { get; set; }
        public string CycleName { get; set; }

        public string SuperVisorName { get; set; }
        public string EmployeeNumber { get; set; }





        public double BirdDeadQTY { get; set; }

        public string BirdDate { get; set; }
        public double BirdQTY { get; set; }
        public double BirdCost { get; set; }

        public double BirdCostTotal { get; set; }

        public double TotalExpense { get; set; }


        public List<ReportContent> reportContents = new List<ReportContent>();



        public double SalesQty { get; set; }
        public double SalesDinar { get; set; }

        public bool ViewSales { get; set; }

    }



    /// <summary>
    /// Interaction logic for MainReport.xaml
    /// </summary>
    public partial class MainReport : UserControl
    {
        MVVMReport mVVMReport = new MVVMReport();


        public static MainReport Main { set; get; } = new MainReport();
        public MainReport()
        {
            InitializeComponent();

            Farms_LoadedAsync();

            Main = this;

            oldReport.Visibility = Visibility.Visible;
            NewReport.Visibility = Visibility.Collapsed;


        }

      
      

        //var DataBirds = await new DAL.Database()._database.QueryAsync<Tables.Birds>("select * from Birds");
        private async void Farms_LoadedAsync()
        {
            ComboFarms.ItemsSource = await new DAL.Database("").GetFarms();








            return;



        }





        private async void ComboFarms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (ComboFarms.SelectedItem != null)
            {
                var FarmsSelected = (Tables.Farms)ComboFarms.SelectedItem;

                var ListNumberCycle = await new DAL.Database()._database.Table<Tables.FarmsCycle>().Where(i => i.FarmID == FarmsSelected.FarmID).ToListAsync();




                ComboCycleNumber.ItemsSource = ListNumberCycle;
                ComboCycleNumber.IsEnabled = true;
                if (ListNumberCycle.Count == 0)
                {
                    ComboCycleNumber.IsEnabled = false;
                }
                return;
            }

            ComboCycleNumber.IsEnabled = false;



        }


        Tables.FarmsCycle SelectedCycle = new Tables.FarmsCycle();
        private void ComboCycleNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboCycleNumber.SelectedItem != null)
            {
                SelectedCycle = (Tables.FarmsCycle)ComboCycleNumber.SelectedItem;
               


            }
        }



        List<Tables.BirdsDead> DeadList { get; set; }
        List<Tables.Birds> BirdsList { get; set; }
        List<Tables.Employees> EmployeesList { get; set; }
        List<Tables.Feeders> FeedersList;
        List<Tables.Waters> WatersList;
        List<Tables.Carpentrys> CarpentrysList;
        List<Tables.Fuel> FuelList;
        List<Tables.Gas_Cylinder> Gas_CylinderList;
        List<Tables.Gas_Liquid> Gas_LiquidList;
        List<Tables.Electricity> ElectricityList;
        List<Tables.Maintenance> MaintenanceList;
        List<Tables.Miscellaneous> MiscellaneousList;
        List<Tables.Pharmaceutical> PharmaceuticalList;





        double TotalExpense = 0;
        private async void btnStartReports_Click(object sender, RoutedEventArgs e)
        {

            DeadList = await new DAL.Database()._database.Table<Tables.BirdsDead>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            BirdsList = await new DAL.Database()._database.Table<Tables.Birds>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            EmployeesList = await new DAL.Database()._database.Table<Tables.Employees>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            FeedersList = await new DAL.Database()._database.Table<Tables.Feeders>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            WatersList = await new DAL.Database()._database.Table<Tables.Waters>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            CarpentrysList = await new DAL.Database()._database.Table<Tables.Carpentrys>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            FuelList = await new DAL.Database()._database.Table<Tables.Fuel>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            Gas_CylinderList = await new DAL.Database()._database.Table<Tables.Gas_Cylinder>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            Gas_LiquidList = await new DAL.Database()._database.Table<Tables.Gas_Liquid>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            ElectricityList = await new DAL.Database()._database.Table<Tables.Electricity>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            MaintenanceList = await new DAL.Database()._database.Table<Tables.Maintenance>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            MiscellaneousList = await new DAL.Database()._database.Table<Tables.Miscellaneous>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();
            PharmaceuticalList = await new DAL.Database()._database.Table<Tables.Pharmaceutical>().Where(i => i.FarmID == SelectedCycle.FarmID && i.cycleID == SelectedCycle.CycleID).ToListAsync();







            oldReport.Visibility = Visibility.Collapsed;
            NewReport.Visibility = Visibility.Visible;

            var FarmsSelected = (Tables.Farms)ComboFarms.SelectedItem;

            mVVMReport.FarmName = FarmsSelected.FarmName;
            mVVMReport.CycleName = SelectedCycle.FarmStrNumber;
            mVVMReport.SuperVisorName = SelectedCycle.FarmSupervisor;
            mVVMReport.EmployeeNumber = EmployeesList.Count().ToString();
            mVVMReport.BirdDeadQTY = DeadList.Sum(i=>i.BirdsDeadCount);
            mVVMReport.BirdDate = BirdsList.FirstOrDefault().DateAdd.ToString("yyyy/MM/dd");

            mVVMReport.BirdQTY = BirdsList.Sum(i => i.BirdCount);
            mVVMReport.BirdCostTotal = BirdsList.Sum(i => i.TotalCost);

            TotalExpense =
               BirdsList.Sum(i => i.TotalCost) +
               FeedersList.Sum(i => i.TotalCost) +
               PharmaceuticalList.Sum(i => i.TotalCost) +
               Gas_LiquidList.Sum(i => i.Gas_LiquidCost) +
               Gas_CylinderList.Sum(i => i.Gas_CylinderCost) +
               FuelList.Sum(i => i.FuelCost) +
               EmployeesList.Sum(i => i.Salary) +
               WatersList.Sum(i => i.TotalCost) +
               CarpentrysList.Sum(i => i.TotalCost) +
               MiscellaneousList.Sum(i => i.MiscellaneousCost) +
               MaintenanceList.Sum(i => i.MaintenanceCost) +
               ElectricityList.Sum(i => i.E_Cost);


            mVVMReport.TotalExpense = TotalExpense;


            mVVMReport.SalesQty = 122665;
            mVVMReport.SalesDinar = 141717;


            DataContext = mVVMReport;




            GenerateTable();


            //ViewReports();
        }


        List<ReportContent> report = new List<ReportContent>();
        void GenerateTable()
        {
            


          

           


            report.Add(new ReportContent { index=0, Header = "صوص", QTY = BirdsList.Sum(i => i.BirdCount), Cost = 0, Total = BirdsList.Sum(i => i.TotalCost),Percent= BirdsList.Sum(i => i.TotalCost)/ TotalExpense });

            report.Add(new ReportContent { index = 1, Header = "اعلاف", QTY = FeedersList.Sum(i => i.FeederCount), Cost = 0, Total = FeedersList.Sum(i => i.TotalCost), Percent = FeedersList.Sum(i => i.TotalCost) / TotalExpense });

            report.Add(new ReportContent { index = 2, Header = "ادوية", QTY = PharmaceuticalList.Sum(i => i.PharmaceuticalQty), Cost = 0, Total = PharmaceuticalList.Sum(i => i.TotalCost), Percent = PharmaceuticalList.Sum(i => i.TotalCost) / TotalExpense });

            report.Add(new ReportContent { index = 3, Header = "غاز سائل", QTY = 0, Cost = 0, Total = Gas_LiquidList.Sum(i => i.Gas_LiquidCost), Percent = Gas_LiquidList.Sum(i => i.Gas_LiquidCost) / TotalExpense });

            report.Add(new ReportContent { index = 4, Header = "غاز جرار", QTY = 0, Cost = 0, Total = Gas_CylinderList.Sum(i => i.Gas_CylinderCost), Percent = Gas_CylinderList.Sum(i => i.Gas_CylinderCost) / TotalExpense });

            report.Add(new ReportContent { index = 5, Header = "محروقات", QTY = 0, Cost = 0, Total = FuelList.Sum(i => i.FuelCost), Percent = FuelList.Sum(i => i.FuelCost) / TotalExpense });

            report.Add(new ReportContent { index = 6, Header = "رواتب", QTY =EmployeesList.Count(), Cost = 0, Total = EmployeesList.Sum(i => i.Salary), Percent = EmployeesList.Sum(i => i.Salary) / TotalExpense });

            report.Add(new ReportContent { index = 7, Header = "مياه", QTY = WatersList.Sum(i => i.WaterCount), Cost = 0, Total = WatersList.Sum(i => i.TotalCost), Percent = WatersList.Sum(i => i.TotalCost) / TotalExpense });

            report.Add(new ReportContent { index = 8, Header = "نجارة", QTY = CarpentrysList.Sum(i => i.CarpentryCount), Cost = 0, Total = CarpentrysList.Sum(i => i.TotalCost), Percent = CarpentrysList.Sum(i => i.TotalCost) / TotalExpense });

            report.Add(new ReportContent { index = 9, Header = "متفرقة", QTY = 0, Cost = 0, Total = MiscellaneousList.Sum(i => i.MiscellaneousCost), Percent = MiscellaneousList.Sum(i => i.MiscellaneousCost) / TotalExpense });

            report.Add(new ReportContent { index = 10, Header = "صيانة", QTY = 0, Cost = 0, Total = MaintenanceList.Sum(i => i.MaintenanceCost), Percent = MaintenanceList.Sum(i => i.MaintenanceCost) / TotalExpense });

            report.Add(new ReportContent { index = 11, Header = "كهرباء", QTY = 0, Cost = 0, Total = ElectricityList.Sum(i => i.E_Cost), Percent = ElectricityList.Sum(i => i.E_Cost) / TotalExpense });

            report.Add(new ReportContent { index = 12, Header = "المجموع", QTY = 0, Cost = 0, Total = report.Sum(i=>i.Total) });

            report.Add(new ReportContent { index = 13, Header = "مبيعات", QTY = mVVMReport.SalesQty, Cost = 0, Total = mVVMReport.SalesDinar });

            report.Add(new ReportContent { index = 14, Header = "نسبة التحويل", QTY = mVVMReport.SalesQty, Cost = FeedersList.Sum(i => i.FeederCount), Total = mVVMReport.SalesQty / FeedersList.Sum(i => i.FeederCount) });

            report.Add(new ReportContent { index = 15, Header = "كلفة 1 كغم", QTY = mVVMReport.SalesQty, Cost = TotalExpense, Total = TotalExpense/ mVVMReport.SalesQty  });

            report.Add(new ReportContent { index = 16, Header = "معدل ادوية للطير", QTY = BirdsList.Sum(i => i.BirdCount), Cost = PharmaceuticalList.Sum(i => i.TotalCost), Total = PharmaceuticalList.Sum(i => i.TotalCost)/ BirdsList.Sum(i => i.BirdCount) });

            double totalgas = Gas_LiquidList.Sum(i => i.Gas_LiquidCost) + Gas_CylinderList.Sum(i => i.Gas_CylinderCost) + FuelList.Sum(i => i.FuelCost);

            report.Add(new ReportContent { index = 17, Header = "معدل غاز للطير", QTY = BirdsList.Sum(i => i.BirdCount), Cost = totalgas, Total = totalgas / BirdsList.Sum(i => i.BirdCount) });

            report.Add(new ReportContent { index = 18, Header = "معدل سعر بيع", QTY = mVVMReport.SalesQty, Cost = mVVMReport.SalesDinar, Total = mVVMReport.SalesDinar/ mVVMReport.SalesQty });

            report.Add(new ReportContent { index = 19, Header = "معدل نجارة", QTY = CarpentrysList.Sum(i => i.TotalCost), Cost = BirdsList.Sum(i => i.BirdCount), Total = CarpentrysList.Sum(i => i.TotalCost) / BirdsList.Sum(i => i.BirdCount) });

            report.Add(new ReportContent { index = 20, Header = "معدل علف", QTY = FeedersList.Sum(i => i.FeederCount), Cost = BirdsList.Sum(i => i.BirdCount), Total = FeedersList.Sum(i => i.FeederCount) / BirdsList.Sum(i => i.BirdCount) });

            report.Add(new ReportContent { index = 21, Header = "معدل كهرباء", QTY = ElectricityList.Sum(i => i.E_Cost), Cost = BirdsList.Sum(i => i.BirdCount), Total = ElectricityList.Sum(i => i.E_Cost) / BirdsList.Sum(i => i.BirdCount) });

            report.Add(new ReportContent { index = 22, Header = "معدل صيانة", QTY = MaintenanceList.Sum(i => i.MaintenanceCost), Cost = BirdsList.Sum(i => i.BirdCount), Total = MaintenanceList.Sum(i => i.MaintenanceCost) / BirdsList.Sum(i => i.BirdCount) });

            report.Add(new ReportContent { index = 23, Header = "معدل اجور عمال", QTY = EmployeesList.Sum(i => i.Salary), Cost = BirdsList.Sum(i => i.BirdCount), Total = EmployeesList.Sum(i => i.Salary) / BirdsList.Sum(i => i.BirdCount) });






            List1.ItemsSource = report.ToList();

        }



       

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (mVVMReport.ViewSales)
            {
                mVVMReport.ViewSales = false;

                //report.Remove(report.Where(i => i.Header == "مبيعات").FirstOrDefault()); //13

                //report.Remove(report.Where(i => i.Header == "كلفة 1 كغم").FirstOrDefault());//15

                //report.Remove(report.Where(i => i.Header == "نسبة التحويل").FirstOrDefault()); //14

                //report.Remove(report.Where(i => i.Header == "معدل سعر بيع").FirstOrDefault()); //18


                //"مبيعات"
                report[13].QTY = mVVMReport.SalesQty;
                report[13].Cost = 0;
                report[13].Total = mVVMReport.SalesDinar;


                //"نسبة التحويل"
                report[14].QTY = mVVMReport.SalesQty;
                report[14].Cost = FeedersList.Sum(i => i.FeederCount);
                report[14].Total = mVVMReport.SalesQty / FeedersList.Sum(i => i.FeederCount);
                report[14].Percent = mVVMReport.SalesQty / FeedersList.Sum(i => i.FeederCount);


                //"كلفة 1 كغم"
                report[15].QTY = mVVMReport.SalesQty;
                report[15].Cost = TotalExpense;
                report[15].Total = TotalExpense/ mVVMReport.SalesQty  ;
                report[15].Percent = mVVMReport.SalesQty / FeedersList.Sum(i => i.FeederCount);

                //"معدل سعر بيع"
                report[18].QTY = mVVMReport.SalesQty;
                report[18].Cost = mVVMReport.SalesDinar;
                report[18].Total = mVVMReport.SalesDinar / mVVMReport.SalesQty;


                //(new ReportContent { Header = "مبيعات", QTY = mVVMReport.SalesQty, Cost = 0, Total = mVVMReport.SalesDinar });


                //report.Add(new ReportContent { Header = "مبيعات", QTY = mVVMReport.SalesQty, Cost = 0, Total = mVVMReport.SalesDinar });


                //report.Add(new ReportContent { Header = "نسبة التحويل", QTY = mVVMReport.SalesQty, Cost = FeedersList.Sum(i => i.FeederCount), Total = mVVMReport.SalesQty / FeedersList.Sum(i => i.FeederCount) , Percent = mVVMReport.SalesQty / FeedersList.Sum(i => i.FeederCount) });


                //report.Add(new ReportContent { Header = "كلفة 1 كغم", QTY = mVVMReport.SalesQty, Cost = TotalExpense, Total = mVVMReport.SalesQty / TotalExpense, Percent = mVVMReport.SalesQty / FeedersList.Sum(i => i.FeederCount) });

                //report.Add(new ReportContent { Header = "معدل سعر بيع", QTY = mVVMReport.SalesQty, Cost = mVVMReport.SalesDinar, Total = mVVMReport.SalesDinar / mVVMReport.SalesQty });




                List1.ItemsSource = report.ToList();
            }


            else mVVMReport.ViewSales = true;
        }


      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var index = ((Button)e.Source).Content;

           


            switch (index)
            {
                case "مبيعات":

                    mVVMReport.ViewSales = true;

                    break;

                
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintQueue queue = new LocalPrintServer().GetPrintQueue(MainWindow.Main.txtPrinter.Text);

            printDialog.PrintQueue = queue;

            printDialog.PageRangeSelection = PageRangeSelection.AllPages;

            printDialog.PrintVisual(MainReport.Main.StackReport, "");
        }
    }
}
