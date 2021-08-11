using System;
using System.Collections.Generic;
using DOService.Models;

namespace DOService.Features.OrganizationRepository
{
    public interface IOrganizationRepository
    {
        OrganziationResponse AddOrganziation(OrganziationRequest request);
        OrganziationResponse GetOrganization(Guid id);
        IEnumerable<OrganziationResponse> GetAllOrganizations();
        OrganziationResponse UpdateOrganziation(Guid id, OrganziationRequest request);
        void DeleteOrganization(Guid id);
    }
}
