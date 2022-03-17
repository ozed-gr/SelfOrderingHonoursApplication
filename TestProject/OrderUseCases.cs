using Application.DTOs;
using Application.UseCases.OrderUseCases;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class OrderUseCases : InMemorySqliteDb
    {
        private static AutoMapperProfiles profiles = new AutoMapperProfiles();
        private static AutoMapperConfig _mapper = new AutoMapperConfig(profiles);

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        public void GetSaucesForMenuItem(MenuItemDTO p_menuItem)
        {
            //In-memory mock database
            var options = new DbContextOptionsBuilder<EntityFrameworkDbContext>().UseInMemoryDatabase("MenuItemSauces").Options;
            //EntityFramework context
            EntityFrameworkDbContext context = new EntityFrameworkDbContext(options);

            
        }


    }
}
