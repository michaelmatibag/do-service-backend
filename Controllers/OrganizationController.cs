using DOService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DOService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly DOServiceContext _context;

        public OrganizationController(ILogger<OrganizationController> logger, DOServiceContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<ICollection<OrganziationResponse>> GetAllOrganizations()
        {
            try
            {
                var orgs = _context.Organizations.OrderBy(org => org.Name);
                var responses = orgs.Select(org => new OrganziationResponse
                {
                    Id = org.Id,
                    Name = org.Name
                });

                return Ok(responses);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpGet]
        [Route("{orgId}")]
        public ActionResult<OrganziationResponse> GetOrganization(Guid orgId)
        {
            try
            {
                var org = _context.Organizations.Find(orgId);

                if (org == null)
                    return NotFound($"Organization with id {orgId} could not be found.");

                var response = new OrganziationResponse
                {
                    Id = org.Id,
                    Name = org.Name
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost]
        public ActionResult<OrganziationResponse> AddOrganziation(OrganziationRequest request)
        {
            try
            {
                var org = new Organization { Name = request.Name };

                _context.Organizations.Add(org);
                _context.SaveChanges();

                var response = new OrganziationResponse
                {
                    Id = org.Id,
                    Name = org.Name
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut]
        [Route("{orgId}")]
        public ActionResult<OrganziationResponse> UpdateOrganziation(Guid orgId, OrganziationRequest request)
        {
            try
            {
                var org = _context.Organizations.Find(orgId);

                if (org == null)
                    return NotFound($"Organization with id {orgId} could not be found.");

                org.Name = request.Name;

                _context.Organizations.Update(org);
                _context.SaveChanges();

                var response = new OrganziationResponse
                {
                    Id = org.Id,
                    Name = org.Name
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete]
        [Route("{orgId}")]
        public IActionResult DeleteOrganization(Guid orgId)
        {
            try
            {
                var org = _context.Organizations.Find(orgId);

                if (org == null)
                    return NotFound($"Organization with id {orgId} could not be found.");

                _context.Organizations.Remove(org);
                _context.SaveChanges();

                return Ok(null);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
