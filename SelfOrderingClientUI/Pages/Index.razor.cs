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
        [Inject]
        NavigationManager Navigation { get; set; }

        private MenuPage refMenuPage;
        private string menuPageTitle;
        private string newMenuPageTitle;
        private List<MenuItemDTO> menuList;
        private string _image = "";

        //On first time being rendered
        protected override void OnInitialized()
        {
            menuList = createMenuItem.Execute("starters").Result;
            menuPageTitle = GetMenuPageTitle();
        }

        //On first render and every re-rendering event
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            menuPageTitle = GetMenuPageTitle();
            menuList = createMenuItem.Execute(menuPageTitle).Result;
        }

        private string GetMenuPageTitle()
        {
           return Navigation.Uri.Substring(Navigation.Uri.LastIndexOf('/') + 1);
        }

        private void ShowMenuPageTitle()
        {
            newMenuPageTitle = refMenuPage.GetPageName();
        }

    }
}
