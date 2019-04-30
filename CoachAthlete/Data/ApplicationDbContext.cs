using System;
using System.Collections.Generic;
using System.Text;
using CoachAthlete.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoachAthlete.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TestHeader> TestHeaders { get; set; }
        public DbSet<TestDetail> TestDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
    }
}
