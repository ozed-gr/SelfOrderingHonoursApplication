using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using Application.UseCases.Menu.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.UseCases.Menu.Queries
{
    public class GetMenuItemSauces : MenuConfigUseCase
    {
        public GetMenuItemSauces(IMenuItemRepository menuItemRepository, IMapper mapper) : base(menuItemRepository, mapper)
        {
        }

        //returns a list of all the sauces that the menu item can have
        public Task<List<MenuItemSauceDTO>> Execute(int p_menuItem_id)
        {
            //returns List<MenuItemSauces>
            var sauces = _menuItemRepository.GetMenuItemSauces(p_menuItem_id).Result;

            List<MenuItemSauceDTO> menuItemSauceDTO = _mapper.Map<List<MenuItemSauceDTO>>(sauces);
            
            return Task.FromResult(menuItemSauceDTO);
        }

        //returns a specific sauce object
        public Task<SauceDTO> GetSauceObject(int p_sauce_id)
        {           
            var sauce = _menuItemRepository.GetMenuItemSauce(p_sauce_id).Result;

            SauceDTO sauceDTO = _mapper.Map<SauceDTO>(sauce);

            return Task.FromResult(sauceDTO);
        }

    }
}
