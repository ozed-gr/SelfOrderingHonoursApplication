using Application.Repositories.MenuItemRepositories;
using Application.UseCases.MenuItemUseCases;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.HardCodedDataSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Instructions : IMenuItemRepository
    {
        //Here we will do the Entity Framework implementation
        EntityFrameworkDbContext context;

        HardCodeDataRepository dataSet;
        public Instructions()
        {
            //options = base.
            //context = new EntityFrameworkDbContext();
            dataSet = new HardCodeDataRepository();
        }

        public Task<MenuItem> Create(int p_id)
        {
            dataSet.Menu.Add(new MenuItem("newName", "newDesc", p_id));
            //throw new NotImplementedException();
            return Task.Run(() => dataSet.Menu.Last());
        }

        public Task<MenuItem> Execute(int p_id)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> GetAll()
        {
            MenuItem item = dataSet.Menu.First();
            //throw new NotImplementedException();
            return Task.Run(() => item);
        }

        public Task<MenuItem> GetById(int p_id)
        {
            //MenuItem item = dataSet.Menu.Where(_item => _item.Id == p_id).FirstOrDefault();
            MenuItem item = dataSet.Menu.ElementAt(p_id);  
            return Task.Run(() => item);
        }

        public Task<List<MenuItem>> GetMenuItemListByMenuType(string p_type)
        {
            throw new NotImplementedException();
        }
    }
}
