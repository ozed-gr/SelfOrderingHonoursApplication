using Application.DTOs;
using Application.UseCases.OrderUseCases;
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
        OrderDTO Order { get; set; }
        [Inject]
        ICreateOrder CreateOrder { get; set; }
        [Inject]
        Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }

        public double OrderTotal { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Order.GroupMenuItemQunatity();      
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            CalculateTotal();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            Order.GroupMenuItemQunatity();
            CalculateTotal();
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var table = await sessionStorage.GetItemAsync<string>("tableId");
            Order.TableId = Int32.Parse(table);
        }

        private void Commit()
        {
            if(Order.OrderItems.Count() != 0)
            CreateOrder.Execute(Order);
        }

        private void RemoveItem(string p_itemName)
        {
            var a = Order.ItemQuantity[p_itemName];
            if(Order.ItemQuantity[p_itemName]==1)
            {
                Order.ItemQuantity.Remove(p_itemName);
                var itemToRemove = Order.OrderItems.Where(x => x.Name == p_itemName).FirstOrDefault();
                Order.OrderItems.Remove(itemToRemove);
            }
            else
            {
                a = a - 1;
                Order.ItemQuantity[p_itemName] = Order.ItemQuantity[p_itemName] - 1;
                var itemToRemove = Order.OrderItems.Where(x => x.Name == p_itemName).FirstOrDefault();
                Order.OrderItems.Remove(itemToRemove);
            }
            ShouldRender();
            //StateHasChanged();
        }

        private void CalculateTotal()
        {
            OrderTotal = 0;
            foreach(var item in Order.OrderItems)
            {
                OrderTotal += item.Price;
            }
        }
    }
}
