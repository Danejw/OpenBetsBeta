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
using Radzen.Blazor;

namespace OpenBetsBeta.Client.Components
{
    public partial class OrganisationComponent
    {
      RadzenDataGrid<Organisation> table;
      private IEnumerable<Organisation> organisations;
      private MongoOrganisationData organisationData;
      private int count;
      private Organisation sample;
        //private string selectedOrganisation = "All";
        protected async override Task OnInitializedAsync()
        {
            organisations = await organisationData.GetOrganisationsAsync();
        }
      protected override Task OnAfterRenderAsync(bool firstRender)
      {
         sample = CreateOrganisation("UFC");

         return base.OnAfterRenderAsync(firstRender);
      }

      private void CreateSampleOrganisations()
      {
         //organisations = await organisationData.GetOrganisationsAsync();
         table.InsertRow(CreateOrganisation("UFC"));
         table.InsertRow(CreateOrganisation("NFL"));
         table.InsertRow(CreateOrganisation("MBA"));
      }

      public Organisation CreateOrganisation(string name)
      {
         Organisation org = new Organisation();
         org.Id = count++.ToString();
         org.Name = name;
         org.Description = "";
         org.CreatedDate = DateTime.UtcNow;
         org.Events = new List<Event>();
         return org;

         //Console.Out.WriteLine("Added New Organisation: " + org.Name);
         //await organisationData.CreateOrganisation(org);
      }
    }
}