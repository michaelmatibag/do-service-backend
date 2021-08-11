using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DOService.Models;
using DOService.Features.DoiHeaderRepository;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace DOService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class DoiHeaderController : ControllerBase
    {
        private readonly ILogger<DoiHeaderController> _logger;
        private readonly IDoiHeaderRepository _doiHeaderRepository;

        public DoiHeaderController(ILogger<DoiHeaderController> logger, IDoiHeaderRepository doiHeaderRepository)
        {
            _logger = logger;
            _doiHeaderRepository = doiHeaderRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<DoiHeaderResponse> GetDoiHeader(Guid id)
        {
            try
            {
                return Ok(_doiHeaderRepository.GetDoiHeader(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoiHeaderResponse>> GetDoiHeaders()
        {
            try
            {
                return Ok(_doiHeaderRepository.GetDoiHeaders());
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost]
        public ActionResult<DoiHeaderResponse> AddDoiHeader(DoiHeaderRequest request)
        {
            try
            {
                return Ok(_doiHeaderRepository.AddDoiHeader(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoiHeader(Guid id)
        {
            try
            {
                _doiHeaderRepository.DeleteDoiHeader(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<DoiHeaderResponse> UpdateDoiHeader(Guid id, DoiHeaderRequest request)
        {
            try
            {
                return Ok(_doiHeaderRepository.UpdateDoiHeader(id, request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
