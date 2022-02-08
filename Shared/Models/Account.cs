namespace OpenBets.Shared.Models;

public class Account
{
    [BsonId] // unique identifer
    [BsonRepresentation(BsonType.ObjectId)] // object id representation
    public string Id { get; set; }
    public string ObjectIdentifier { get; set; } // azure identifier
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string PublicAddress { get; set; }
    public string Description { get; set; }

    // profile pic
    // rewards

    public float Reserves { get; set; } // amount of buying power
    public float Locked { get; set; } // amount locked waiting to outcomes
    

    public List<BasicBet> PastBets { get; set; } = new List<BasicBet>();
    public List<BasicBet> PendingBets { get; set; } = new List<BasicBet>();
    public List<BasicBet> OpenBets { get; set; } = new List<BasicBet>();
}
