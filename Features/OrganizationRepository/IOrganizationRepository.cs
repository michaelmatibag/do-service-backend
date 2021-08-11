using System;
using System.Collections.Generic;
using DOService.Models;

namespace DOService.Features.OrganizationRepository
{
    public interface IOrganizationRepository
    {
        OrganizationResponse AddOrganization(OrganizationRequest request);
        OrganizationResponse GetOrganization(Guid id);
        IEnumerable<OrganizationResponse> GetOrganizations();
        OrganizationResponse UpdateOrganization(Guid id, OrganizationRequest request);
        void DeleteOrganization(Guid id);
    }
}
