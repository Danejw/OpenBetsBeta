
namespace OpenBetsBeta.Shared.DataAccess;

public interface ISubEventData
{
   Task CreateSubEvent(Organisation org, Event parEvent, SubEvent subEvent);
   Task<SubEvent> GetEventAsync(string id);
   Task<List<SubEvent>> GetSubEventsAsync();
   Task UpdateSubEvent(Organisation org, Event parEvent, SubEvent subEvent);
}