using Application.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Common;
using Domain.Entities;
using Application.DTOs;

namespace Application.Repositories.MenuItemRepositories
{
    public interface IOrderRepository : IDataRepository<Order>
    {
        void ChangeOrderAddMenuItem(MenuItem p_menuItem);
        void ChangeOrderRemoveMenuItem(MenuItem p_menuItem);
        Task<List<MenuItem>> GetAllOrderMenuItems(int p_order_id);
        Task Create(Order p_order);

        int[] GetTables();
    }
}
