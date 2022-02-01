
using Microsoft.Extensions.Caching.Memory;

namespace OpenBetsBeta.Shared.DataAccess;

internal class MongoSubEventData : ISubEventData
{
   private readonly IMongoCollection<SubEvent> _subEvents;
   private readonly IMemoryCache _cache;
   private const string cacheName = "SubEventData";

   public MongoSubEventData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _subEvents = db.SubEventCollection;
   }

   public async Task<List<SubEvent>> GetSubEventsAsync()
   {
      // try getting the cache
      var output = _cache.Get<List<SubEvent>>(cacheName);
      // get the cache is not already
      if (output is null)
      {
         var results = await _subEvents.FindAsync(_ => true);
         output = results.ToList();

         // cache the events every minute
         _cache.Set(cacheName, results, TimeSpan.FromMinutes(1));
      }
      return output;
   }

   public async Task<SubEvent> GetEventAsync(string id)
   {
      var results = await _subEvents.FindAsync(u => u.Id == id);
      return results.FirstOrDefault();
   }

   public Task CreateSubEvent(Organisation org, Event parEvent, SubEvent subEvent)
   {
      var orgEvent = org.Events.Where(e => e.Id == parEvent.Id);
      orgEvent.FirstOrDefault().SubEvents.Add(subEvent);
      return _subEvents.InsertOneAsync(subEvent);
   }

   public Task UpdateSubEvent(Organisation org, Event parEvent, SubEvent subEvent)
   {
      var filter = Builders<SubEvent>.Filter.Where(e => e.Id == parEvent.Id);
      return _subEvents.ReplaceOneAsync(filter, subEvent, new ReplaceOptions { IsUpsert = true });
   }
}
