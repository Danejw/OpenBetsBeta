
namespace OpenBetsBeta.Shared.DataAccess;

internal interface IEventData
{
   Task CreateEvent(Organisation org, Event newEvent);
   Task<Event> GetEventAsync(string id);
   Task<List<Event>> GetEventsAsync();
   Task UpdateEvent(Organisation org, Event updateEvent);
}