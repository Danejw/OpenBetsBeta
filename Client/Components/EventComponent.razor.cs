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
    public partial class EventComponent
    {
        private List<Event> events = new();
        private readonly MongoEventData eventData;
        private string selectedEvent = "All";

        protected async override Task OnInitializedAsync()
        {
            Organisation org = new Organisation();
            events.Add(CreateSampleEvent(org, "UFC 270"));
           
            await base.OnInitializedAsync();
            //events = await eventData.GetEventsAsync();
        }

         int ufcCount = 0;
         private void CreateAndAddEvent()
         {
            Organisation org = new Organisation();
            events.Add(CreateSampleEvent(org, "UFC " + ufcCount));
            ufcCount++;
         }

         private Event CreateSampleEvent(Organisation org, string name)
         {
            Event e  = new Event();
            e.Id = (events.Count+1).ToString();
            e.Name = name;
            e.CreatedDateTime = DateTime.UtcNow;
            e.ScheduledDateTime = DateTime.UtcNow.AddDays(1); // event date
            e.IsDone = false;
            e.Description = "";
            e.SubEvents = new();
            return e;
         }
    }
}