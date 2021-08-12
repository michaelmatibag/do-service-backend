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

        public OrganizationResponse AddOrganization(OrganizationRequest request)
        {
            var org = new Organization { Name = request.Name };

            _context.Organizations.Add(org);
            _context.SaveChanges();

            var response = new OrganizationResponse
            {
                Id = org.Id,
                Name = org.Name,
                Quti = org.Quti
            };

            return response;
        }

        public OrganizationResponse GetOrganization(Guid id)
        {
            var org = _context.Organizations
                .Include(org => org.DoiHeaders)
                .Include(org => org.DoiOwners)
                .FirstOrDefault(org => org.Id == id);

            if (org == null)
                throw new KeyNotFoundException($"Organization with id {id} could not be found.");

            var response = new OrganizationResponse
            {
                Id = org.Id,
                Name = org.Name,
                Quti = org.Quti
            };

            if(org.DoiHeaders.Any())
            {
                var doiHeaderResponses = new List<DoiHeaderResponse>();
                foreach (var doiHeader in org.DoiHeaders)
                {
                     var doiHeaderResponse = new DoiHeaderResponse
                     {
                        ApprovedDate = doiHeader.ApprovedDate,
                        ApprovedFlag = doiHeader.ApprovedFlag,
                        ApprovedUserId = doiHeader.ApprovedUserId,
                        CreatedDate = doiHeader.ApprovedDate,
                        Description = doiHeader.Description,
                        Id = doiHeader.Id,
                        OrganizationId = doiHeader.OrganizationId
                     };

                    if(org.DoiOwners.Any())
                    {
                        doiHeaderResponse.DoiOwners = org.DoiOwners
                            .Where(owner => owner.DoiHeaderId ==  doiHeaderResponse.Id)
                            .Select(owner => new DoiOwnerResponse
                        {
                            BurdenGroupId = owner.BurdenGroupId,
                            CreatedDate = owner.CreatedDate,
                            DoiHeaderId = owner.DoiHeaderId,
                            EffectiveFromDate = owner.EffectiveFromDate,
                            EffectiveToDate = owner.EffectiveToDate,
                            Id = owner.Id,
                            InterestType = owner.InterestType,
                            NriDecimal = owner.NriDecimal,
                            OrganizationId = owner.OrganizationId,
                            OwnerId = owner.OwnerId,
                            OwnerName = owner.OwnerName,
                            PayCode = owner.PayCode,
                            SuspenseReason = owner.SuspenseReason
                        });
                    }
                    doiHeaderResponses.Add(doiHeaderResponse);
                }

                response.DoiHeaders = doiHeaderResponses;
            }

            var date = DateTime.Now;
            if(org.DoiOwners.Any())
            {
                response.ActiveOwners = org.DoiOwners
                        .Where(owner => owner.EffectiveFromDate <= date && date <= owner.EffectiveToDate)
                        .Select(owner => new DoiOwnerResponse
                {
                    BurdenGroupId = owner.BurdenGroupId,
                    CreatedDate = owner.CreatedDate,
                    DoiHeaderId = owner.DoiHeaderId,
                    EffectiveFromDate = owner.EffectiveFromDate,
                    EffectiveToDate = owner.EffectiveToDate,
                    Id = owner.Id,
                    InterestType = owner.InterestType,
                    NriDecimal = owner.NriDecimal,
                    OrganizationId = owner.OrganizationId,
                    OwnerId = owner.OwnerId,
                    OwnerName = owner.OwnerName,
                    PayCode = owner.PayCode,
                    SuspenseReason = owner.SuspenseReason
                });
            }

            return response;
        }

        public IEnumerable<OrganizationResponse> GetOrganizations()
        {
            var response = new List<OrganizationResponse>();

            foreach (var org in _context.Organizations
                .Include(org => org.DoiHeaders)
                .Include(org => org.DoiOwners)
                .OrderBy(org => org.Name))
            {
                var organization = new OrganizationResponse
                {
                    Id = org.Id,
                    Name = org.Name,
                    Quti = org.Quti
                };

                if (org.DoiHeaders.Any())
                {
                    var doiHeaderResponses = new List<DoiHeaderResponse>();
                    foreach (var doiHeader in org.DoiHeaders)
                    {
                        var doiHeaderResponse = new DoiHeaderResponse
                        {
                            ApprovedDate = doiHeader.ApprovedDate,
                            ApprovedFlag = doiHeader.ApprovedFlag,
                            ApprovedUserId = doiHeader.ApprovedUserId,
                            CreatedDate = doiHeader.ApprovedDate,
                            Description = doiHeader.Description,
                            Id = doiHeader.Id,
                            OrganizationId = doiHeader.OrganizationId
                        };

                        if (org.DoiOwners.Any())
                        {
                            doiHeaderResponse.DoiOwners = org.DoiOwners
                                .Where(owner => owner.DoiHeaderId == doiHeaderResponse.Id)
                                .Select(owner => new DoiOwnerResponse
                                {
                                    BurdenGroupId = owner.BurdenGroupId,
                                    CreatedDate = owner.CreatedDate,
                                    DoiHeaderId = owner.DoiHeaderId,
                                    EffectiveFromDate = owner.EffectiveFromDate,
                                    EffectiveToDate = owner.EffectiveToDate,
                                    Id = owner.Id,
                                    InterestType = owner.InterestType,
                                    NriDecimal = owner.NriDecimal,
                                    OrganizationId = owner.OrganizationId,
                                    OwnerId = owner.OwnerId,
                                    OwnerName = owner.OwnerName,
                                    PayCode = owner.PayCode,
                                    SuspenseReason = owner.SuspenseReason
                                });
                        }
                        doiHeaderResponses.Add(doiHeaderResponse);
                    }

                    organization.DoiHeaders = doiHeaderResponses;
                }

                var date = DateTime.Now;
                if (org.DoiOwners.Any())
                {
                    organization.ActiveOwners = org.DoiOwners
                        .Where(owner => owner.EffectiveFromDate <= date && date <= owner.EffectiveToDate)
                        .Select(owner => new DoiOwnerResponse
                    {
                        BurdenGroupId = owner.BurdenGroupId,
                        CreatedDate = owner.CreatedDate,
                        DoiHeaderId = owner.DoiHeaderId,
                        EffectiveFromDate = owner.EffectiveFromDate,
                        EffectiveToDate = owner.EffectiveToDate,
                        Id = owner.Id,
                        InterestType = owner.InterestType,
                        NriDecimal = owner.NriDecimal,
                        OrganizationId = owner.OrganizationId,
                        OwnerId = owner.OwnerId,
                        OwnerName = owner.OwnerName,
                        PayCode = owner.PayCode,
                        SuspenseReason = owner.SuspenseReason
                    });
                }

                response.Add(organization);
            }

            return response;
        }

        public OrganizationResponse UpdateOrganization(Guid id, OrganizationRequest request)
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
                Name = org.Name,
                Quti = org.Quti
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
