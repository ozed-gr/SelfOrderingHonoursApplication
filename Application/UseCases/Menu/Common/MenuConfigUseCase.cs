using Application.Repositories.MenuItemRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Menu.Common
{
    public abstract class MenuConfigUseCase
    {
        protected readonly IMenuItemRepository _menuItemRepository;
        protected IMapper _mapper;

        public MenuConfigUseCase(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }
    }
}
