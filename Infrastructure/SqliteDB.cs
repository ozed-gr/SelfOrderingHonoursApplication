using Application.Repositories.Common;
using Application.Repositories.MenuItemRepositories;
using Domain.Entities;
using Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SqliteDB : IMenuItemRepository
    {
        private readonly EntityFrameworkDbContext _dbContext;

        public SqliteDB(EntityFrameworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(MenuItem p_menuItem)
        {
            if(p_menuItem != null)
            { 
                try
                {
                    _dbContext.MenuItems.Add(p_menuItem);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Task.CompletedTask;
        }

        public Task<MenuItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> GetById(int p_id)
        {
            //get menu item by id
            MenuItem menuItem = _dbContext.MenuItems.Find(p_id);
            //get menu item and ingredient relationship list
            var query = from t in _dbContext.ItemIngredients
                        where t.MenuItemId == p_id
                        select t;

            //list of ingredient ids that associate to the menu item
            var result = query.ToList();

            foreach(var i in result)
            {
                var query2 = from t in _dbContext.Ingredients
                             where t.Id == i.IngredientId
                             select t;
                var temp_result = query2.FirstOrDefault();
                i.Ingredient = temp_result;
            }

            //clean ItemIngredients
            menuItem.ItemIngredients = new List<ItemIngredient>();

            foreach (var item in result)
            {
                //get ingredient by ingredient_id 
                var ingr = _dbContext.Ingredients.First(a => a.Id == item.IngredientId);

                menuItem.ItemIngredients.Add(item);
            }

            return Task.FromResult(menuItem);
        }

        public Task<List<MenuItem>> GetListOfMenuItemWithSameMenuType(string p_type)
        {
            try
            {
                var query = from t in _dbContext.MenuItems
                            where t.Category == p_type
                            select t;

                var result = query.ToList();

                if (result.Count != 0) 
                { return Task.FromResult(result); }
            }
            catch (Exception)
            {

            }

            return Task.FromResult(new List<MenuItem>());
        }

        public Task<Sauce> GetMenuItemSauce(int p_sauceId)
        {
            var query = from t in _dbContext.Sauces
                        where t.Id == p_sauceId
                        select t;

            var result = query.First();

            return Task.FromResult(result);
        }

        public Task<List<MenuItemSauce>> GetMenuItemSauces(int p_menuItemId)
        {
            List<MenuItemSauce> result = new List<MenuItemSauce>();

            try
            {
                var query = from t in _dbContext.MenuItemSauces
                            join j in _dbContext.Sauces
                            on t.SauceId equals j.Id
                            where t.MenuItemId == p_menuItemId
                            select new MenuItemSauce
                            {
                                MenuItem = t.MenuItem,
                                MenuItemId = t.MenuItemId,
                                SauceId = t.SauceId,
                                Sauce = j,
                                Default = t.Default
                            };

                result = query.ToList();
            }
            catch (Exception)
            {
               result = new List<MenuItemSauce>();
            }

            return Task.FromResult(result);
        }
    }
}
