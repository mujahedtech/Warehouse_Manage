﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Manage.Tables;

namespace Warehouse_Manage.DAL
{
   public class Database
    {



        //return new SQLiteAsyncConnection("MujahedTech.db3");

        public readonly SQLiteAsyncConnection _database;


        public static string Path = "MujahedTech.db3";
        public Database(string dbpath = "")
        {
            dbpath = Path;
            _database = new SQLiteAsyncConnection(dbpath);



            

            _database.CreateTableAsync<Tables.Farms>();
            _database.CreateTableAsync<Tables.FarmsCycle>();
            _database.CreateTableAsync<Tables.Employees>();
            _database.CreateTableAsync<Tables.Birds>();
            _database.CreateTableAsync<Tables.BirdsDead>();
            _database.CreateTableAsync<Tables.Feeders>();
            _database.CreateTableAsync<Tables.Waters>();
            _database.CreateTableAsync<Tables.Carpentrys>();
            _database.CreateTableAsync<Tables.Electricity>();
            _database.CreateTableAsync<Tables.Maintenance>();
            _database.CreateTableAsync<Tables.Miscellaneous>();
            _database.CreateTableAsync<Tables.Fuel>();
            _database.CreateTableAsync<Tables.Gas_Cylinder>();
            _database.CreateTableAsync<Tables.Gas_Liquid>();
            _database.CreateTableAsync<Tables.Pharmaceutical>();

        }

        #region Farms

        public Task<List<Tables.Farms>> GetFarms()
        {

            return _database.Table<Tables.Farms>().ToListAsync();
        }


        public Task<int> SaveFarmAsync(Tables.Farms farms)
        {
            return _database.InsertAsync(farms);

        }

        public Task<int> UpdateFarmAsync(Tables.Farms farms)
        {
            return _database.UpdateAsync(farms);

        }
        #endregion



        #region Cycle

        //Query Using Linq
        public Task<List<Tables.FarmsCycle>> GetFarmsCycles_Linq()
        {

            return _database.Table<Tables.FarmsCycle>().Where(i => i.CycleID == 1).ToListAsync();
        }

        public Task<List<Tables.FarmsCycle>> GetFarmsCycles()
        {

            return _database.Table<Tables.FarmsCycle>().ToListAsync();
        }
        public Task<int> SaveCycleAsync(Tables.FarmsCycle farmsCycle)
        {
            return _database.InsertAsync(farmsCycle);

        }
        public Task<int> UpdateFarmsCycleAsync(Tables.FarmsCycle farmsCycle)
        {
            return _database.UpdateAsync(farmsCycle);

        }
        #endregion



        #region Employee


        public Task<int> SaveEmployeeAsync(List<Tables.Employees> employees)
        {
            return _database.InsertAllAsync(employees);

        }

        public Task<List<Tables.Employees>> DeleteEmployeeAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Employees>($"delete from Employees where cycleID={CycleID}");

        }

        #endregion


        #region Birds


        public Task<int> SaveBirdAsync(List<Tables.Birds> birds)
        {
            return _database.InsertAllAsync(birds);

        }
        public Task<List<Tables.Birds>> DeleteBirdAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Birds>($"delete from Birds where cycleID={CycleID}");

        }
        #endregion


        #region BirdsDead


        public Task<int> SaveBirdsDeadAsync(List<Tables.BirdsDead> birdsDeads)
        {
            return _database.InsertAllAsync(birdsDeads);

        }
        public Task<List<Tables.BirdsDead>> DeleteBirdsDeadAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.BirdsDead>($"delete from BirdsDead where cycleID={CycleID}");

        }
        #endregion


        #region Feeders


        public Task<int> SaveFeedersAsync(List<Tables.Feeders> feeders)
        {
            return _database.InsertAllAsync(feeders);

        }
        public Task<List<Tables.Feeders>> DeleteFeedersAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Feeders>($"delete from Feeders where cycleID={CycleID}");

        }
        #endregion


        #region Waters


        public Task<int> SaveWatersAsync(List<Tables.Waters> waters)
        {
            return _database.InsertAllAsync(waters);

        }
        public Task<List<Tables.Waters>> DeleteWatersAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Waters>($"delete from Waters where cycleID={CycleID}");

        }
        #endregion


        #region Carpentrys


        public Task<int> SaveCarpentrysAsync(List<Tables.Carpentrys> carpentrys)
        {
            return _database.InsertAllAsync(carpentrys);

        }
        public Task<List<Tables.Carpentrys>> DeleteCarpentrysAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Carpentrys>($"delete from Carpentrys where cycleID={CycleID}");

        }
        #endregion


        #region Electricity

        public Task<int> SaveElectricityAsync(List<Tables.Electricity> electricity)
        {
            return _database.InsertAllAsync(electricity);

        }
        public Task<List<Tables.Electricity>> DeleteElectricityAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Electricity>($"delete from Electricity where cycleID={CycleID}");

        }

        #endregion

        #region Maintenance

        public Task<int> SaveMaintenanceAsync(List<Tables.Maintenance> electricity)
        {
            return _database.InsertAllAsync(electricity);

        }
        public Task<List<Tables.Maintenance>> DeleteMaintenanceAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Maintenance>($"delete from Maintenance where cycleID={CycleID}");

        }



        #endregion


        #region Miscellaneous

        public Task<int> SaveMiscellaneousAsync(List<Tables.Miscellaneous> Miscellaneous)
        {
            return _database.InsertAllAsync(Miscellaneous);

        }
        public Task<List<Tables.Miscellaneous>> DeleteMiscellaneousAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Miscellaneous>($"delete from Miscellaneous where cycleID={CycleID}");

        }

        #endregion


        #region Fuel

        public Task<int> SaveFuelAsync(List<Tables.Fuel> Fuel)
        {
            return _database.InsertAllAsync(Fuel);

        }
        public Task<List<Tables.Fuel>> DeleteFuelAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Fuel>($"delete from Fuel where cycleID={CycleID}");

        }

        #endregion



        #region Gas_Cylinder

        public Task<int> SaveGas_CylinderAsync(List<Tables.Gas_Cylinder> Gas_Cylinder)
        {
            return _database.InsertAllAsync(Gas_Cylinder);

        }
        public Task<List<Tables.Gas_Cylinder>> DeleteGas_CylinderAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Gas_Cylinder>($"delete from Gas_Cylinder where cycleID={CycleID}");

        }

        #endregion

        #region Gas_Liquid

        public Task<int> SaveGas_LiquidAsync(List<Tables.Gas_Liquid> Gas_Liquid)
        {
            return _database.InsertAllAsync(Gas_Liquid);

        }
        public Task<List<Tables.Gas_Liquid>> DeleteGas_LiquidAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Gas_Liquid>($"delete from Gas_Liquid where cycleID={CycleID}");

        }

       
        #endregion


        #region Pharmaceutical

        public Task<int> SavePharmaceuticalAsync(List<Tables.Pharmaceutical> Pharmaceutical)
        {
            return _database.InsertAllAsync(Pharmaceutical);

        }
        public Task<List<Tables.Pharmaceutical>> DeletePharmaceuticalAsync(int CycleID)
        {
            return _database.QueryAsync<Tables.Pharmaceutical>($"delete from Pharmaceutical where cycleID={CycleID}");

        }

        #endregion



        #region Reports


       
        #endregion




    }
}
