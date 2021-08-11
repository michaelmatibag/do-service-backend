using DOService.Controllers;
using DOService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOService.Tests
{
    [TestClass]
    public class OrganizationControllerTests
    {
        #region Private Props

        #endregion

        #region Testing Methods

        [TestMethod]
        public void GetAllOrganizations_ShouldReturnAllOrganizations()
        {
            var testOrgs = GetTestingOrganizations();
            var controller = new OrganizationController(null, testOrgs);

            var result = controller.GetAllOrganizations().ToList();
            Assert.AreEqual(testOrgs.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllOrganizationsAsync_ShouldReturnAllOrganizations()
        {
            var testOrgs = GetTestingOrganizations();
            var controller = new OrganizationController(null, testOrgs);

            var result = (await controller.GetAllOrganizationsAsync()).ToList();
            Assert.AreEqual(testOrgs.Count, result.Count);
        }

        #endregion

        #region Testing Data

        private List<Organization> GetTestingOrganizations()
        {
            return new List<Organization>()
            {
                new Organization { Name = "Federation of Planets"},
                new Organization { Name = "Klingon Empire"},
                new Organization { Name = "Romulan Star Empire"}
            };
        }

        #endregion
    }
}
