using System;
using System.Collections.Generic;
using DOService.Models;

namespace DOService.Features.DoiOwnerRepository
{
    public interface IDoiOwnerRepository
    {
        DoiOwnerResponse AddDoiOwner(DoiOwnerRequest request);
        IEnumerable<DoiOwnerResponse> AddDoiOwners(IEnumerable<DoiOwnerRequest> request);
        DoiOwnerResponse GetDoiOwner(Guid id);
        IEnumerable<DoiOwnerResponse> GetDoiOwners();
        DoiOwnerResponse UpdateDoiOwner(Guid id, DoiOwnerRequest request);
        void DeleteDoiOwner(Guid id);
    }
}
