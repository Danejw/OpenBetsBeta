using Microsoft.Extensions.Caching.Memory;

namespace OpenBetsBeta.Shared.DataAccess;

internal class MongoEventData : IEventData
{
   private readonly IMongoCollection<Event> _events;
   private readonly IMemoryCache _cache;
   private const string cacheName = "EventData";

   public MongoEventData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _events = db.EventCollection;
   }

   public async Task<List<Event>> GetEventsAsync()
   {
      // try getting the cache
      var output = _cache.Get<List<Event>>(cacheName);
      // get the cache is not already
      if (output is null)
      {
         var results = await _events.FindAsync(_ => true);
         output = results.ToList();

         // cache the events every minute
         _cache.Set(cacheName, results, TimeSpan.FromMinutes(1));
      }
      return output;
   }

   public async Task<Event> GetEventAsync(string id)
   {
      var results = await _events.FindAsync(u => u.Id == id);
      return results.FirstOrDefault();
   }

   public Task CreateEvent(Organisation org, Event newEvent)
   {
      org.Events.Add(newEvent);
      return _events.InsertOneAsync(newEvent);
   }

   public Task UpdateEvent(Organisation org, Event updateEvent)
   {
      var filter = Builders<Event>.Filter.Where(e => e.Id == updateEvent.Id);
      return _events.ReplaceOneAsync(filter, updateEvent, new ReplaceOptions { IsUpsert = true });
   }
}
