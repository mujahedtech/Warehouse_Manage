﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    public class Maintenance
    {
        public Guid MaintenanceID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }

        public double MaintenanceCost { get; set; }
        public DateTime DateAdd { get; set; }

        public string Notes { get; set; }

    }
}
