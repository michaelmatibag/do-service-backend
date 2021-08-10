using DOService.Models;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly ILogger<OrganizationController> _logger;

        public OrganizationController(ILogger<OrganizationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Organization> GetOrganizations(List<Guid> orgIDs = null)
        {
            return null;
        }

        [HttpPost]
        public IEnumerable<Organization> PostOrganziations(List<Organization> organizations)
        {
            return null;
        }

        [HttpPut]
        public IEnumerable<Organization> PutOrganziations(List<Organization> organizations)
        {
            throw new NotImplementedException();
        }
    }
}
