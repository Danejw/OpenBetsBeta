namespace OpenBets.Shared.Models;

internal class Event
{
    [BsonId] // unique identifer
    [BsonRepresentation(BsonType.ObjectId)] // object id representation
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime ScheduledDateTime { get; set; }

    public List<SubEvent> SubEvents { get; set; } = new List<SubEvent>();

    public bool IsDone { get; set; } = false;


}
