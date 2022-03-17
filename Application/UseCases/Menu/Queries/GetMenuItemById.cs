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
    public class GetMenuItemById : IGetMenuItemById
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private IMapper _mapper;
        public GetMenuItemById(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }
        public Task<MenuItemDTO> Execute(int p_id)
        {
            //retrieves complex entity type
            var item = _menuItemRepository.GetById(p_id).Result;
            //converts into UI friendly type
            //ItemIngredient item1 = new ItemIngredient();         

            MenuItemDTO menuItemDTO = _mapper.Map<MenuItem, MenuItemDTO>(item);

            return Task.FromResult(menuItemDTO);
        }
    }
}
