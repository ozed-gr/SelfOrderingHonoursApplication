using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using Domain.Entities;
using Infrastructure.EntityFramework;

namespace Infrastructure
{
    public class SqliteDBOrdersContext : IOrderRepository
    {
        private readonly EntityFrameworkDbContext _dbContext;
        public Order order;

        public SqliteDBOrdersContext(EntityFrameworkDbContext dbContext)
        {
            _dbContext = dbContext;
            order = new Order(GetLastOrderIdFromOrderTable()+1,1);
            order.OrderItems = new List<OrderItems>();
        }

        public void ChangeOrderTable(int p_tableId)
        {
            order.TableId = p_tableId;
        }

        public int[] GetTables()
        {
            int[] range = new int[2] { 1 , 1};
            try
            {
                range[0] = _dbContext.Tables.FirstOrDefault().TableId;
                range[1] = _dbContext.Tables.OrderByDescending(x=>x).LastOrDefault().TableId;
            }
            catch (Exception)
            {

                throw;
            }

            return range;
        }

        public void ChangeOrderAddMenuItem(MenuItem p_menuItem)
        {
            order.MenuItems.Add(p_menuItem);
        }

        public void ChangeOrderRemoveMenuItem(MenuItem p_menuItem)
        {
            order.MenuItems.Remove(p_menuItem);
        }

        public Task Create(Order p_order)
        {
            int lastOrderId = _dbContext.Orders.Count();
            int lastOrderItemsId = _dbContext.OrderItems.Count();

            lastOrderId++;

            p_order.Id = lastOrderId;

            foreach(var oi in p_order.OrderItems)
            {
                lastOrderItemsId++;
                oi.OrderId = lastOrderItemsId;
                //If item doesn't have a sauce, otherwise it get automatically 0 as SauceId
                if (oi.Sauce.Id == 0)
                { oi.SauceId = null; }
                //Making them null because it conflicts with EF Core
                oi.Sauce = null;
                oi.MenuItem = null;
            }
            
            _dbContext.Orders.Add(p_order);
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuItem>> GetAllOrderMenuItems(int p_order_id)
        {
            return Task.FromResult(order.MenuItems);
        }

        public Task<Order> GetById(int p_id)
        {
            throw new NotImplementedException();
        }

        private int GetLastOrderIdFromOrderTable()
        {            
            return 1;
        }

        public Task<Order> Create(int p_id)
        {
            throw new NotImplementedException();
        }
    }
}
