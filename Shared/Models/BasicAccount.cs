namespace OpenBets.Shared.Models;

internal class BasicAccount
{
    [BsonRepresentation(BsonType.ObjectId)] // object id representation
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PublicAddress { get; set; }

    public BasicAccount()
    {

    }

    public BasicAccount(Account account)
    {
        Id = account.Id;
        Name = account.Name;
        Description = account.Description;
        PublicAddress = account.PublicAddress;
    }
}
