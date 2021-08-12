using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DOService.Models;
using DOService.Features.DoiOwnerRepository;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace DOService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
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
        public ActionResult<DoiOwnerResponse> GetDoiOwner(Guid id)
        {
            try
            {
                return Ok(_doiOwnerRepository.GetDoiOwner(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoiOwnerResponse>> GetDoiOwners()
        {
            try
            {
                return Ok(_doiOwnerRepository.GetDoiOwners());
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost]
        public ActionResult<DoiOwnerResponse> AddDoiOwner(DoiOwnerRequest request)
        {
            try
            {
                return Ok(_doiOwnerRepository.AddDoiOwner(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoiOwner(Guid id)
        {
            try
            {
                _doiOwnerRepository.DeleteDoiOwner(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<DoiOwnerResponse> UpdateDoiOwner(Guid id, DoiOwnerRequest request)
        {
            try
            {
                return Ok(_doiOwnerRepository.UpdateDoiOwner(id, request));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
