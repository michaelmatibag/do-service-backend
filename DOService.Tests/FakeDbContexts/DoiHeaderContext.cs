﻿using DOService.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DOService.Tests.FakeDbContexts.DoiHeaderContext
{
    public sealed class DoiHeaderContext : DbContext
    {
        private DOServiceContext _context;

        public DOServiceContext DbContext { get { return _context; } }

        public DoiHeaderContext(string testName)
        {
            var options = new DbContextOptionsBuilder<DOServiceContext>()
                .UseInMemoryDatabase(databaseName: testName)
                .Options;

            _context = new DOServiceContext(options);
        }

        public void SeedDatabase()
        {
            var org = new Organization { Name = "DOI Test Org" };
            DbContext.Organizations.Add(org);

            var dh1 = new DoiHeader
            {
                Id = Guid.NewGuid(),
                Description = "Test DOI 1",
                ApprovedFlag = true,
                ApprovedDate = DateTime.Today,
                ApprovedUserId = "Test User",
                CreatedDate = DateTime.Today,
                OrganizationId = org.Id,
                Organization = org
            };
            DbContext.DoiHeaders.Add(dh1);

            var dh2 = new DoiHeader
            {
                Id = Guid.NewGuid(),
                Description = "Test DOI 2",
                ApprovedFlag = true,
                ApprovedDate = DateTime.Today,
                ApprovedUserId = "Test User",
                CreatedDate = DateTime.Today,
                OrganizationId = org.Id,
                Organization = org
            };
            DbContext.DoiHeaders.Add(dh1);

            var dh3 = new DoiHeader
            {
                Id = Guid.NewGuid(),
                Description = "Test DOI 3",
                ApprovedFlag = true,
                ApprovedDate = DateTime.Today,
                ApprovedUserId = "Test User",
                CreatedDate = DateTime.Today,
                OrganizationId = org.Id,
                Organization = org
            };
            DbContext.DoiHeaders.Add(dh1);

            DbContext.SaveChanges();
        }
    }
}