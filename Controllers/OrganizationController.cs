using DOService.Features.OrganizationRepository;
using DOService.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DOService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
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
        public ActionResult<IEnumerable<OrganizationResponse>> GetOrganizations()
        {
            try
            {
                return Ok(_orgRepository.GetOrganizations());
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OrganizationResponse> GetOrganization(Guid id)
        {
            try
            {
                return Ok(_orgRepository.GetOrganization(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost]
        public ActionResult<OrganizationResponse> AddOrganization(OrganizationRequest request)
        {
            try
            {
                return Ok(_orgRepository.AddOrganization(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<OrganizationResponse> UpdateOrganization(Guid id, OrganizationRequest request)
        {
            try
            {
                return Ok(_orgRepository.UpdateOrganization(id, request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrganization(Guid id)
        {
            try
            {
                _orgRepository.DeleteOrganization(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
