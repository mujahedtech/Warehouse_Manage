using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.DAL
{
    class Queries
    {

      public async Task<ObservableCollection<Tables.Farms>> GetFarms()
        {


            var Accounts = await  DAL.PassParameter._connection.Table<Tables.Farms>().ToListAsync();

            var _UsersAccounts = new ObservableCollection<Tables.Farms>(Accounts);



            return _UsersAccounts;
        }


    }
}
