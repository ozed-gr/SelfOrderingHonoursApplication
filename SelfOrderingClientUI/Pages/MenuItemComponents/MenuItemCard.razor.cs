using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using Application.UseCases.OrderUseCases;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.Menu.Queries;

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
        public bool ShowCustomisationDialog { get; set; } = false;

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
        GetMenuItemSauces ShowSauces { get; set; }

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

        public bool CustomisationOptionsAvailable()
        {
            List<MenuItemSauceDTO> sauces = ShowSauces.Execute(Id).Result;
            if(sauces.Count==0)
            {
                return false;
            }
            //else if(temperature.Count==0)
            //{

            //}

            return true;
        }
        //Whenever the user presses cancel on CustomisationComponent, run this method
        public void CancelCustomisationDialog()
        {
            ShowCustomisationDialog = false;
            StateHasChanged();
        }
        //Whenever the user presses done on CustomisationComponent, run this method
        public void DoneCustomisationDialog(Dictionary<string,int> UserCustomisation)
        {
            //Sauce object
            MenuItem.Sauce = ShowSauces.GetSauceObject(UserCustomisation["Sauce"]).Result;
            //Add item to cart
            Order.OrderItems.Add(MenuItem);
            ShowToastMessage();
            //Close dialog
            ShowCustomisationDialog = false;
            StateHasChanged();
        }

        public void AddItemToOrder()
        {
            //Check if there are any customisation options           
            if (CustomisationOptionsAvailable())
            {
                //display and allow for selection
                ShowCustomisationDialog = true;
            }
            else
            {
                //Add item to cart
                Order.OrderItems.Add(MenuItem);
                ShowToastMessage();
            }
        }

        public void ShowToastMessage()
        {
            AddToastMsg.InvokeAsync();
        }
    }
}
