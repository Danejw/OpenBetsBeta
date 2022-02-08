
namespace OpenBets.Shared.DataAccess;

public interface IDbConnection
{
   IMongoCollection<Account> AccountCollection { get; }
   string AccountCollectionName { get; }
   IMongoCollection<Bet> BetCollection { get; }
   string BetCollectionName { get; }
   MongoClient Client { get; }
   string DatabaseName { get; }
   IMongoCollection<Event> EventCollection { get; }
   string EventCollectionName { get; }
   IMongoCollection<Organisation> OrganisationCollection { get; }
   string OrganisationCollectionName { get; }
   IMongoCollection<SubEvent> SubEventCollection { get; }
   string SubEventCollectionName { get; }
}