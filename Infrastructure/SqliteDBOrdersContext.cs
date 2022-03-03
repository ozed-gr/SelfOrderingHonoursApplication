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
            //get last order Id
            int lastId = _dbContext.Orders.Count();
            lastId++;

            p_order.Id = lastId;

            //Order temp_order = new Order(lastId, 7);
            //_dbContext.Orders.Add(temp_order);
            //p_order.OrderItems = new List<OrderItems>();
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

        public void CommitOrder()
        {
            Dictionary<string, int> listOfMenuItems = GroupMenuItemQunatity();

            foreach (var m in order.MenuItems)
            {
                _dbContext.OrderItems.Add(new OrderItems
                {
                    Order = order,
                    OrderId = order.Id,
                    MenuItem = m,
                    MenuItemId = m.Id,
                    Quantity = listOfMenuItems[m.Name]
                });
            }

        }

        private Dictionary<string, int> GroupMenuItemQunatity()
        {
            Dictionary<int,string> keyValuePairs = new Dictionary<int, string>();
            int counter = 0;

            foreach(var item in order.MenuItems)
            {
                keyValuePairs.Add(counter++, item.Name);
            }

            Dictionary<string, int> valCount = new Dictionary<string, int>();

            foreach (var i in keyValuePairs.Values)
            {
                if (valCount.ContainsKey(i))
                {
                    valCount[i]++;
                }
                else
                {
                    valCount[i] = 1;
                } 
            }

            return valCount;
        }

        public Task<Order> Create(int p_id)
        {
            throw new NotImplementedException();
        }
    }
}
