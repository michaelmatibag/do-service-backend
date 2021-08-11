using DOService.Controllers;
using DOService.Features.DoiHeaderRepository;
using DOService.Models;
using DOService.Tests.FakeDbContexts.DoiHeaderContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.DoiHeaderTests
{
    [TestClass]
    public class PutTests
    {
        [TestMethod]
        public void UpdateDoiHeader_ShouldUpdateADoiHeader()
        {
            using (var context = new DoiHeaderContext("PutTests.UpdateDoiHeader"))
            {
                //Arrange
                context.SeedDatabase();

                var doiHeader = context.DbContext.DoiHeaders.First();
                var doiHeaderRequest = new DoiHeaderRequest
                {
                    ApprovedDate = doiHeader.ApprovedDate,
                    ApprovedFlag = doiHeader.ApprovedFlag,
                    ApprovedUserId = doiHeader.ApprovedUserId,
                    Description = "UpdatedDescription",
                    OrganizationId = doiHeader.OrganizationId,
                };

                //Act
                var action = new DoiHeaderController(null, new DoiHeaderRepository(context.DbContext)).UpdateDoiHeader(doiHeader.Id, doiHeaderRequest).Result as OkObjectResult;

                //Assert
                var result = action.Value as DoiHeaderResponse;
                
                Assert.AreEqual(doiHeader.Description, result.Description);
            }
        }
    }
}
