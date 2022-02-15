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
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ItemIngredient> ItemIngredients { get; set; }


    }
}
