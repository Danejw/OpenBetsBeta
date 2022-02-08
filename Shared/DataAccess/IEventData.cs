
namespace OpenBetsBeta.Shared.DataAccess;

public interface IEventData
{
   Task CreateEvent(Organisation org, Event newEvent);
   Task<Event> GetEventAsync(string id);
   Task<List<Event>> GetEventsAsync();
   Task UpdateEvent(Organisation org, Event updateEvent);
}