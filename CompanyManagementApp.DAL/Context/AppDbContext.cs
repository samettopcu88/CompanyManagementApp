using CompanyManagementApp.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApp.DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<ExpenseRequest> ExpenseRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Resume> Resumes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Identity tabanlı ilişkilere gerek yok

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<Employee>(e => e.UserId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LeaveRequests)
                .WithOne(lr => lr.Employee)
                .HasForeignKey(lr => lr.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ExpenseRequests)
                .WithOne(er => er.Employee)
                .HasForeignKey(er => er.EmployeeId);

            modelBuilder.Entity<LeaveRequest>()
                .HasMany(lr => lr.Notifications)
                .WithOne(n => n.LeaveRequest)
                .HasForeignKey(n => n.LeaveRequestId);

            modelBuilder.Entity<ExpenseRequest>()
                .HasMany(er => er.Notifications)
                .WithOne(n => n.ExpenseRequest)
                .HasForeignKey(n => n.ExpenseRequestId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Resume)
                .WithOne(r => r.Employee)
                .HasForeignKey<Resume>(r => r.EmployeeId);
        }
    }
}
