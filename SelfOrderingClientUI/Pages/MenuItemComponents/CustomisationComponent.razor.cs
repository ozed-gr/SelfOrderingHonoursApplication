using Application.DTOs;
using Application.UseCases.Menu.Queries;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfOrderingClientUI.Pages.MenuItemComponents
{
    public partial class CustomisationComponent
    {
        public List<MenuItemSauceDTO> Sauces { get; set; }
        [Parameter]
        public int SauceId { get; set; }
        [Parameter]
        public int MenuItemId{ get; set; }

        public Dictionary<string, int> UserCustomisation { get; set; } = new Dictionary<string, int>();

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback CancelDialog { get; set; }

        //What do I want to send back as a parameter when the user presses done.
        //I want to send back all the user customisation selections
        [Parameter]
        public EventCallback<Dictionary<string,int>> DoneDialog { get; set; }

        [Inject]
        GetMenuItemSauces ShowSauces { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //Get Sauces for that Item
            try
            {
                Sauces = ShowSauces.Execute(MenuItemId).Result;
            }
            catch (Exception)
            {
                //if no sauces have been assigned display blank
                Sauces = new List<MenuItemSauceDTO>();
            }
        }

        private Task Close()
        {
            return CancelDialog.InvokeAsync();
        }

        //Action for Done button, upon the user confirms their selection
        private Task Done()
        {
            //if user doesn't select a sauce       
            UserCustomisation.Add("Sauce", SauceId);
            return DoneDialog.InvokeAsync(UserCustomisation);
        }

    }
}
