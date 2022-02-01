using Microsoft.Extensions.Caching.Memory;
using OpenBets.Shared.DataAccess;

namespace OpenBetsBeta.Shared.DataAccess;

internal class MongoBetData : IBetData
{
   private readonly IMongoCollection<Bet> _bets;
   private readonly IMemoryCache _cache;
   private const string cacheName = "BetData";

   public MongoBetData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _bets = db.BetCollection;
   }

   public async Task<List<Bet>> GetBetsAsync()
   {
      // trying to get a cache
      var output = _cache.Get<List<Bet>>(cacheName);
      // cache if not already
      if (output is null)
      {
         var results = await _bets.FindAsync(_ => true);
         output = results.ToList();

         // cache every minute
         _cache.Set(cacheName, output, TimeSpan.FromMinutes(1));
      }
      return output;
   }

   public async Task<Bet> GetBetAsync(string id)
   {
      var result = await _bets.FindAsync(id);
      return result.FirstOrDefault();
   }

   public Task CreateBet(Bet bet)
   {
      return _bets.InsertOneAsync(bet);
   }

   public void MatchBet(Bet bet)
   {
      var foundBet = GetBetAsync(bet.Id);
      if (!bet.IsDone || DateTime.Now <= bet.ScheduledDateTime)
      {
         //do match

      }
   }
}
