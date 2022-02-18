using Application.DTOs;
using Application.UseCases.MenuItemUseCases;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages
{
    public partial class MenuPage
    {
        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        [Parameter]
        public string MenuPageName { get; set; }

        string pageName = "Starter";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            pageName = GetPageName();
            if (!pageName.Equals(""))
                menuList = createMenuItem.Execute(pageName).Result;
            else { menuList = createMenuItem.Execute("Starter").Result; }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            //When new or changed parameter values from the parent are passed
            //Get new menu list based on MenuPageName
            //pageName = GetPageName();
            //GetMenuItemsList(pageName);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            pageName = GetPageName();
            if (!pageName.Equals(""))
            {
                menuList = createMenuItem.Execute(pageName).Result;
            }        
            else { menuList = createMenuItem.Execute("Starter").Result; }
        }

        [Inject]
        IGetAllMenuTypeMenuItems createMenuItem { get; set; }

        private List<MenuItemDTO> menuList;
        private string _image = "";

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

        public string GetPageName()
        {
           return MyNavigationManager.Uri.Substring(MyNavigationManager.Uri.LastIndexOf('/') + 1);
        }

        public void GetMenuItemsList(string p_menuPageName)
        {
            menuList = createMenuItem.Execute(p_menuPageName).Result;
        }
    }
}
