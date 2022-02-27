using Application.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Common;
using Domain.Entities;

namespace Application.Repositories.MenuItemRepositories
{
    public interface IOrderRepository : IDataRepository<Order>
    {
        Task<Order> ChangeOrderAddMenuItem(MenuItem p_menuItem);
        Task<Order> ChangeOrderRemoveMenuItem(int p_menuItem_id);
        Task<List<MenuItem>> GetAllOrderMenuItems(int p_order_id);
    }
}
