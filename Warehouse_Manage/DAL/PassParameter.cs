using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.DAL
{

    public class Validations
    {
        public static bool IsNumeric(string input)
        {
            decimal test = 0;
            return decimal.TryParse(input, out test);
        }


        public static bool IsDate(string input)
        {
            DateTime test;
            return DateTime.TryParse(input, out test);
        }


        public static bool IsDouble(string input)
        {
            double test;
            return double.TryParse(input, out test);
        }

        public static bool Isdecimal(string input)
        {
            decimal test;
            return decimal.TryParse(input, out test);
        }
    }


    class PassParameter
    {

        public static ObservableCollection<Tables.Farms> FarmsList { get; set; } = new ObservableCollection<Tables.Farms>();


        public static ObservableCollection<Tables.Employees> EmployeesList { get; set; } = new ObservableCollection<Tables.Employees>();
        public static ObservableCollection<Tables.Birds> BirdsList { get; set; } = new ObservableCollection<Tables.Birds>();

        public static ObservableCollection<Tables.BirdsDead> BirdsDead { get; set; } = new ObservableCollection<Tables.BirdsDead>();
        public static ObservableCollection<Tables.Feeders> Feeders { get; set; } = new ObservableCollection<Tables.Feeders>();
        public static ObservableCollection<Tables.Waters> Waters { get; set; } = new ObservableCollection<Tables.Waters>();
        public static ObservableCollection<Tables.Carpentrys> Carpentrys { get; set; } = new ObservableCollection<Tables.Carpentrys>();

        public static ObservableCollection<Tables.Electricity> Electricity { get; set; } = new ObservableCollection<Tables.Electricity>();
        public static ObservableCollection<Tables.Maintenance> Maintenance { get; set; } = new ObservableCollection<Tables.Maintenance>();
        public static ObservableCollection<Tables.Miscellaneous> Miscellaneous { get; set; } = new ObservableCollection<Tables.Miscellaneous>();
        public static ObservableCollection<Tables.Fuel> Fuel { get; set; } = new ObservableCollection<Tables.Fuel>();





        public  static DateTime GetDateWithCurrentTime(DateTime dateTime)
        {

          return  new DateTime(
                             dateTime.Year,
                            dateTime.Month,
                            dateTime.Day,
                           DateTime.Now.Hour,
                             DateTime.Now.Minute,
                              DateTime.Now.Second);
        }


    }
}
