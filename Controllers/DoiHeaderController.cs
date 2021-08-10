using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
