using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace ShellyPOS.Components.Pages.Sales
{
    public partial class Sales
    {       
        //RadzenDataGrid<Order> ordersGrid;
        //IList<Order> orders;

        private async Task OpenOrder(int orderId)
        {
          //  await DialogService.OpenAsync<DialogCardPage>($"Order {orderId}",
           //     new Dictionary<string, object>() { { "OrderID", orderId } },
             //   new DialogOptions() { Width = "700px", Height = "520px" });
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

           // orders = dbContext.Orders.Include("Customer").Include("Employee").ToList();
        }

    }
}