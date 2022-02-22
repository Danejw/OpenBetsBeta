using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace OpenBetsBeta.Shared.API;

public class StellarAPI
{
   private HttpClient client;
   private const string stellarExpertEndpoint = "https://api.stellar.expert/explorer/directory?";

   // examples
   // Search for Kraken's deposit account
   // https://api.stellar.expert/explorer/directory?search=kraken
   // Find accounts tagged as malicious or unsafe
   // https://api.stellar.expert/explorer/directory?tag[]=malicious&tag[]=unsafe
   // Lookup addresses reported for "staking"-related scams
   // https://api.stellar.expert/explorer/directory?tag[]=malicious&search=stacking

   // https://api.stellar.expert/explorer/public/asset/{asset}/holders


   public StellarAPI()
   {
      //client = new HttpClient();
   }

   public async Task<string> GetStellarExpertApi()
   {
      client = new HttpClient();
      var response = await client.GetAsync(
         "https://api.stellar.expert/explorer/public/asset/EURT-GAP5LETOV6YIE62YAM56STDANPRDO7ZFDBGSNHJQIYGGKSMOZAHOOS2S/holders"
         );
      //client.DefaultRequestHeaders.Add("accept", "application/json");
      //client.DefaultRequestHeaders.Add("content-type", "application/json");

      response.EnsureSuccessStatusCode();
      return await response.Content.ReadAsStringAsync();
   }

   public async Task<HttpResponseMessage> GetStellarHolders()
   {
      HttpClient client = new HttpClient();


      HttpRequestMessage request =    
         new HttpRequestMessage(HttpMethod.Get,
         "https://api.stellar.expert/explorer/public/asset/EURT-GAP5LETOV6YIE62YAM56STDANPRDO7ZFDBGSNHJQIYGGKSMOZAHOOS2S/holders?order=asc&limit=10&cursor=500"
         );
      
      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      //client.DefaultRequestHeaders.Accept.Clear();
      //client.DefaultRequestHeaders.Accept.Add(new("application/json"));

      return await client.SendAsync(request);
   }

   public async Task<HttpResponseMessage> GetStellarResponse()
   {
      client = new HttpClient();

      using var httpResponse = await client.GetAsync(
         "https://api.stellar.expert/explorer/public/asset/EURT-GAP5LETOV6YIE62YAM56STDANPRDO7ZFDBGSNHJQIYGGKSMOZAHOOS2S/holders", 
         HttpCompletionOption.ResponseHeadersRead);

      httpResponse.EnsureSuccessStatusCode();

      if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
      {
         var contentStream = await httpResponse.Content.ReadAsStreamAsync();

         using var streamReader = new StreamReader(contentStream);
         using var jsonReader = new JsonTextReader(streamReader);

         JsonSerializer serializer = new JsonSerializer();

         try {
            return serializer.Deserialize<HttpResponseMessage>(jsonReader);
         }
         catch (JsonReaderException) {
            Console.WriteLine("Invalid Json");
         }
      }
      else
         Console.WriteLine("HTTP response was invalid and cannot be deserialized");
      
      return null;
   }
}
