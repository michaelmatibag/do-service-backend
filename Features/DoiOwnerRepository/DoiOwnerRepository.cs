using System;
using System.Linq;
using DOService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DOService.Features.DoiOwnerRepository
{
    public class DoiOwnerRepository : IDoiOwnerRepository
    {
        private readonly DOServiceContext _context;

        public DoiOwnerRepository(DOServiceContext context)
        {
            _context = context;
        }

        public DoiOwnerResponse AddDoiOwner(DoiOwnerRequest request)
        {
            var organization = _context.Organizations.Find(request.OrganizationId);

            if (organization == null)
            {
                throw new KeyNotFoundException($"Organization with organization_id {request.OrganizationId} could not be found.");
            }

            var doiHeader = _context.DoiHeaders.Find(request.DoiHeaderId);

            if (doiHeader == null)
            {
                throw new KeyNotFoundException($"DOI Header with doi_header_id {request.DoiHeaderId} could not be found.");
            }

            var item = new DoiOwner
            {
                BurdenGroupId = request.BurdenGroupId,
                CreatedDate = DateTime.Now,
                DoiHeaderId = request.DoiHeaderId,
                EffectiveFromDate = request.EffectiveFromDate,
                EffectiveToDate = request.EffectiveToDate,
                Id = Guid.NewGuid(),
                InterestType = request.InterestType,
                NriDecimal = request.NriDecimal,
                OrganizationId = organization.Id,
                OwnerId = request.OwnerId,
                OwnerName = request.OwnerName,
                PayCode = request.PayCode,
                SuspenseReason = request.SuspenseReason
            };

            _context.DoiOwners.Add(item);
            _context.SaveChanges();
            
            return new DoiOwnerResponse
            {
                BurdenGroupId = item.BurdenGroupId,
                CreatedDate = item.CreatedDate,
                DoiHeaderId = item.DoiHeaderId,
                EffectiveFromDate = item.EffectiveFromDate,
                EffectiveToDate = item.EffectiveToDate,
                Id = item.Id,
                InterestType = item.InterestType,
                NriDecimal = item.NriDecimal,
                OrganizationId = item.OrganizationId,
                OwnerId = item.OwnerId,
                OwnerName = item.OwnerName,
                PayCode = item.PayCode,
                SuspenseReason = item.SuspenseReason,
                Organziation = new OrganziationResponse
                {
                    Id = organization.Id,
                    Name = organization.Name
                },
                DoiHeader = new DoiOwnerResponseDoiHeader
                {
                    ApprovedDate = doiHeader.ApprovedDate,
                    ApprovedFlag = doiHeader.ApprovedFlag,
                    ApprovedUserId = doiHeader.ApprovedUserId,
                    CreatedDate = doiHeader.CreatedDate,
                    Description = doiHeader.Description,
                    Id = doiHeader.Id,
                    OrganizationId = doiHeader.OrganizationId
                }
            };
        }

        public IEnumerable<DoiOwnerResponse> AddDoiOwners(IEnumerable<DoiOwnerRequest> request)
        {
            var response = new List<DoiOwnerResponse>();

            foreach (var item in request)
            {
                response.Add(AddDoiOwner(item));
            }

            return response;
        }

        public DoiOwnerResponse GetDoiOwner(Guid id)
        {
            var doiOwner = _context.DoiOwners.Include(x => x.Organization).Include(x => x.DoiHeader).FirstOrDefault(x => x.Id == id);

            return new DoiOwnerResponse
            {
                BurdenGroupId = doiOwner.BurdenGroupId,
                CreatedDate = doiOwner.CreatedDate,
                DoiHeaderId = doiOwner.DoiHeaderId,
                EffectiveFromDate = doiOwner.EffectiveFromDate,
                EffectiveToDate = doiOwner.EffectiveToDate,
                Id = doiOwner.Id,
                InterestType = doiOwner.InterestType,
                NriDecimal = doiOwner.NriDecimal,
                OrganizationId = doiOwner.OrganizationId,
                OwnerId = doiOwner.OwnerId,
                OwnerName = doiOwner.OwnerName,
                PayCode = doiOwner.PayCode,
                SuspenseReason = doiOwner.SuspenseReason,
                Organziation = new OrganziationResponse
                {
                    Id = doiOwner.Organization.Id,
                    Name = doiOwner.Organization.Name
                },
                DoiHeader = new DoiOwnerResponseDoiHeader
                {
                    ApprovedDate = doiOwner.DoiHeader.ApprovedDate,
                    ApprovedFlag = doiOwner.DoiHeader.ApprovedFlag,
                    ApprovedUserId = doiOwner.DoiHeader.ApprovedUserId,
                    CreatedDate = doiOwner.DoiHeader.CreatedDate,
                    Description = doiOwner.DoiHeader.Description,
                    Id = doiOwner.DoiHeader.Id,
                    OrganizationId = doiOwner.DoiHeader.OrganizationId
                }
            };
        }

        public IEnumerable<DoiOwnerResponse> GetDoiOwners()
        {
            var response = new List<DoiOwnerResponse>();

            foreach (var item in _context.DoiOwners.Include(x => x.Organization))
            {
                response.Add(new DoiOwnerResponse
                {
                    BurdenGroupId = item.BurdenGroupId,
                    CreatedDate = item.CreatedDate,
                    DoiHeaderId = item.DoiHeaderId,
                    EffectiveFromDate = item.EffectiveFromDate,
                    EffectiveToDate = item.EffectiveToDate,
                    Id = item.Id,
                    InterestType = item.InterestType,
                    NriDecimal = item.NriDecimal,
                    OrganizationId = item.OrganizationId,
                    OwnerId = item.OwnerId,
                    OwnerName = item.OwnerName,
                    PayCode = item.PayCode,
                    SuspenseReason = item.SuspenseReason,
                    Organziation = new OrganziationResponse
                    {
                        Id = item.Organization.Id,
                        Name = item.Organization.Name
                    },
                    DoiHeader = new DoiOwnerResponseDoiHeader
                    {
                        ApprovedDate = item.DoiHeader.ApprovedDate,
                        ApprovedFlag = item.DoiHeader.ApprovedFlag,
                        ApprovedUserId = item.DoiHeader.ApprovedUserId,
                        CreatedDate = item.DoiHeader.CreatedDate,
                        Description = item.DoiHeader.Description,
                        Id = item.DoiHeader.Id,
                        OrganizationId = item.DoiHeader.OrganizationId
                    }
                });
            }

            return response;
        }

        public DoiOwnerResponse UpdateDoiOwner(Guid id, DoiOwnerRequest request)
        {
            var item = _context.DoiOwners.Find(id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Id {id} could not be found.");
            }

            var organization = _context.Organizations.Find(request.OrganizationId);

            if (organization == null)
            {
                throw new KeyNotFoundException($"Organization with organization_id {request.OrganizationId} could not be found.");
            }

            var doiHeader = _context.DoiHeaders.Find(request.DoiHeaderId);

            if (doiHeader == null)
            {
                throw new KeyNotFoundException($"DOI Header with doi_header_id {request.DoiHeaderId} could not be found.");
            }

            item.BurdenGroupId = request.BurdenGroupId;
            item.DoiHeaderId = request.DoiHeaderId;
            item.EffectiveFromDate = request.EffectiveFromDate;
            item.EffectiveToDate = request.EffectiveToDate;
            item.InterestType = request.InterestType;
            item.NriDecimal = request.NriDecimal;
            item.OrganizationId = request.OrganizationId;
            item.OwnerId = request.OwnerId;
            item.OwnerName = request.OwnerName;
            item.PayCode = request.PayCode;
            item.SuspenseReason = request.SuspenseReason;

            _context.DoiOwners.Update(item);
            _context.SaveChanges();

            return new DoiOwnerResponse
            {
                BurdenGroupId = item.BurdenGroupId,
                CreatedDate = item.CreatedDate,
                DoiHeaderId = item.DoiHeaderId,
                EffectiveFromDate = item.EffectiveFromDate,
                EffectiveToDate = item.EffectiveToDate,
                Id = item.Id,
                InterestType = item.InterestType,
                NriDecimal = item.NriDecimal,
                OrganizationId = item.OrganizationId,
                OwnerId = item.OwnerId,
                OwnerName = item.OwnerName,
                PayCode = item.PayCode,
                SuspenseReason = item.SuspenseReason,
                Organziation = new OrganziationResponse
                {
                    Id = item.Organization.Id,
                    Name = item.Organization.Name
                },
                DoiHeader = new DoiOwnerResponseDoiHeader
                {
                    ApprovedDate = item.DoiHeader.ApprovedDate,
                    ApprovedFlag = item.DoiHeader.ApprovedFlag,
                    ApprovedUserId = item.DoiHeader.ApprovedUserId,
                    CreatedDate = item.DoiHeader.CreatedDate,
                    Description = item.DoiHeader.Description,
                    Id = item.DoiHeader.Id,
                    OrganizationId = item.DoiHeader.OrganizationId
                }
            };
        }

        public void DeleteDoiOwner(Guid id)
        {
            var item = _context.DoiOwners.Find(id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Id {id} could not be found.");
            }

            _context.DoiOwners.Remove(item);
            _context.SaveChanges();
        }
    }
}