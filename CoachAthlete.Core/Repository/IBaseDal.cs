using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;

namespace CoachAthlete.Core.Repository
{

    public interface IBaseDal : IDisposable
    {
        string DataSource { get; }
        string InitialCatalog { get; }
        string UserID { get; }
        string Password { get; }
        void SaveChanges();

        /// <summary>
        /// Disables tracking changes to the entities of the data context.
        /// This also disables audit logging on the data context.
        /// </summary>
        void DisableChangeTracking();

        /// <summary>
        /// Enables tracking changes to the entities of the data context.
        /// </summary>
        void EnableChangeTracking();

        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        void CommitTransaction(IDbContextTransaction transaction);
        void DetectChangesAndSave();

        /// <summary>
        /// Enables audit logging on the entities of the data context..
        /// </summary>
        void EnableAuditLog();

        /// <summary>
        /// Disables audit logging on the entities of the data context.
        /// </summary>
        void DisableAuditLog();
    }
}
