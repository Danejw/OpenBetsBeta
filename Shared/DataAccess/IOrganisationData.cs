
namespace OpenBets.Shared.DataAccess;

internal interface IOrganisationData
{
   Task CreateOrganisation(Organisation org);
   Task<Organisation> GetOrganisationAsync(string id);
   Task<List<Organisation>> GetOrganisationsAsync();
   Task UpdateOrganisation(Organisation org);
}