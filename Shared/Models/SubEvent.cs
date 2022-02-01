namespace OpenBets.Shared.Models;

internal class SubEvent
{
    [BsonId] // unique identifer
    [BsonRepresentation(BsonType.ObjectId)] // object id representation
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;
    public DateTime ScheduledDateTime { get; set; }

    public bool IsDone { get; set; } = false;

    // possible outcomes
}
