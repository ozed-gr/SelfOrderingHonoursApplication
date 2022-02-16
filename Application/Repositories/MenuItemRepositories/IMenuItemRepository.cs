using Application.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.MenuItemRepositories
{
    /*
     * unique repository operations to this entity
     */
    public interface IMenuItemRepository : IDataRepository<Domain.Entities.MenuItem>
    {
        //retrieve a list of menu items based on their meny type(starter, main, dessert)
        Task<List<Domain.Entities.MenuItem>> GetMenuItemListByMenuType(string p_type);

        //create menu item using its id
    }
}
