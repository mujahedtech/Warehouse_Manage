using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    class Fuel
    {
        public Guid FuelID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }

        public double FuelCost { get; set; }
        public DateTime DateAdd { get; set; }

        public string Notes { get; set; }

    }
}
