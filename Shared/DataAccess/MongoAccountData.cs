namespace OpenBets.Shared.DataAccess;

internal class MongoAccountData : IAccountData
{
   private readonly IMongoCollection<Account> _accounts;


   public MongoAccountData(IDbConnection db)
   {
      _accounts = db.AccountCollection;
   }

   public async Task<List<Account>> GetAccountsAsync()
   {
      var results = await _accounts.FindAsync(_ => true);
      return results.ToList();
   }

   public async Task<Account> GetAccount(string id)
   {
      var results = await _accounts.FindAsync(u => u.Id == id);
      return results.FirstOrDefault();
   }

   public async Task<Account> GetAccountFromAutentication(string objectId)
   {
      var results = await _accounts.FindAsync(u => u.ObjectIdentifier == objectId);
      return results.FirstOrDefault();
   }

   public Task CreateAccount(Account account)
   {
      return _accounts.InsertOneAsync(account);
   }

   public Task UpdateAccount(Account account)
   {
      var filter = Builders<Account>.Filter.Eq("Id", account.Id);
      return _accounts.ReplaceOneAsync(filter, account, new ReplaceOptions { IsUpsert = true });
   }
}
