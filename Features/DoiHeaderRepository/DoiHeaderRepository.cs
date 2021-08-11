using System;
using System.Linq;
using DOService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DOService.Features.DoiHeaderRepository
{
    public class DoiHeaderRepository : IDoiHeaderRepository
    {
        private readonly DOServiceContext _context;

        public DoiHeaderRepository(DOServiceContext context)
        {
            _context = context;
        }

        public DoiHeaderResponse AddDoiHeader(DoiHeaderRequest request)
        {
            var organization = _context.Organizations.Find(request.OrganizationId);

            if (organization == null)
            {
                throw new KeyNotFoundException($"Organization with organization_id {request.OrganizationId} could not be found.");
            }

            var item = new DoiHeader
            {
                ApprovedDate = request.ApprovedDate,
                ApprovedFlag = request.ApprovedFlag,
                ApprovedUserId = request.ApprovedUserId,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                Id = Guid.NewGuid(),
                OrganizationId = organization.Id
            };

            _context.DoiHeaders.Add(item);
            _context.SaveChanges();
            
            return new DoiHeaderResponse
            {
                ApprovedDate = item.ApprovedDate,
                ApprovedFlag = item.ApprovedFlag,
                ApprovedUserId = item.ApprovedUserId,
                CreatedDate = item.CreatedDate,
                Description = item.Description,
                Id = item.Id,
                OrganizationId = item.OrganizationId,
                Organization = new OrganizationResponse
                {
                    Id = organization.Id,
                    Name = organization.Name
                } 
            };
        }

        public IEnumerable<DoiHeaderResponse> AddDoiHeaders(IEnumerable<DoiHeaderRequest> request)
        {
            var response = new List<DoiHeaderResponse>();

            foreach (var item in request)
            {
                response.Add(AddDoiHeader(item));
            }

            return response;
        }

        public DoiHeaderResponse GetDoiHeader(Guid id)
        {
            var doiHeader = _context.DoiHeaders
                .Include(x => x.Organization)
                .Include(x => x.DoiOwners)
                .FirstOrDefault(x => x.Id == id);

            if (doiHeader == null)
                throw new KeyNotFoundException($"DOI header with id {id} could not be found.");

            var response = new DoiHeaderResponse
            {
                ApprovedDate = doiHeader.ApprovedDate,
                ApprovedFlag = doiHeader.ApprovedFlag,
                ApprovedUserId = doiHeader.ApprovedUserId,
                CreatedDate = doiHeader.CreatedDate,
                Description = doiHeader.Description,
                Id = doiHeader.Id,
                OrganizationId = doiHeader.OrganizationId,
                Organization = new OrganizationResponse
                {
                    Id = doiHeader.Organization.Id,
                    Name = doiHeader.Organization.Name
                }
            };

            if(doiHeader.DoiOwners.Any())
            {
                response.DoiOwners = doiHeader.DoiOwners.Select(owner => new DoiOwnerResponse
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

        public IEnumerable<DoiHeaderResponse> GetDoiHeaders()
        {
            var response = new List<DoiHeaderResponse>();

            foreach (var item in _context.DoiHeaders.Include(x => x.Organization).Include(x => x.DoiOwners))
            {
                var doiHeader = new DoiHeaderResponse
                {
                    ApprovedDate = item.ApprovedDate,
                    ApprovedFlag = item.ApprovedFlag,
                    ApprovedUserId = item.ApprovedUserId,
                    CreatedDate = item.CreatedDate,
                    Description = item.Description,
                    Id = item.Id,
                    OrganizationId = item.OrganizationId,
                    Organization = new OrganizationResponse
                    {
                        Id = item.Organization.Id,
                        Name = item.Organization.Name
                    }
                };

                if (item.DoiOwners.Any())
                {
                    doiHeader.DoiOwners = item.DoiOwners.Select(owner => new DoiOwnerResponse
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

                response.Add(doiHeader);
            }

            return response;
        }

        public DoiHeaderResponse UpdateDoiHeader(Guid id, DoiHeaderRequest request)
        {
            var item = _context.DoiHeaders.Find(id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Id {id} could not be found.");
            }

            var organization = _context.Organizations.Find(request.OrganizationId);

            if (organization == null)
            {
                throw new KeyNotFoundException($"Organization with organization_id {request.OrganizationId} could not be found.");
            }

            item.ApprovedDate = request.ApprovedDate;
            item.ApprovedFlag = request.ApprovedFlag;
            item.ApprovedUserId = request.ApprovedUserId;
            item.Description = request.Description;
            item.OrganizationId = request.OrganizationId;

            _context.DoiHeaders.Update(item);
            _context.SaveChanges();

            return new DoiHeaderResponse
            {
                ApprovedDate = item.ApprovedDate,
                ApprovedFlag = item.ApprovedFlag,
                ApprovedUserId = item.ApprovedUserId,
                CreatedDate = item.CreatedDate,
                Description = item.Description,
                Id = item.Id,
                OrganizationId = item.OrganizationId,
                Organization = new OrganizationResponse
                {
                    Id = organization.Id,
                    Name = organization.Name
                } 
            };
        }

        public void DeleteDoiHeader(Guid id)
        {
            var item = _context.DoiHeaders.Find(id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Id {id} could not be found.");
            }

            _context.DoiHeaders.Remove(item);
            _context.SaveChanges();
        }
    }
}
