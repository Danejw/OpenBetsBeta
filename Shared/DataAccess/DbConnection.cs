using Microsoft.Extensions.Configuration;

namespace OpenBets.Shared.DataAccess;

public class DbConnection : IDbConnection
{
   private readonly IConfiguration _config;
   private readonly IMongoDatabase _db;
   private string _connectionId = "MongoDB";

   // sets the names of each collection
   public string DatabaseName { get; private set; }
   public string AccountCollectionName { get; private set; } = "accounts";
   public string BetCollectionName { get; private set; } = "bets";
   public string OrganisationCollectionName { get; private set; } = "organisations";
   public string EventCollectionName { get; private set; } = "events";
   public string SubEventCollectionName { get; private set; } = "subevents";

   public MongoClient Client { get; private set; }

   // actual connections of the model database, similar to tables in other db concepts
   public IMongoCollection<Account> AccountCollection { get; private set; }
   public IMongoCollection<Bet> BetCollection { get; private set; }
   public IMongoCollection<Organisation> OrganisationCollection { get; private set; }
   public IMongoCollection<Event> EventCollection { get; private set; }
   public IMongoCollection<SubEvent> SubEventCollection { get; private set; }

   // initialize the database
   public DbConnection(IConfiguration config)
   {
      _config = config;
      // get the connection dtring form mongo db
      Client = new MongoClient(_config.GetConnectionString(_connectionId));
      // gets the database name from the config file. appsetting.json
      DatabaseName = _config["DatabaseName"];
      _db = Client.GetDatabase(DatabaseName);

      AccountCollection = _db.GetCollection<Account>(AccountCollectionName);
      BetCollection = _db.GetCollection<Bet>(BetCollectionName);
      OrganisationCollection = _db.GetCollection<Organisation>(OrganisationCollectionName);
      EventCollection = _db.GetCollection<Event>(EventCollectionName);
      SubEventCollection = _db.GetCollection<SubEvent>(SubEventCollectionName);
   }
}
