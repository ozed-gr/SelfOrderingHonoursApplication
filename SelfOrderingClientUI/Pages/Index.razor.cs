using Application.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Blazored.Toast.Services;

namespace SelfOrderingClientUI.Pages
{
    public partial class Index : IDisposable
    {
        [Inject]
        NavigationManager Navigation { get; set; }

        [Inject]
        Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }

        [Inject]
        OrderDTO Order { get; set; }

        [Inject]
        IToastService Toast { get; set; }

        private string menuPageTitle;

        private bool closeDialog = false;

        public bool tableAssigned { get; set; }

        //On first time being rendered
        protected override void OnInitialized()
        {
            //Order.Id = 3;
            menuPageTitle = "Starter";
            Navigation.LocationChanged += LocationChanged;
            Console.WriteLine("Index OnInitialised");
        }

        protected override async Task OnInitializedAsync()
        {
            //Check if table is assigned a value
            tableAssigned = await sessionStorage.GetItemAsync<bool>("tableAssigned");
        }

        //On first render and every re-rendering event
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            //when the user interact with the nav bar then this happens,
            if(!firstRender)
            menuPageTitle = GetMenuPageTitle();

            Console.WriteLine("Index OnAfterRender, FirstRender: ", firstRender.ToString());
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var name = await sessionStorage.GetItemAsync<string>("tableId");
        }

        private string GetMenuPageTitle()
        {
           return Navigation.Uri.Substring(Navigation.Uri.LastIndexOf('/') + 1);
        }

        private void LocationChanged(object o, LocationChangedEventArgs lea)
        {
            bool isNavChanged = lea.IsNavigationIntercepted;
            string locat = lea.Location;
            menuPageTitle = GetMenuPageTitle();
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            //Unsubscribe from the event when our component is disposed
            Navigation.LocationChanged -= LocationChanged;
        }

        public void TableIdDialogClose(bool p_bool)
        {
            closeDialog = true;
            StateHasChanged();
        }

        public void ToastSuccess()
        {
            Toast.ShowSuccess("Added to cart");
        }
    }
}
