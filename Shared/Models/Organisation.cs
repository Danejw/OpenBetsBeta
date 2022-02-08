namespace OpenBets.Shared.Models;

public class Organisation
{
    [BsonId] // unique identifer
    [BsonRepresentation(BsonType.ObjectId)] // object id representation
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public List<Event> Events { get; set; } = new List<Event>();
}
