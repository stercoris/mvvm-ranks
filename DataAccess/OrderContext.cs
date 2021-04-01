using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Models;
using System;
using System.IO;

namespace Order.DataAccess
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
        {
            this.Database.Migrate();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory; // TODO: Наверное это и не работает в релизе?
            string dbPath = Path.Combine(path, Config.DBName);
            options.UseSqlite("Data Source=" + dbPath + ";");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Group);

            modelBuilder.Entity<Rank>()
                .HasMany(r => r.Students)
                .WithOne(s => s.Rank);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
