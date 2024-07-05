using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.Tables
{
   public class Farms
    {
        [PrimaryKey, AutoIncrement]
        public int FarmID { get; set; }
        public Guid FarmIDGuid { get; set; }
        public string FarmName { get; set; }
        public DateTime DateEnter { get; set; }
      



    }
}
