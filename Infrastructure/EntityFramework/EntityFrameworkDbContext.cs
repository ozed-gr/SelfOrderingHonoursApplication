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
            //modelBuilder.Entity<OrderItems>()
            //   .HasKey(oi => new { oi.MenuItemId, oi.OrderId, oi.SauceId });
            modelBuilder.Entity<OrderItems>()
               .HasKey(oi => new { oi.OrderItemsId });

            //Create 1-to-many relationship between Order(1) and the joinTable OrderItems(M)
            //One Order has many OrderItems
            modelBuilder.Entity<OrderItems>()
                .HasOne(o => o.Order)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(o => o.OrderId);
            
            modelBuilder.Entity<OrderItems>()
                .HasOne(i => i.MenuItem)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(i => i.MenuItemId);

            modelBuilder.Entity<OrderItems>()
                .HasOne(i => i.Sauce)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(i => i.SauceId)
                .IsRequired(false);

            //Create a composite primary key for MenuItemSauce
            modelBuilder.Entity<MenuItemSauce>()
               .HasKey(mis => new { mis.MenuItemId, mis.SauceId});

            modelBuilder.Entity<MenuItemSauce>()
                .HasOne(i => i.Sauce)
                .WithMany(oi => oi.MenuItemSaucesCombination)
                .HasForeignKey(i => i.SauceId);

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ItemIngredient> ItemIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Table> Tables { get; set; }

        //Customisation
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<MenuItemSauce> MenuItemSauces { get; set; }



    }
}
