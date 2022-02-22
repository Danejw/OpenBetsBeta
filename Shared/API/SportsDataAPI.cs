using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace OpenBetsBeta.Shared.API;

public class SportsDataAPI
{
   private readonly string ufcScheduleEndpoint = "https://api.sportsdata.io/v3/mma/scores/json/Schedule/NFL/2022";
   private readonly string ufcEventEndpoint = "https://api.sportsdata.io/v3/mma/scores/json/Event/272";
   private readonly string key = "27c99f4173ba435590ff64746b6bd69e";

   // Ocp-Apim-Subscription-Key: {key}

   private readonly HttpClient client;

   public SportsDataAPI()
   {
      client = new HttpClient();
      client.DefaultRequestHeaders.Add("key", key);
   }


   public async Task<string> GetScheduleAsync()
   {
      var response = await client.GetAsync(ufcScheduleEndpoint);
      response.EnsureSuccessStatusCode();
      return await response.Content.ReadAsStringAsync();

   }

   public async Task<List<UfcEvent>> GetEventAsync()
   {
      List<UfcEvent> events = new List<UfcEvent>();

      var response = await client.GetAsync(ufcEventEndpoint);
      response.EnsureSuccessStatusCode();
      var result = response.Content.ReadAsStringAsync().Result;
      events = JsonConvert.DeserializeObject<List<UfcEvent>>(result);
      return events;
   }



}
