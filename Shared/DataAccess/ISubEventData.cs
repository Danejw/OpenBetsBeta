
namespace OpenBets.Shared.DataAccess;

internal interface ISubEventData
{
   Task CreateSubEvent(Organisation org, Event parEvent, SubEvent subEvent);
   Task<SubEvent> GetEventAsync(string id);
   Task<List<SubEvent>> GetSubEventsAsync();
   Task UpdateSubEvent(Organisation org, Event parEvent, SubEvent subEvent);
}