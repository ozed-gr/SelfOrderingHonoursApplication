using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MenuItemUseCases
{
    public interface IGetAllMenuItemsByMenuType
    {
        Task<List<MenuItemDTO>> Execute(string p_menuType);
    }
}
