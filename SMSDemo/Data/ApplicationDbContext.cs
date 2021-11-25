using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSDemo.Data;
using SMSDemo.Models;

namespace SMSDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Salles>  Salles { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Banke> Bankes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sallary> Sallaries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Addmission> Addmissions { get; set; }
    }
}
