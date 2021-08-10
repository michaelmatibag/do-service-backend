using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using DOService.Models;

namespace DOService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoiHeaderController : ControllerBase
    {
        private readonly ILogger<DoiHeaderController> _logger;
        private readonly DOServiceContext _context;

        public DoiHeaderController(ILogger<DoiHeaderController> logger, DOServiceContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<DoiHeader> Get()
        {
            return _context.DoiHeaders.OrderByDescending(x => x.CreatedDate).Take(5);
        }

        [HttpPost]
        public bool Add(DoiHeader doiHeader)
        {
            try
            {
                _context.DoiHeaders.Add(doiHeader);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool Delete(Guid id)
        {
            try
            {
                var item = _context.DoiHeaders.FirstOrDefault(x => x.Id == id);

                if (item == null)
                {
                    throw new KeyNotFoundException();
                }

                _context.DoiHeaders.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        public DoiHeader Update(DoiHeader doiHeader)
        {
            try
            {
                var item = _context.DoiHeaders.FirstOrDefault(x => x.Id == doiHeader.Id);

                if (item == null)
                {
                    throw new KeyNotFoundException();
                }

                item.ApprovedDate = doiHeader.ApprovedDate;
                item.ApprovedFlag = doiHeader.ApprovedFlag;
                item.ApprovedUserId = doiHeader.ApprovedUserId;
                item.Description = doiHeader.Description;
                item.OrganizationId = doiHeader.OrganizationId;

                _context.DoiHeaders.Update(item);
                _context.SaveChanges();

                return _context.DoiHeaders.FirstOrDefault(x => x.Id == item.Id);
            }
            catch
            {
                return null;
            }
        }
    }
}
