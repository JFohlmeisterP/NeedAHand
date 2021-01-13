using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Reflection;

namespace NeedAHand.Domain.Infra

{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// To manually add a new migration, from solution folder run the following command changing <MigrationName> by your migration name
        /// dotnet ef migrations add <MigrationName> --startup-project NeedAHand --project Domain
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString")
                ?? "Data Source=db;User Id=sa;PWD=some(!)Password;Initial Catalog=NeedAHand"; //fallback connection to manually add migrations
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
        }
    }

}


