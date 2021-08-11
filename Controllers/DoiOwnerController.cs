using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DOService.Models;
using DOService.Features.DoiOwnerRepository;
using System.Collections.Generic;

namespace DOService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoiOwnerController : ControllerBase
    {
        private readonly ILogger<DoiOwnerController> _logger;
        private readonly IDoiOwnerRepository _doiOwnerRepository;

        public DoiOwnerController(ILogger<DoiOwnerController> logger, IDoiOwnerRepository doiOwnerRepository)
        {
            _logger = logger;
            _doiOwnerRepository = doiOwnerRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<DoiHeaderResponse> GetDoiHeader(Guid id)
        {
            try
            {
                return Ok(_doiOwnerRepository.GetDoiHeader(id));
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
                return Ok(_doiOwnerRepository.GetDoiHeaders());
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost("{request}")]
        public ActionResult<DoiHeaderResponse> AddDoiHeader(DoiHeaderRequest request)
        {
            try
            {
                return Ok(_doiOwnerRepository.AddDoiHeader(request));
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
                _doiOwnerRepository.DeleteDoiHeader(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut("{id}/{request}")]
        public ActionResult<DoiHeaderResponse> UpdateDoiHeader(Guid id, DoiHeaderRequest request)
        {
            try
            {
                return Ok(_doiOwnerRepository.UpdateDoiHeader(id, request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
