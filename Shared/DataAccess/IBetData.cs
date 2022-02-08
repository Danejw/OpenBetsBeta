
namespace OpenBetsBeta.Shared.DataAccess;

public interface IBetData
{
   Task CreateBet(Bet bet);
   Task<Bet> GetBetAsync(string id);
   Task<List<Bet>> GetBetsAsync();
   void MatchBet(Bet bet);
}