using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    class Waters
    {

        public Guid WaterID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }
        public double WaterCount { get; set; }
        public DateTime DateAdd { get; set; }
        public double CostPrice { get; set; }

        public double TotalCost { get; set; }


    }
}
