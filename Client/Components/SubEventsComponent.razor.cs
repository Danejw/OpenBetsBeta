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
    public partial class SubEventsComponent
    {
      private List<SubEvent> subEvents = new();
        private readonly MongoSubEventData subEventData;
        private string selectedEvent = "All";
        protected async override Task OnInitializedAsync()
        {
            subEvents.Add(CreateSubEvent("SupremeKai Vs Sponger"));
            subEvents.Add(CreateSubEvent("SupremeKai Vs Dano"));
            subEvents.Add(CreateSubEvent("Dano Vs Sponger"));

            await base.OnInitializedAsync();
            //subEvents = await subEventData.GetSubEventsAsync();
        }

      int fighterId = 0;
      private void CreateAndAddSubEvent()
      {
         subEvents.Add(CreateSubEvent( "Fighter " + (fighterId + 1) + " vs Fighter " + (fighterId + 2) ));
         fighterId++;
         fighterId++;
      }

        private SubEvent CreateSubEvent(string name)
        {
            SubEvent sub = new SubEvent();
            sub.Id = (subEvents.Count+1).ToString();
            sub.Name = name;
            sub.CreateDateTime = DateTime.UtcNow;
            sub.ScheduledDateTime = DateTime.UtcNow.AddHours(24);
            sub.IsDone = false;
            sub.Description = "";
            return sub;
        }
    }
}