﻿using Application.Repositories.MenuItemRepositories;
using AutoMapper;
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
        private IMapper _mapper;

        public CreateMenuItem(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public async Task Execute(int p_id)
        {
            int id = p_id;
            //await will suspend the Execute method completion until the Create method is completed
            await _menuItemRepository.Create(id);
            
            //for some reason this loops
            //return await Task.FromResult(await _menuItemRepository.Create(id));
        }
    }
}
