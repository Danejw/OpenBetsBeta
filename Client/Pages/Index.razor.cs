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
using OpenBets.Shared.DataAccess;
using OpenBetsBeta.Shared.DataAccess;


namespace OpenBetsBeta.Client.Pages;
public partial class Index
{
   private List<Organisation> organisations;
   private List<Event> events;
   private List<SubEvent> subEvents;
   private List<Bet> bets;
   private List<Account> accounts;

   private readonly MongoOrganisationData organisationData;
   private readonly MongoEventData eventData;
   private readonly MongoSubEventData subEventData;
   private readonly MongoAccountData accountData;
   private readonly MongoBetData betData;

   private string selectedOrganisation = "All";
   private string selectedEvent = "All";
   private string searchText = "ufc";
   private bool isSortedByNew = true;

   protected async override Task OnInitializedAsync()
   {
      organisations = await organisationData.GetOrganisationsAsync();
      events = await eventData.GetEventsAsync();
      subEvents = await subEventData.GetSubEventsAsync();
      accounts = await accountData.GetAccountsAsync();
      bets = await betData.GetBetsAsync();
   }

   protected override Task OnAfterRenderAsync(bool firstRender)
   {
      

      organisations = new List<Organisation>();

      //creating sample organisations
      Organisation ufc = new Organisation();
      ufc.Name = "UFC";
      Organisation nfl = new Organisation();
      nfl.Name = "NFL";

      organisations.Add(ufc);
      organisations.Add(nfl);

      return base.OnAfterRenderAsync(firstRender);
   }

}
