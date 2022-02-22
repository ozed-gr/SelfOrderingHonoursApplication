using Application.DTOs;
using Application.UseCases.MenuItemUseCases;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages.MenuItemComponents
{
    public partial class MenuItemInfo
    {
        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public int Id { get; set; } = 0;

        [Inject]
        IGetMenuItemById GetItemById { get; set; }

        private MenuItemDTO menuItem; 

        protected override void OnInitialized()
        {
            base.OnInitialized();
            menuItem = GetItemById.Execute(Id).Result;
        }
    }
}
