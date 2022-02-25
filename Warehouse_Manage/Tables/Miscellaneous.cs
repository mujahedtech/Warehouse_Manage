using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    class Miscellaneous
    {

        public Guid MiscellaneousID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }

        public double MiscellaneousCost { get; set; }
        public DateTime DateAdd { get; set; }

        public string Notes { get; set; }

    }
}
