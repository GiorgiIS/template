using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Repository.EF
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options) { }

        public DbSet<SomeTestEntity> SomeTestEntities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SomeTestEntity>().Property(p => p.SomeStringValue).HasMaxLength(50);
            modelBuilder.Entity<SomeTestEntity>().Property(p => p.SomeDateTimeValue).IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}
