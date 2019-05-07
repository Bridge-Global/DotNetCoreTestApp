using System;
using System.Collections.Generic;
using System.Text;
using CoachAthlete.Data.Entities;
using CoachAthlete.Data.Repository;

namespace CoachAthlete.Data.UnitOfWork
{
    class UnitOfWork : IDisposable, IUnitOfWork
    {
        ApplicationDbContext _context;
 
        private ApplicationDbContext context
        {
            get { return _context; }
        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
    

        private GenericRepository<TestHeaderEntity> testHeaderEntityRepository;
        public GenericRepository<TestHeaderEntity> TestHeaderEntityRepository
        {
            get
            {
                if (testHeaderEntityRepository == null)
                    testHeaderEntityRepository = new GenericRepository<TestHeaderEntity>(context);
                return testHeaderEntityRepository;
            }
        }

        private GenericRepository<TestDetailEntity> testDetailEntityRepository;
        public GenericRepository<TestDetailEntity> TestDetailEntityRepository
        {
            get
            {
                if (testDetailEntityRepository == null)
                    testDetailEntityRepository = new GenericRepository<TestDetailEntity>(context);
                return testDetailEntityRepository;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
  
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 

    }
}
