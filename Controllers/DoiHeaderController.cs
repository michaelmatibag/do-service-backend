using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using DOService.Models;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<DoiHeaderResponse> Get(Guid id)
        {
            try
            {
                var doiHeader = _context.DoiHeaders.Include(x => x.Organization).FirstOrDefault(x => x.Id == id);

                return Ok(new DoiHeaderResponse
                {
                    ApprovedDate = doiHeader.ApprovedDate,
                    ApprovedFlag = doiHeader.ApprovedFlag,
                    ApprovedUserId = doiHeader.ApprovedUserId,
                    CreatedDate = doiHeader.CreatedDate,
                    Description = doiHeader.Description,
                    Id = doiHeader.Id,
                    OrganizationId = doiHeader.OrganizationId,
                    Organization = new DoiHeaderOrganization
                    {
                        Id = doiHeader.Organization.Id,
                        Name = doiHeader.Organization.Name
                    }
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost]
        public ActionResult<DoiHeaderResponse> Add(DoiHeaderRequest request)
        {
            try
            {
                var organization = _context.Organizations.Find(request.OrganizationId);

                if (organization == null)
                {
                    return NotFound($"Organization with organization_id {request.OrganizationId} could not be found.");
                }

                var item = new DoiHeader
                {
                    ApprovedDate = request.ApprovedDate,
                    ApprovedFlag = request.ApprovedFlag,
                    ApprovedUserId = request.ApprovedUserId,
                    CreatedDate = DateTime.Now,
                    Description = request.Description,
                    Id = Guid.NewGuid(),
                    OrganizationId = organization.Id
                };

                _context.DoiHeaders.Add(item);
                _context.SaveChanges();
                
                return Ok(new DoiHeaderResponse
                {
                    ApprovedDate = item.ApprovedDate,
                    ApprovedFlag = item.ApprovedFlag,
                    ApprovedUserId = item.ApprovedUserId,
                    CreatedDate = item.CreatedDate,
                    Description = item.Description,
                    Id = item.Id,
                    OrganizationId = item.OrganizationId,
                    Organization = new DoiHeaderOrganization
                    {
                        Id = organization.Id,
                        Name = organization.Name
                    } 
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var item = _context.DoiHeaders.Find(id);

                if (item == null)
                {
                    return NotFound($"Id {id} could not be found.");
                }

                _context.DoiHeaders.Remove(item);
                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult<DoiHeaderResponse> Update(Guid id, DoiHeaderRequest request)
        {
            try
            {
                var item = _context.DoiHeaders.Find(id);

                if (item == null)
                {
                    return NotFound($"Id {id} could not be found.");
                }

                var organization = _context.Organizations.Find(request.OrganizationId);

                if (organization == null)
                {
                    return NotFound($"Organization with organization_id {request.OrganizationId} could not be found.");
                }

                item.ApprovedDate = request.ApprovedDate;
                item.ApprovedFlag = request.ApprovedFlag;
                item.ApprovedUserId = request.ApprovedUserId;
                item.Description = request.Description;
                item.OrganizationId = request.OrganizationId;

                _context.DoiHeaders.Update(item);
                _context.SaveChanges();

                return Ok(new DoiHeaderResponse
                {
                    ApprovedDate = item.ApprovedDate,
                    ApprovedFlag = item.ApprovedFlag,
                    ApprovedUserId = item.ApprovedUserId,
                    CreatedDate = item.CreatedDate,
                    Description = item.Description,
                    Id = item.Id,
                    OrganizationId = item.OrganizationId,
                    Organization = new DoiHeaderOrganization
                    {
                        Id = organization.Id,
                        Name = organization.Name
                    } 
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
