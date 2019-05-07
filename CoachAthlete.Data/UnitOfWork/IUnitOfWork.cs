using CoachAthlete.Data.Entities;
using CoachAthlete.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoachAthlete.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Save();
        GenericRepository<TestHeaderEntity> TestHeaderEntityRepository { get; }
        GenericRepository<TestDetailEntity> TestDetailEntityRepository { get; }
    }
}
