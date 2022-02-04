using Microsoft.AspNetCore.Components;

namespace OpenBets.Client.Pages;

public partial class EventComponent : ComponentBase
{
   public string? EventResponse { get; set; }
   private Event _event = new Event();

   protected override Task OnInitializedAsync()
   {
      GetEvent();   
      return Task.CompletedTask;
   }

   public void GetEvent()
   {
      EventResponse = OpenBets.Shared.API.SportsDataAPI.GetEvent();
   }

}
