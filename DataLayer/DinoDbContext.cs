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

        public DbSet<Rabat> Rabats { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Dinoshoppen; Trusted_Connection = True; ")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
            .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasKey(dc => new { dc.DinosaurId, dc.CustomerId });

            modelBuilder.Entity<Promotion>()
                .Property(p => p.SoftDelete)
                .HasDefaultValue(false);

            modelBuilder.Entity<Rabat>()
                .Property(p => p.SoftDelete)
                .HasDefaultValue(false);

            modelBuilder.Entity<Diet>().HasData(
                new Diet { DietId = 1, DietName = "Carnivore" },
                new Diet { DietId = 2, DietName = "Herbivore" },
                new Diet { DietId = 3, DietName = "Omnivore" }
                );

            modelBuilder.Entity<Promotion>().HasData(
                new Promotion { PromotionId = 1, PromotionName = "Åbnings salg", PromotionRabat = 25}
                );

            modelBuilder.Entity<Dinosaur>().HasData(
                new Dinosaur { DinosaurId = 1, DinoName = "Tyrannosaurus Rex", DinoWeight = 14000, DinoLenght = 13, DinoHeight = 6.1, DinoPrice = 11650000, DietId = 1, PromotionId = 1 },
                new Dinosaur { DinosaurId = 2, DinoName = "Carnotaurus", DinoWeight = 3000, DinoLenght = 9, DinoHeight = 3, DinoPrice = 3500000, DietId = 1, PromotionId = 1 },
                new Dinosaur { DinosaurId = 3, DinoName = "Brontosaurus", DinoWeight = 15000, DinoLenght = 22, DinoHeight = 6, DinoPrice = 15000000, DietId = 2, PromotionId = 1 },
                new Dinosaur { DinosaurId = 4, DinoName = "Ornithomimus", DinoWeight = 170, DinoLenght = 3.8, DinoHeight = 4.5, DinoPrice = 365000, DietId = 3, PromotionId = 1 }
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Customer1", Address = "Sønderborgvej 1", Mail = "customer1@gmail.com"},
                new Customer { CustomerId = 2, Name = "Customer2", Address = "Sønderborgvej 2", Mail = "customer2@gmail.com" },
                new Customer { CustomerId = 3, Name = "Customer3", Address = "Sønderborgvej 3", Mail = "customer3@gmail.com" },
                new Customer { CustomerId = 4, Name = "Customer4", Address = "Sønderborgvej 4", Mail = "customer4@gmail.com" }
                );

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Mail)
                .IsUnique();

        }
    }
}
