namespace OpenBets.Shared.Models;

internal class BasicBet
{
    [BsonRepresentation(BsonType.ObjectId)] // object id representation
    public string Id { get; set; }
    public string TransactionId { get; set; }

    public DateTime ScheduledDateTime { get; set; }

    public Event Event { get; set; }
    public SubEvent SubEvent { get; set; }

    public string Winner { get; set; }
    public string Loser { get; set; }
    public float Stake { get; set; }

    public BasicBet()
    {

    }

    public BasicBet(Bet bet)
    {
        Id = bet.Id;
        TransactionId = bet.TransactionId;
        ScheduledDateTime = bet.ScheduledDateTime;
        Event = bet.Event;
        SubEvent = bet.SubEvent;
        Winner = bet.Winner;
        Loser = bet.Loser;
        Stake = bet.Stake;
    }

}
