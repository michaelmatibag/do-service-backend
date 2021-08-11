using DOService.Features.OrganizationRepository;
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
        private readonly IOrganizationRepository _orgRepository;

        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationRepository orgRepository)
        {
            _logger = logger;
            _orgRepository = orgRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<OrganziationResponse>> GetAllOrganizations()
        {
            try
            {
                return Ok(_orgRepository.GetAllOrganizations());
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpGet("{orgId}")]
        public ActionResult<OrganziationResponse> GetOrganization(Guid orgId)
        {
            try
            {
                return Ok(_orgRepository.GetOrganization(orgId));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost("{request}")]
        public ActionResult<OrganziationResponse> AddOrganziation(OrganziationRequest request)
        {
            try
            {
                return Ok(_orgRepository.AddOrganziation(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut("{orgId}/{request}")]
        public ActionResult<OrganziationResponse> UpdateOrganziation(Guid orgId, OrganziationRequest request)
        {
            try
            {
                return Ok(_orgRepository.UpdateOrganziation(orgId, request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete("{orgId}")]
        public IActionResult DeleteOrganization(Guid orgId)
        {
            try
            {
                _orgRepository.DeleteOrganization(orgId);
                return Ok(null);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
