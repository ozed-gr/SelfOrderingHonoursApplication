using Application.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages.ShoppingCartComponents
{
    public partial class CartMenuItemCard
    {
        [Inject]
        OrderDTO Order { get; set; }

        [Parameter]
        public MenuItemDTO MenuItem { get; set; }
        [Parameter]
        public string ItemName { get; set; }
        [Parameter]
        public int Quantity { get; set; }
        [Parameter]
        public double Total { get; set; }
        [Parameter]
        public string SauceName { get; set; }

        [Parameter]
        public EventCallback<string> RemoveCallBack { get; set; }
        [Parameter]
        public EventCallback<MenuItemDTO> AddCallBack { get; set; }

        public void RemoveItem(string p_itemName)
        {
            RemoveCallBack.InvokeAsync(ItemName);
        }

        public void AddItem(MenuItemDTO p_MenuItem)
        {
            //passing MenuItem as a parameter to the parent method
            AddCallBack.InvokeAsync(MenuItem);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}
