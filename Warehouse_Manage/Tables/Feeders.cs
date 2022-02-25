using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    class Feeders
    {

        public Guid FeederID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }
        public double FeederCount { get; set; }
        public DateTime DateAdd { get; set; }
        public string FeederType { get; set; }
        public double CostPrice { get; set; }

        public double TotalCost { get; set; }


    }
}
