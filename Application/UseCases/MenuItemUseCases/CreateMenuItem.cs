using Application.Repositories.MenuItemRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MenuItemUseCases
{
    public class CreateMenuItem : ICreateMenuItem
    {

        private readonly IMenuItemRepository _menuItemRepository;

        public CreateMenuItem(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<MenuItem> Execute(int p_id)
        {
            int id = p_id;
            await _menuItemRepository.Create(id);

            throw new NotImplementedException();
        }
    }
}
