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
    public partial class DialogSale
    {
        [Parameter] public long saleId { get; set; }

        //Order order;
        //IEnumerable<OrderDetail> orderDetails;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            //order = dbContext.Orders.Where(o => o.OrderID == OrderID)
              //              .Include("Customer")
                //            .Include("Employee").FirstOrDefault();

            //orderDetails = dbContext.OrderDetails.Include("Order").ToList();
        }
    }
}