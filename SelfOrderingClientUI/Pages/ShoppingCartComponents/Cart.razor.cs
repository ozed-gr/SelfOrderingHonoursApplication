using Application.DTOs;
using Application.UseCases.OrderUseCases;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages.ShoppingCartComponents
{
    public partial class Cart
    {
        [Inject]
        public IToastService Toast { get; set; }
        [Inject]
        OrderDTO Order { get; set; }
        [Inject]
        ICreateOrder CreateOrder { get; set; }
        [Inject]
        Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }
        [Inject]
        NavigationManager uriHelper { get; set; }

        public double OrderTotal { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            CreateOrder.Execute(Order);
            //Order.GroupMenuItemQunatity();      
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            CalculateTotal();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            CalculateTotal();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var table = await sessionStorage.GetItemAsync<string>("tableId");
            Order.TableId = Int32.Parse(table);
        }

        private void Commit()
        {
            if (Order.OrderItems.Count() != 0)
            {
                //CreateOrder.Execute(Order);
                CreateOrder.SaveToDB(Order);
                Toast.ShowInfo("Order has been successfully created");

                //re-initialise ordering process
                Order = new OrderDTO();
                StateHasChanged();
            }
            else
            {
                Toast.ShowError("An error occured.");
            }
        }

        private void RemoveItem(MenuItemDTO p_MenuItem)
        {
            Order.OrderItems.Remove(p_MenuItem);
            CreateOrder.Execute(Order);
        }

        public void OrderSameAgainMenuItem(MenuItemDTO p_MenuItem)
        {
            Order.OrderItems.Add(p_MenuItem);
            CreateOrder.Execute(Order);  
        }

        private void CalculateTotal()
        {
            OrderTotal = 0;
            foreach(var item in Order.OrderItemsEntities)
            {
                OrderTotal += item.MenuItem.Price * item.Quantity;
            }
            StateHasChanged();
        }
    }
}
