using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using CoachAthlete.Core.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Microsoft.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace CoachAthlete.Data.Base
{
    internal class BaseDal : IBaseDal
    {
        internal ApplicationDbContext applicationDbContext { get; }
        public DbContext Context { get; }
        private bool _isDisposed;
        public BaseDal(string connectionName)
        {
            var connStringSetting = ConfigurationManager.ConnectionStrings[connectionName];
            if (connStringSetting == null)
            {
                throw new ArgumentException("Connection string for database: " + connectionName + " is not found");
            }
            const string providerName = "System.Data.SqlClient";
            //var entityBuilder = new EntityConnectionStringBuilder
            //{
            //    Provider = providerName,
            //    ProviderConnectionString = connStringSetting.ConnectionString + ";MultipleActiveResultSets=True;App=EntityFramework",

            //    Metadata = @"res://*/Entities.StoreInEntityDataModel.csdl|res://*/Entities.StoreInEntityDataModel.ssdl|res://*/Entities.StoreInEntityDataModel.msl"
            //};
            //StoreInDbEntities = new StoreInDbEntities(entityBuilder.ToString());

            var connBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder
            {
                ConnectionString = connStringSetting.ConnectionString
            };

            DataSource = connBuilder.DataSource;
            InitialCatalog = connBuilder.InitialCatalog;
            UserID = connBuilder.UserID;
            Password = connBuilder.Password;
        }

        public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return applicationDbContext.Database.BeginTransaction(isolationLevel);
        }

        public void CommitTransaction(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public void DisableChangeTracking()
        {
            //applicationDbContext.Configuration.AutoDetectChangesEnabled = false;
            DisableAuditLog();
        }

        public void EnableChangeTracking()
        {
            //applicationDbContext.Configuration.AutoDetectChangesEnabled = true;
        }

        public void DetectChangesAndSave()
        {
            //applicationDbContext.Configuration.AutoDetectChangesEnabled = true;
            applicationDbContext.ChangeTracker.DetectChanges();
            applicationDbContext.SaveChanges();
        }

        public void EnableAuditLog()
        {
            //applicationDbContext.DisableAuditLog = false;
        }

        public void DisableAuditLog()
        {
            //applicationDbContext.DisableAuditLog = true;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                applicationDbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        //protected ObjectContext ObjectContext => ((IObjectContextAdapter)applicationDbContext).ObjectContext;

        public string DataSource { get; }

        public string InitialCatalog { get; }

        public string UserID { get; }

        public string Password { get; }
    }

}
