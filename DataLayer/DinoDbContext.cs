using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DinoDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Dinosaur> Dinosaurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Dinoshoppen; Trusted_Connection = True; ")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
            .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
        }
    }
}
