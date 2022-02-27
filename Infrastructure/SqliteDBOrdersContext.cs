using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<Order> ChangeOrderAddMenuItem(MenuItem p_menuItem)
        {
            //order.OrderItems.Add();
            //order.OrderItems.Add(new OrderItems(order, p_menuItem));
            //var query = from t in _dbContext.
            //            where t.MenuItemId == p_id
            //            select t;
            OrderItems orderItems = new OrderItems(order,p_menuItem);
            _dbContext.OrderItems.Add(orderItems);
            throw new NotImplementedException();
        }

        public Task<Order> ChangeOrderRemoveMenuItem(int p_menuItem_id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Create(int p_id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuItem>> GetAllOrderMenuItems(int p_order_id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetById(int p_id)
        {
            throw new NotImplementedException();
        }

        private int GetLastOrderIdFromOrderTable()
        {
            //int count = _dbContext.Orders.Count();

            //if(count==0)
            //{
            //    _dbContext.Orders.Add(order);
            //}
            //else
            //{

            //}


            //try
            //{
            //    var lastOrder = _dbContext.Orders.OrderByDescending(p => p.Id)
            //        .FirstOrDefault().Id;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            
            return 1;
        }
    }
}
