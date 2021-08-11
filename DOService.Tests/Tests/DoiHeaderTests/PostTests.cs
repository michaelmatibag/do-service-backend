using System.Linq;
using DOService.Controllers;
using DOService.Features.DoiHeaderRepository;
using DOService.Models;
using DOService.Tests.FakeDbContexts.DoiHeaderContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DOService.Tests.DoiHeaderTests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void AddDoiHeader_ShouldAddADoiHeader()
        {
            using (var context = new DoiHeaderContext("DoiHeader.PostTests"))
            {
                //Arrange
                context.SeedDatabase();

                var organization = context.DbContext.Organizations.First();
                var doiHeaderRequest = new DoiHeaderRequest
                {
                    Description = "NewDoiHeader",
                    OrganizationId = organization.Id
                };

                //Act
                var action = new DoiHeaderController(null, new DoiHeaderRepository(context.DbContext)).AddDoiHeader(doiHeaderRequest).Result as OkObjectResult;

                //Assert
                var result = action.Value as DoiHeaderResponse;

                Assert.AreEqual(doiHeaderRequest.Description, result.Description);
                Assert.AreEqual(doiHeaderRequest.OrganizationId, result.OrganizationId);
                Assert.AreEqual(organization.Id, result.Organization.Id);
                Assert.AreEqual(organization.Name, result.Organization.Name);
            }
        }
    }
}
