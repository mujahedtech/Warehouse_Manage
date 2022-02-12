using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.DAL
{
    class PassParameter
    {

        public static ObservableCollection<Tables.Farms> FarmsList { get; set; } = new ObservableCollection<Tables.Farms>();


        public static ObservableCollection<Tables.Employees> EmployeesList { get; set; } = new ObservableCollection<Tables.Employees>();
        public static ObservableCollection<Tables.Birds> BirdsList { get; set; } = new ObservableCollection<Tables.Birds>();

        public static ObservableCollection<Tables.BirdsDead> BirdsDead { get; set; } = new ObservableCollection<Tables.BirdsDead>();
        public static ObservableCollection<Tables.Feeders> Feeders { get; set; } = new ObservableCollection<Tables.Feeders>();
        public static ObservableCollection<Tables.Waters> Waters { get; set; } = new ObservableCollection<Tables.Waters>();
        public static ObservableCollection<Tables.Carpentrys> Carpentrys { get; set; } = new ObservableCollection<Tables.Carpentrys>();




        static SQLiteAsyncConnection connection;
        public static SQLiteAsyncConnection _connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }
        public PassParameter()
        {


           


        }

    }
}
