using DOService.Models;
using Npgsql;
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
        public IEnumerable<Organization> GetOrganizations()
        {
            try
            {
                return _context.Organizations.OrderBy(org => org.Name);
            }
            catch (Exception e)
            {
                throw new NpgsqlException($"Failed to get organziations. Error: {e.Message}");
            }
        }

        [HttpPost]
        public bool PostOrganziations(List<Organization> organizations)
        {
            try
            {
                _context.Organizations.AddRange(organizations);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw new NpgsqlException($"Failed to post new organziations. Error: {e.Message}");
            }
        }

        [HttpPut]
        public IEnumerable<Organization> PutOrganziations(List<Organization> organizations)
        {
            throw new NotImplementedException();
        }
    }
}
