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
        Task<List<MenuItem>> GetListOfMenuItemWithSameMenuType(string p_type);

        Task<List<MenuItemSauce>> GetMenuItemSauces(int p_menuItemId);
        Task<Sauce> GetMenuItemSauce(int p_sauceId);

    }
}
