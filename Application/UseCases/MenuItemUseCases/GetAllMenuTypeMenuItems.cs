using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MenuItemUseCases
{
    public class GetAllMenuTypeMenuItems : IGetAllMenuTypeMenuItems
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private IMapper _mapper;

        public GetAllMenuTypeMenuItems(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public Task<List<MenuItemDTO>> Execute(string p_menuType)
        {
            var menu = _menuItemRepository.GetMenuItemListByMenuType(p_menuType).Result;
            var menuDTO = _mapper.Map<List<MenuItem>, List<MenuItemDTO>>(menu);

            return Task.FromResult(menuDTO);
        }
    }
}
