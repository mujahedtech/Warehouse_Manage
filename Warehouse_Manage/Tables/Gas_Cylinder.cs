using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    class Gas_Cylinder
    {

        public Guid Gas_CylinderID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }

        public double Gas_CylinderCost { get; set; }
        public DateTime DateAdd { get; set; }

        public string Notes { get; set; }

    }
}
