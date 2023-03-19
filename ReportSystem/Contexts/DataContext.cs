using ReportSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hannah\Documents\EC-Utbildning\ecutb-datalagring-assignment\ReportSystem\Contexts\sql_datab.mdf;Integrated Security=True;Connect Timeout=30";
        #region contructors
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<TenantEntity> Tenants { get; set; } = null!;
        public DbSet<AddressEntity> Address { get; set; } = null!;
        public DbSet<ReportsEntity> Reports { get; set; } = null!;


    }
}
