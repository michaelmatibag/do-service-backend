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
            var result = _context.DoiHeaders.Take(5);

            Console.WriteLine(result.Count());

            return result;
        }
    }
}
