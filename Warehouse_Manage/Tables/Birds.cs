using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{

    //هذا جدول خاص بعدد الصوص الي نزل على المزرعة
    class Birds
    {

        public Guid BirdID { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }
      
        public double BirdCount { get; set; }
        public DateTime DateAdd { get; set; }
       


    }
}
