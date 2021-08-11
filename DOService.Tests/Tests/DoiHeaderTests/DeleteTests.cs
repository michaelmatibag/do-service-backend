using DOService.Controllers;
using DOService.Tests.FakeDbContexts.DoiHeaderContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.DoiHeaderTests
{
    [TestClass]
    public class DeleteTests
    {
        [TestMethod]
        public void DeleteDoiHeader_ShouldDeleteADoiHeader()
        {
            using (var context = new DoiHeaderContext("DeleteTests.DeleteDoiHeader"))
            {
                //Arrange
                context.SeedDatabase();

                var doiHeader = context.DbContext.DoiHeaders.First();

                //Act
                var action = new DoiHeaderController(null, context.Repository).DeleteDoiHeader(doiHeader.Id) as OkResult;

                //Assert
                Assert.IsNotNull(action);
                Assert.AreEqual(action.StatusCode, 200);
                Assert.IsNull(context.DbContext.DoiHeaders.Find(doiHeader.Id));
            }
        }
    }
}
