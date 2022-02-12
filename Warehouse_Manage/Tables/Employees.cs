using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
    class Employees
    {

        public Guid EmployeeID { get; set; }
        public int cycleID { get; set; }
        public int FarmID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateRemove { get; set; }
        public string State { get; set; }

    }
}
