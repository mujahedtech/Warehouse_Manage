﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    public class FarmsCycle
    {

        [PrimaryKey, AutoIncrement]
        public int CycleID { get; set; }
        public Guid CycleIDGuid { get; set; }


      
        public int FarmID { get; set; }
        public string FarmStrNumber { get; set; }


        public DateTime DateEnter { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool CycleClose  { get; set; }

        public string FarmSupervisor { get; set; }


        



    }
}
