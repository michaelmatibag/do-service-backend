using System;
using System.Linq;
using DOService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DOService.Features.OrganizationRepository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DOServiceContext _context;

        public OrganizationRepository(DOServiceContext context)
        {
            _context = context;
        }

        public OrganizationResponse AddOrganziation(OrganizationRequest request)
        {
            var org = new Organization { Name = request.Name };

            _context.Organizations.Add(org);
            _context.SaveChanges();

            var response = new OrganizationResponse
            {
                Id = org.Id,
                Name = org.Name
            };

            return response;
        }

        public OrganizationResponse GetOrganization(Guid id)
        {
            var org = _context.Organizations.Find(id);

            if (org == null)
                throw new KeyNotFoundException($"Organization with id {id} could not be found.");

            var response = new OrganizationResponse
            {
                Id = org.Id,
                Name = org.Name
            };

            return response;
        }

        public IEnumerable<OrganizationResponse> GetAllOrganizations()
        {
            var orgs = _context.Organizations.Include(x => x.DoiHeaders).OrderBy(org => org.Name);
            var response = new List<OrganizationResponse>();

            foreach (var org in orgs)
            {
                var organization = new OrganizationResponse
                {
                    Id = org.Id,
                    Name = org.Name
                };

                if (org.DoiHeaders.Any())
                {
                    organization.DoiHeaders = new List<DoiHeaderResponse>();
                }

                foreach (var doiHeader in org.DoiHeaders)
                {
                    organization.DoiHeaders.Add(new DoiHeaderResponse
                    {
                        ApprovedDate = doiHeader.ApprovedDate,
                        ApprovedFlag = doiHeader.ApprovedFlag,
                        ApprovedUserId = doiHeader.ApprovedUserId,
                        CreatedDate = doiHeader.ApprovedDate,
                        Description = doiHeader.Description,
                        Id = doiHeader.Id,
                        OrganizationId = doiHeader.OrganizationId
                    });
                }

                response.Add(organization);
            }

            return response;
        }

        public OrganizationResponse UpdateOrganziation(Guid id, OrganizationRequest request)
        {
            var org = _context.Organizations.Find(id);

            if (org == null)
                throw new KeyNotFoundException($"Organization with id {id} could not be found.");

            org.Name = request.Name;

            _context.Organizations.Update(org);
            _context.SaveChanges();

            var response = new OrganizationResponse
            {
                Id = org.Id,
                Name = org.Name
            };

            return response;
        }

        public void DeleteOrganization(Guid id)
        {
            var org = _context.Organizations.Find(id);

            if (org == null)
                throw new KeyNotFoundException($"Organization with id {id} could not be found.");

            _context.Organizations.Remove(org);
            _context.SaveChanges();
        }
    }
}
