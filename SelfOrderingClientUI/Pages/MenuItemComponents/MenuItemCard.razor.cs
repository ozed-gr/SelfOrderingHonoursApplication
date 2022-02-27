using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using Application.UseCases.OrderUseCases;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages.MenuItemComponents
{
    public partial class MenuItemCard
    {
        public string CardTitle { get; set; }
        public string CardDesc { get; set; }
        public string Image { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public MenuItemDTO MenuItem { get; set; }  

        [Inject]
        NavigationManager Navigation { get; set; }

        [Inject]
        IToastService Toast { get; set; }

        [Inject]
        IChangeOrderAddMenuItem AddMenuItem { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CardTitle = MenuItem.Name;
            CardDesc = MenuItem.Category;
            Image = MenuItem.Image;
        }

        private void NavigateToInfoPageWithId(int p_id)
        {
            Navigation.NavigateTo("/item/" + p_id);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Id = Id;
            CardTitle = MenuItem.Name;
            CardDesc = MenuItem.Category;
            Image = MenuItem.Image;
            //StateHasChanged();
        }

        public void AddItemToOrder()
        {
            //AddMenuItem.Execute(MenuItem);
        }
    }
}
