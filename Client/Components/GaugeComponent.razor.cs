using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using OpenBetsBeta.Client;
using OpenBetsBeta.Client.Shared;
using Radzen;
using Radzen.Blazor;

namespace OpenBetsBeta.Client.Components;

   

    public partial class GaugeComponent
    {
      Account account;

      protected override Task OnInitializedAsync()
      {
         

         return base.OnInitializedAsync();
      }

      private Account NewAccount()
      {
         account = new Account();
         account.Id = "";
         account.Name = "";
         account.PublicAddress = "";
         account.Description = "";
         account.Reserves = 0;
         account.Locked = 0;
         account.CreatedDate = DateTime.UtcNow;
         account.OpenBets = new();
         account.PendingBets = new();
         account.PastBets = new();
         return account;
      }
   }
