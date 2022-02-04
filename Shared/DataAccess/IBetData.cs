
namespace OpenBets.Shared.DataAccess;

internal interface IBetData
{
   Task CreateBet(Bet bet);
   Task<Bet> GetBetAsync(string id);
   Task<List<Bet>> GetBetsAsync();
   void MatchBet(Bet bet);
}