using System;
using System.Collections.Generic;
using DOService.Models;

namespace DOService.Features.DoiHeaderRepository
{
    public interface IDoiHeaderRepository
    {
        DoiHeaderResponse AddDoiHeader(DoiHeaderRequest request);
        IEnumerable<DoiHeaderResponse> AddDoiHeaders(IEnumerable<DoiHeaderRequest> request);
        DoiHeaderResponse GetDoiHeader(Guid id);
        IEnumerable<DoiHeaderResponse> GetDoiHeaders();
        DoiHeaderResponse UpdateDoiHeader(Guid id, DoiHeaderRequest request);
        void DeleteDoiHeader(Guid id);
    }
}
