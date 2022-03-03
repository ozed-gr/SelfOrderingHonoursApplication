using Application.DTOs;
using Application.UseCases.MenuItemUseCases;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages.MenuItemComponents
{
    public partial class MenuTypeComponent
    {
        [Inject]
        IGetAllMenuTypeMenuItems createMenuItemsList { get; set; }
        [Inject]
        NavigationManager Navigation { get; set; }

        [Parameter]
        public string PageName { get; set; }

        [Parameter]
        public EventCallback ToastMsg { get; set; }

        private string menuPageTitle;
        private List<MenuItemDTO> menuList;
        private string _image = "";
        private int count = 0;

        //On first time being rendered
        protected override void OnInitialized()
        {
            Console.WriteLine("Child OnInitialised");
        }

        //When the component received new parameter values then execute this method
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (PageName.Equals(""))
            {
                menuList = createMenuItemsList.Execute("Starter").Result;
            }
            else
            {
                menuList = createMenuItemsList.Execute(PageName).Result;
            }
            Console.WriteLine(ShouldRender().ToString());
            Console.WriteLine("Child OnParametersSet");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            Console.WriteLine("Child OnAfterRender, FirstRender: ", firstRender.ToString());
        }

        public void ToastMessage()
        {
            ToastMsg.InvokeAsync();
        }
    }
}
