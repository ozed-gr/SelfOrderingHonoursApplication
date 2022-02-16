using Application.DTOs;
using Application.UseCases.MenuItemUseCases;
using Microsoft.AspNetCore.Components;
using SelfOrderingClientUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages
{
    public partial class DisplayMenuItem
    {
        [Inject]
        ICreateMenuItem createMenuItem { get; set; }
        [Inject]
        IGetMenuItemById getMenuItem { get; set; }



        private MenuItemDTO menuItemDTO;
        private List<string> render = new List<string>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //createMenuItem.Execute(2);
            var item = getMenuItem.Execute(1).Result;
            menuItemDTO = item;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            render.Add("Item has been rendered!");
        }
    }
}
