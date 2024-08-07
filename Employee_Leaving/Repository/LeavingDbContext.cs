﻿using Employee_Leaving.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;

namespace Employee_Leaving.Repository
{
    public class LeavingDbContext : DbContext
    {
        public LeavingDbContext()
        {

        }
        public LeavingDbContext(DbContextOptions<LeavingDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Leave_Type> LeaveTypes { get; set; }
        public DbSet<Roll> Roll { get; set; }
    }
}
