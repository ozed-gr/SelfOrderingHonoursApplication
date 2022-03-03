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
        [Parameter]
        public string CardDesc { get; set; }
        public string Image { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public MenuItemDTO MenuItem { get; set; }

        [Parameter]
        public EventCallback AddToastMsg { get; set; }

        [CascadingParameter]
        public Action<MenuItemDTO> AddItemToOrderDel { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        [Inject]
        IToastService Toast { get; set; }

        [Inject]
        IChangeOrderAddMenuItem AddMenuItem { get; set; }

        [Inject]
        OrderDTO Order { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CardTitle = MenuItem.Name;
            CardDesc = MenuItem.Description;
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
            CardDesc = MenuItem.Description;
            Image = MenuItem.Image;
        }

        public void AddItemToOrder()
        {
            Order.OrderItems.Add(MenuItem);
            ShowToastMessage();
        }

        public void ShowToastMessage()
        {
            AddToastMsg.InvokeAsync();
        }
    }
}
