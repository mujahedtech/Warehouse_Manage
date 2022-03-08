using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    class Pharmaceutical
    {

       
        public Guid PharmaceuticalID { get; set; }

        //في هذا الحقل يتم تخزين رقم الدواء و الذي هو بالاصل يعود\ الى جدول الادوية
        public double MedID { get; set; }
        public string MedName { get; set; }

        public int cycleID { get; set; }
        public int FarmID { get; set; }
        public double PharmaceuticalQty { get; set; }
        public DateTime DateAdd { get; set; }
        public double CostPrice { get; set; }

        public double TotalCost { get; set; }

        public string PharmaceuticalNote { get; set; }
    }
}
