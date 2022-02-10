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
       private List<Organisation> organisations = new();
       private MongoOrganisationData organisationData;
       private int count;
       
         //private string selectedOrganisation = "All";
       protected async override Task OnInitializedAsync()
       {
         CreateSampleOrganisations();


         await base.OnInitializedAsync();
          //organisations = await organisationData.GetOrganisationsAsync();
       }
       protected override Task OnAfterRenderAsync(bool firstRender)
      {      
         return base.OnAfterRenderAsync(firstRender);
      }
       
       private void CreateSampleOrganisations()
      {
         Organisation ufc = CreateOrganisation("UFC", "The Ultimate Figting Championship");
         Organisation nfl = CreateOrganisation("NFL", "The National Football League");
         Organisation nba = CreateOrganisation("NBA", "THe National Basketball Association");

         organisations.Add(ufc);
         organisations.Add(nfl);
         organisations.Add(nba);
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
       public Organisation CreateOrganisation(string name, string desc)
      {
         Organisation org = new Organisation();
         org.Id = count++.ToString();
         org.Name = name;
         org.Description = desc;
         org.CreatedDate = DateTime.UtcNow;
         org.Events = new List<Event>();
         return org;

         //Console.Out.WriteLine("Added New Organisation: " + org.Name);
         //await organisationData.CreateOrganisation(org);
      }
    }
}