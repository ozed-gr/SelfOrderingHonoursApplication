using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework
{
    public class EntityFrameworkDbContext : DbContext
    {
        public EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Create a composite primary key
            modelBuilder.Entity<ItemIngredient>()
                .HasKey(ii => new { ii.MenuItemId, ii.IngredientId });

            //Create relationship between MenuItem and the joinTable ItemIngredient
            modelBuilder.Entity<ItemIngredient>()
                .HasOne(mi => mi.MenuItem)
                .WithMany(ii => ii.ItemIngredients)
                .HasForeignKey(mi => mi.MenuItemId);

            modelBuilder.Entity<ItemIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(ii => ii.ItemIngredients)
                .HasForeignKey(i => i.IngredientId);

            //Create a composite primary key for OrderItems
            modelBuilder.Entity<OrderItems>()
               .HasKey(ii => new { ii.MenuItemId, ii.OrderId });

            //Create relationship between MenuItem and the joinTable ItemIngredient
            modelBuilder.Entity<OrderItems>()
                .HasOne(o => o.Order)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(o => o.OrderId);


            modelBuilder.Entity<OrderItems>()
                .HasOne(i => i.MenuItem)
                .WithMany(ii => ii.OrderItems)
                .HasForeignKey(i => i.MenuItemId);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ItemIngredient> ItemIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }


    }
}
