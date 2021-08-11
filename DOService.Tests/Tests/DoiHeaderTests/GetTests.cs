using DOService.Controllers;
using DOService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOService.Tests.FakeDbContexts.DoiHeaderContext;
using Microsoft.EntityFrameworkCore;
using DOService.Features.DoiHeaderRepository;

namespace DOService.Tests.DoiHeaderTests
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void GetDoiHeaders_ShouldReturnAllDoiHeaders()
        {
            using (var context = new DoiHeaderContext("GetTests.GetDoiHeaders"))
            {
                //Arrange
                context.SeedDatabase();

                //Act
                var action = new DoiHeaderController(null, new DoiHeaderRepository(context.ServiceContext)).GetDoiHeaders().Result as OkObjectResult;

                //Assert
                Assert.AreEqual(3, (action.Value as IEnumerable<DoiHeaderResponse>).Count());
            }
        }

        [TestMethod]
        public void GetDoiHeader_ShouldReturnADoiHeader()
        {
            using (var context = new DoiHeaderContext("GetTests.GetDoiHeader"))
            {
                //Arrange
                context.SeedDatabase();

                var doiHeader = context.ServiceContext.DoiHeaders.Include(x => x.Organization).First();

                //Act
                var action = new DoiHeaderController(null, new DoiHeaderRepository(context.ServiceContext)).GetDoiHeader(doiHeader.Id).Result as OkObjectResult;

                //Assert
                var result = action.Value as DoiHeaderResponse;

                Assert.AreEqual(doiHeader.Id, result.Id);
                Assert.AreEqual(doiHeader.Description, result.Description);
                Assert.AreEqual(doiHeader.ApprovedFlag, result.ApprovedFlag);
                Assert.AreEqual(doiHeader.ApprovedDate, result.ApprovedDate);
                Assert.AreEqual(doiHeader.ApprovedUserId, result.ApprovedUserId);
                Assert.AreEqual(doiHeader.CreatedDate, result.CreatedDate);
                Assert.AreEqual(doiHeader.OrganizationId, result.OrganizationId);
                Assert.AreEqual(doiHeader.Organization.Id, result.Organization.Id);
                Assert.AreEqual(doiHeader.Organization.Name, result.Organization.Name);
            }
        }
    }
}
