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
    public partial class BetComponent
    {
        private List<Bet> bets = new();
        private readonly MongoBetData betData;

        protected async override Task OnInitializedAsync()
        {
            bets.Add(CreateSampleBet());            

            await base.OnInitializedAsync();
            //bets = await betData.GetBetsAsync();
        }

      private void CreateAndAddBet()
      {
         bets.Add(CreateSampleBet());
      }

      private Bet CreateSampleBet()
      {
         Bet bet = new Bet(); 
         bet.Id = (bets.Count + 1).ToString();
         bet.TransactionId = bet.Id;
         bet.Event = new();
         bet.SubEvent = new();
         bet.CreatedDateTime = DateTime.UtcNow;
         bet.ScheduledDateTime = DateTime.UtcNow.AddHours(5);
         bet.IsDone = false;
         bet.Address1 = "";
         bet.Address2 = "";
         bet.Stake = 100;
         bet.Loser = null;
         bet.Winner = null;
         return bet;
      }
    }
}