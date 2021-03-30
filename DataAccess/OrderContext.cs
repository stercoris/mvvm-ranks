using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Models;
using System;
using System.IO;

namespace Order.DataAccess
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            this.Database.Migrate();
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(Path.Combine(path, "order.db")))
            {
                File.Create(Path.Combine(path, "order.db"));
            }
            options.UseSqlite("Data Source=" + Path.Combine(path, "order.db") + ";");
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
    }
}
