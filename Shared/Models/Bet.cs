namespace OpenBets.Shared.Models;

public class Bet
{
    [BsonId] // unique identifer
    [BsonRepresentation(BsonType.ObjectId)] // object id representation
    public string Id { get; set; }
    public string TransactionId { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime ScheduledDateTime { get; set; }

    public string Address1 { get; set; }
    public string Address2 { get; set; }

    public Event Event { get; set; }
    public SubEvent SubEvent { get; set; }

    // address 1's wish
    // address 2's wish
    public float Stake { get; set; }

    // outcome
    public string Winner { get; set; }
    public string Loser { get; set; }

    public bool IsDone { get; set; } = false;
    
    
}
