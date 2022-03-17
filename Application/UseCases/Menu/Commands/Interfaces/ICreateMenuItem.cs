using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MenuItemUseCases
{
    public interface ICreateMenuItem
    {
        //create menu item using its id as a reference
        Task Execute(MenuItem p_menuItem);
    }
}
