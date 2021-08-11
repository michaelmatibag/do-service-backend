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

        public OrganziationResponse AddOrganziation(OrganziationRequest request)
        {
            var org = new Organization { Name = request.Name };

            _context.Organizations.Add(org);
            _context.SaveChanges();

            var response = new OrganziationResponse
            {
                Id = org.Id,
                Name = org.Name
            };

            return response;
        }

        public OrganziationResponse GetOrganization(Guid id)
        {
            var org = _context.Organizations.Find(id);

            if (org == null)
                throw new KeyNotFoundException($"Organization with id {id} could not be found.");

            var response = new OrganziationResponse
            {
                Id = org.Id,
                Name = org.Name
            };

            return response;
        }

        public IEnumerable<OrganziationResponse> GetAllOrganizations()
        {
            var orgs = _context.Organizations.OrderBy(org => org.Name);
            var responses = orgs.Select(org => new OrganziationResponse
            {
                Id = org.Id,
                Name = org.Name
            });

            return (responses);
        }

        public OrganziationResponse UpdateOrganziation(Guid id, OrganziationRequest request)
        {
            var org = _context.Organizations.Find(id);

            if (org == null)
                throw new KeyNotFoundException($"Organization with id {id} could not be found.");

            org.Name = request.Name;

            _context.Organizations.Update(org);
            _context.SaveChanges();

            var response = new OrganziationResponse
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
