using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages.ShoppingCartComponents
{
    public partial class CartMenuItemCard
    {
        [Parameter]
        public string ItemName { get; set; }
        [Parameter]
        public int Quantity { get; set; }
        [Parameter]
        public double Total { get; set; }

        [Parameter]
        public EventCallback<string> RemoveCallBack { get; set; }

        public void RemoveItem(string p_itemName)
        {
            RemoveCallBack.InvokeAsync(ItemName);
        }
    }
}
