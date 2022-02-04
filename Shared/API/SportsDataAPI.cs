namespace OpenBets.Shared.API;

public static class SportsDataAPI
{
   // needs to be created once per application
   private static readonly HttpClient HttpClient;

   // SportsData.io MMA data
   private const string API_Key = "27c99f4173ba435590ff64746b6bd69e";

   private static readonly string fighterEndpoint = "https://api.sportsdata.io/v3/mma/scores/json/Fighter/{fighterid}"; // every 1 hour
   private static readonly string fightersEndpoint = "https://api.sportsdata.io/v3/mma/scores/json/Fighters"; // every 1 hour
   private static readonly string scheduleEndpoint = "https://api.sportsdata.io/v3/mma/scores/json/Schedule/{league}/{season}"; // every 1 hour
   private static readonly string eventEndpoint = "https://api.sportsdata.io/v3/mma/scores/json/Event/"; // every 1 minute
   private static readonly string fightEndpoint = "https://api.sportsdata.io/v3/mma/stats/json/Fight/{fightid}"; // every 10 seconds

   private static string fighterResponse;
   private static string fightersResponse;
   private static string scheduleResponse;
   private static string eventResponse;
   private static string fightResponse;

   static SportsDataAPI()
   {
      HttpClient = new HttpClient();

      fightersResponse = GetAllFighters();
      fighterResponse = GetFighter();
      scheduleResponse = GetSchedule();
      eventResponse = GetEvent();
      fightResponse = GetFight();
   }

   
   private static async Task<string> GetResponse(string endpoint)
   {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
         var response = await HttpClient.GetAsync(endpoint);
         response.EnsureSuccessStatusCode();
         string responseBody = await response.Content.ReadAsStringAsync();
         // Above three lines can be replaced with new helper method below
         // string responseBody = await client.GetStringAsync(uri);
         Console.WriteLine(responseBody);
         return responseBody;
      }
      catch (HttpRequestException e)
      {
         Console.WriteLine("\nException Caught!");
         Console.WriteLine("Message :{0} ", e.Message);
         return null;
      }
   }

   public static string GetAllFighters()
   {
      return fightersResponse = GetResponse(fightersEndpoint).Result;
   }

   public static string GetFighter()
   {     
      return GetResponse(fighterEndpoint).Result;
   }

   public static string GetSchedule()
   {
      return scheduleResponse = GetResponse(scheduleEndpoint).Result;
   }

   public static string GetEvent()
   {
      return eventResponse = GetResponse(eventEndpoint + "1").Result;
   }

   public static string GetFight()
   {
      return fightResponse = GetResponse(fightEndpoint).Result;
   }
}
