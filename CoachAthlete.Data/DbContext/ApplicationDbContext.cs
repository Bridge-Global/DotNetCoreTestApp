using System;
using System.Collections.Generic;
using System.Text;
using CoachAthlete.Data.Entities;
using CoachAthlete.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoachAthlete.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        //const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ClientDb;Trusted_Connection=True;";
        public DbSet<TestHeaderEntity> TestHeaders { get; set; }
        public DbSet<TestDetailEntity> TestDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
    }
}
