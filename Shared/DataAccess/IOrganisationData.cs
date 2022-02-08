
namespace OpenBetsBeta.Shared.DataAccess;

public interface IOrganisationData
{
   Task CreateOrganisation(Organisation org);
   Task<Organisation> GetOrganisationAsync(string id);
   Task<List<Organisation>> GetOrganisationsAsync();
   Task UpdateOrganisation(Organisation org);
}