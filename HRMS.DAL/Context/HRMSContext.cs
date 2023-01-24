using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMS.BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
namespace HRMS.DAL.Context
{
    public class HRMSContext:DbContext
    {
        public HRMSContext(DbContextOptions<HRMSContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EmployeeCustomName>().HasNoKey();
        }
        public DbSet<Employee> Employee { get; set; }       
        public DbSet<DesignationMaster> DesignationMaster { get; set; }
        public DbSet<LeaveReasonMaster> LeaveReasonMaster { get; set; }
        public DbSet<EmployeeCustomName> EmpName { get; set; }
        public DbSet<NewsEventsMaster> NewsEventsMaster { get; set; }
        public DbSet<LeaveApplication> LeaveApplication { get; set; }
        public DbSet<HolidayMaster> HolidayMaster { get; set; }
        public DbSet<User> UserMaster { get; set; }
        //public DbSet<DashboardViewModel> DashboardViewModel { get; set; }
    }
}

