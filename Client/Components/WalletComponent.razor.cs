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
using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;

namespace OpenBetsBeta.Client.Components
{
    public partial class WalletComponent
    {
        private List<OpenBets.Shared.Models.Account> accounts = new();
        private readonly MongoAccountData accountData;

      string stellarUrl = "https://horizon-testnet.stellar.org";
      Server server;
      public string secretSeed = "Seed";
      public byte[] publicKey;
      public byte[] privateKey;
      public string accountId ="AccountId";

      public KeyPair source;
      public KeyPair destination;


        protected async override Task OnInitializedAsync()
        {
            accounts.Add(CreateSampleAccount("Dano"));
            accounts.Add(CreateSampleAccount("SupremeKai"));
            accounts.Add(CreateSampleAccount("Sponger"));


            

            await base.OnInitializedAsync();
            //accounts = await accountData.GetAccountsAsync();
        }

      private OpenBets.Shared.Models.Account CreateSampleAccount(string name)
      {
         OpenBets.Shared.Models.Account account = new OpenBets.Shared.Models.Account();
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

      public async Task ConnectToAccount()
      {
         stellar_dotnet_sdk.Network.UseTestNetwork();

         server = new stellar_dotnet_sdk.Server(stellarUrl);
      }
    }
}