using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using Application.UseCases.Menu.Queries;
using Application.UseCases.MenuItemUseCases;
using AutoMapper;
using Domain.Entities;
using Infrastructure;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Xunit;

namespace TestProject
{

    public class DbTest : InMemorySqliteDb
    {
        //Check if the DbContext of EF can connect to the database
        [Fact]
        public void DbConnectionTest()
        {
            Assert.True(dbContext.Database.CanConnect());
        }
    }

    public class MenuUseCases : InMemorySqliteDb
    {
        private static AutoMapperProfiles profiles = new AutoMapperProfiles();
        private static AutoMapperConfig mapper = new AutoMapperConfig(profiles);

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetMenuItemByIdTest(int p_id)
        {
            //Arrange
                //Here we replicate the database with an empty instance in memory
                var options = new DbContextOptionsBuilder<EntityFrameworkDbContext>().UseInMemoryDatabase("MenuItems").Options;
            
                EntityFrameworkDbContext context = new EntityFrameworkDbContext(options);

                IMenuItemRepository menuItemRepository = new SqliteDB(context);

                IGetMenuItemById itemByIdUseCase = new GetMenuItemById(menuItemRepository, mapper._mapper);

                //Creating a record in memory 
                MenuItem menuItem = new MenuItem();
                menuItem.Id = p_id;
                menuItem.ItemIngredients = new List<ItemIngredient>();
                menuItem.OrderItems = new List<OrderItems>();
                //adding item to the db context
                context.MenuItems.Add(menuItem);

                //Mapping
                MenuItemDTO actualItem = new MenuItemDTO();
                actualItem.Id = p_id;

            //Act
                //Fetch the item from the in memory db
                var testItem = itemByIdUseCase.Execute(p_id);

            //Assert
                Assert.Equal(actualItem.Id, testItem.Result.Id);
        }

        [Theory]
        [InlineData(1, "Egg", "Free-Range", "Starter", 7.0)]
        public void CreateMenuItem(int p_id, string p_name, string p_desc, string p_category, double p_price)
        {
            //Arrange

            var options = new DbContextOptionsBuilder<EntityFrameworkDbContext>().UseInMemoryDatabase("MenuItems").Options;

            EntityFrameworkDbContext context = new EntityFrameworkDbContext(options);

            IMenuItemRepository menuItemRepository = new SqliteDB(context);

            ICreateMenuItem createItemService = new CreateMenuItem(menuItemRepository, mapper._mapper);

            MenuItem menuItem = new MenuItem(p_id, p_name, p_desc, p_category, p_price);

            bool expectedResult = false;

            //Act
            try
            {
                createItemService.Execute(menuItem);
                expectedResult = true;
            }
            catch (Exception)
            {
                expectedResult = false;
                throw;
            }

            //Assert
            Assert.True(expectedResult);
        }

        [Theory]
        [InlineData("Starter")]
        public void GetAllMenuItemsByTypeTest(string p_type)
        {

            //Arrange

                var options = new DbContextOptionsBuilder<EntityFrameworkDbContext>().UseInMemoryDatabase("MenuItems").Options;

                EntityFrameworkDbContext context = new EntityFrameworkDbContext(options);

                IMenuItemRepository menuItemRepository = new SqliteDB(context);

                GetAllMenuItemsByMenuType sameTypeItemsService = new GetAllMenuItemsByMenuType(menuItemRepository, mapper._mapper);
                ICreateMenuItem createItemService = new CreateMenuItem(menuItemRepository, mapper._mapper);
                
                //Create sample records in the in-memory db
                createItemService.Execute(new MenuItem(1, "Egg", "Free-Range", "Starter", 7.0));
                createItemService.Execute(new MenuItem(2, "Hamburger", "McDonalds", "Main", 7.0));
                createItemService.Execute(new MenuItem(3, "Chocolate Cake", "Dark chocolate", "Dessert", 7.0));

                //Expected Result
                List<MenuItemDTO> expectedResult = new List<MenuItemDTO>() { new MenuItemDTO("Egg", "Free-Range", "Starter", 7.0) };

            //Act
                var result  = sameTypeItemsService.Execute(p_type);
                var actualResult = result.Result;


            //Assert
                Assert.Equal(expectedResult.Find(x=>x.Category == "Starter").Category,actualResult.Find(x => x.Category == "Starter").Category);
        }



        [Theory]
        //Valid id
        [InlineData(1)]
        //Item without any sauces assigned to it. It should be handled without crashing the program.
        [InlineData(0)]
       /*
        * Checks if database design is correct and if the query throws an error
        */
        public void CheckIfGetSaucesForMenuItemWorksForAllVariations(int p_menuItem)
        {
                
            //Arrange

                //In-memory mock database
                var options = new DbContextOptionsBuilder<EntityFrameworkDbContext>().UseInMemoryDatabase("MenuItemSauces").Options;
                //EntityFramework context
                EntityFrameworkDbContext context = new EntityFrameworkDbContext(options);

                IMenuItemRepository menuItemRepository = new SqliteDB(context);

                GetMenuItemSauces getMenuItemSauces = new GetMenuItemSauces(menuItemRepository,mapper._mapper);

                //Initialise tables
                context.MenuItemSauces.RemoveRange(context.MenuItemSauces);
                context.Sauces.RemoveRange(context.Sauces);

                //Insert mock data into Sauces Table
                context.Sauces.Add(new Sauce(p_id: 1, p_name: "Sauce 1"));
                context.Sauces.Add(new Sauce(p_id: 2, p_name: "Sauce 2"));
                //Insert mock data into MenuItemSauces Table
                context.MenuItemSauces.Add(new MenuItemSauce(p_menuItem_id: 1, p_sauce_id: 2, p_default: false));
                context.MenuItemSauces.Add(new MenuItemSauce(p_menuItem_id: 1, p_sauce_id: 1, p_default: false));

            //Act

                //list of possible menu sauce ids that the menu item with Id = p_menuItem has
                var menuItemSauces = getMenuItemSauces.Execute(p_menuItem).Result;

            //Assert
                Assert.NotNull(menuItemRepository);
        }

    }

}
