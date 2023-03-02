using GraphQLPractice.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GraphQLPractice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Gadget> Gadgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var gadgets = new List<Gadget>();

            for (int i = 0; i < 5; i++)
            {
                gadgets.Add(new Gadget
                {
                    Id = 1 + i,
                    Name = "Foo" + i,
                    Brand = "Bar" + i,
                    Price = 10 + i,
                    Type = "Dummy" + i
                });
            }

            modelBuilder.Entity<Gadget>().HasData(gadgets);
        }
    }
}
