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

        public Task<MenuItem> Create(int p_id)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> GetById(int p_id)
        {
            //throw new NotImplementedException();
            MenuItem menuItem = _dbContext.MenuItems.Find(p_id);
            return Task.FromResult(menuItem);
        }

        public Task<List<MenuItem>> GetMenuItemListByMenuType(string p_type)
        {
            var query = from t in _dbContext.MenuItems
                        where t.Category=="Starter"
                        select t;

            var result = query.ToList();

            return Task.FromResult(result);
        }
    }
}
