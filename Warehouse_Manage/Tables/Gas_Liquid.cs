using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    public class Gas_Liquid
    {

        public Guid Gas_LiquidID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }

        public double Gas_LiquidCost { get; set; }
        public DateTime DateAdd { get; set; }

        public string Notes { get; set; }


    }
}
