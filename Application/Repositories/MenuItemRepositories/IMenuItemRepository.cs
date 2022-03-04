using Application.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Repositories.MenuItemRepositories
{
    /*
     * unique repository operations to this entity
     */
    public interface IMenuItemRepository : IDataRepository<MenuItem>
    {
        //retrieve a list of menu items based on their meny type(starter, main, dessert)
        Task<List<MenuItem>> GetMenuItemListByMenuType(string p_type);

        //create menu item
        Task Create(MenuItem p_menuItem);
    }
}
