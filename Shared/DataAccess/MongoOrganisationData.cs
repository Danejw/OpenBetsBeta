using Microsoft.Extensions.Caching.Memory;

namespace OpenBetsBeta.Shared.DataAccess;

public class MongoOrganisationData : IOrganisationData
{
   private readonly IMongoCollection<Organisation> _org;
   private readonly IMemoryCache _cache;
   private const string cacheName = "OrganisationData";

   public MongoOrganisationData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _org = db.OrganisationCollection;
   }

   public async Task<List<Organisation>> GetOrganisationsAsync()
   {
      // try getting the cache
      var output = _cache.Get<List<Organisation>>(cacheName);
      // get the cache is not already
      if (output is null)
      {
         var results = await _org.FindAsync(_ => true);
         output = results.ToList();

         // cache the organisation once a day
         _cache.Set(cacheName, results, TimeSpan.FromDays(1));
      }
      return output;
   }

   public async Task<Organisation> GetOrganisationAsync(string id)
   {
      var results = await _org.FindAsync(u => u.Id == id);
      return results.FirstOrDefault();
   }

   public Task CreateOrganisation(Organisation org)
   {
      return _org.InsertOneAsync(org);
   }

   public Task UpdateOrganisation(Organisation org)
   {
      var filter = Builders<Organisation>.Filter.Eq("Id", org.Id);
      return _org.ReplaceOneAsync(filter, org, new ReplaceOptions { IsUpsert = true });
   }
}
