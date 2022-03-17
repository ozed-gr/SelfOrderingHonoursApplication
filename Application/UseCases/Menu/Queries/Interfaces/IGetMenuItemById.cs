using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MenuItemUseCases
{
    public interface IGetMenuItemById
    {
        Task<MenuItemDTO> Execute(int p_id);
    }
}
