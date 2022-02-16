using Application.DTOs;
using Application.UseCases.MenuItemUseCases;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages
{
    public partial class Index
    {
        [Inject]
        IGetAllMenuTypeMenuItems createMenuItem { get; set; }

        private List<MenuItemDTO> menuList;
        private string _image = "";
        protected override void OnInitialized()
        {
            menuList = createMenuItem.Execute("starters").Result;
        }

        public bool even = false;
        public int counter = 0;

        public void ResetCount()
        {
            counter = 0;
        }

        private void IncrementCount()
        {
            counter++;
        }

        private void ChangeToTrue()
        {
            even = true;
        }

        private void ChangeToFalse()
        {
            even = false;
        }
    }
}
