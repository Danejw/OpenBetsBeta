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

namespace OpenBetsBeta.Client.Components
{
    public partial class WalletComponent
    {
        private List<Account> accounts = new();
        private readonly MongoAccountData accountData;

        protected async override Task OnInitializedAsync()
        {
            accounts.Add(CreateSampleAccount("Dano"));
            accounts.Add(CreateSampleAccount("SupremeKai"));
            accounts.Add(CreateSampleAccount("Sponger"));

            await base.OnInitializedAsync();
            //accounts = await accountData.GetAccountsAsync();
        }

      private Account CreateSampleAccount(string name)
      {
         Account account = new Account();
         account.Id = (accounts.Count + 1).ToString();
         account.Name = name;
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
}