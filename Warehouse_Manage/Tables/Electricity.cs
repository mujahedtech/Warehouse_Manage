using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    public class Electricity
    {

        public Guid ElectricityID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }

        public double E_Cost { get; set; }
        public DateTime DateAdd { get; set; }

        public string Notes { get; set; }

     



    }
}
