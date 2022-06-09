using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Account)
                .WithOne(em => em.Employee)
                .HasForeignKey<Account>(em => em.NIK);

            modelBuilder.Entity<Account>()
               .HasOne(e => e.Profiling)
               .WithOne(em => em.Account)
               .HasForeignKey<Profiling>(e => e.NIK);

            modelBuilder.Entity<Profiling>()
                    .HasOne(e => e.Education)
                    .WithMany(em => em.Profiling);


            modelBuilder.Entity<Education>()
                  .HasOne(e => e.University)
                  .WithMany(em => em.Education);


            //Relasi Many to Many table Account dan tabel Role
            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.AccNIK, ar.RoleId });


            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Account)
                .WithMany(a => a.AccountRole)
                .HasForeignKey(ar => ar.AccNIK);


            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Role)
                .WithMany(r => r.AccountRole)
                .HasForeignKey(ar => ar.RoleId);


            /*modelBuilder.Entity<BookCategory>()
        .HasKey(bc => new { bc.BookId, bc.CategoryId });
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);*/

        }


        public DbSet<Employee> Employees      { get; set; }
        public DbSet<Account> Accounts        { get; set; }
        public DbSet<Profiling> Profilings    { get; set; }
        public DbSet<Education> Educations    { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Role> Roles              { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }


    }
}
