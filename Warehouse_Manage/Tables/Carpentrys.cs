using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    class Carpentrys
    {

        public Guid CarpentryID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }
        public double CarpentryCount { get; set; }
        public DateTime DateAdd { get; set; }

    }
}
