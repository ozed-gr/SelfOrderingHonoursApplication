using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OrderUseCases
{
    public interface IChangeOrderAddMenuItem
    {
        Task Execute(MenuItemDTO p_menuItem);
    }
}
