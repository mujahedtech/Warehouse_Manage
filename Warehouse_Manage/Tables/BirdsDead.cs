﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{

    //هذا جدول مختص بعدد الصوص وفيات يومي
   public class BirdsDead
    {

        public Guid BirdsDeadID { get; set; }
        public int FarmID { get; set; }
        public int cycleID { get; set; }
        public double BirdsDeadCount { get; set; }
        public DateTime DateAdd { get; set; }

        public double CostPrice { get; set; }

        public double TotalCost { get; set; }

    }
}
