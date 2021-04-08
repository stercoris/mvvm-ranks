using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Models;
using System;
using System.IO;

namespace Order.DataAccess
{
    public class OrderContext : DbContext, IDisposable
    {
        public OrderContext(DbContextOptions<OrderContext> options)
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory; // TODO: Наверное это и не работает в релизе?

            #if DEBUG
                string dbPath = Path.Combine(path, "..\\..\\..\\..\\DataAccess\\order.db");
            #else
                string dbPath = Path.Combine(path, Config.DBName);
            #endif

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

        public override void Dispose()
        {
            this.SaveChanges();
            base.Dispose();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
