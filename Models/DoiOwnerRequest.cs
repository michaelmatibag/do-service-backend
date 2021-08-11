﻿using System;

namespace DOService.Models
{
    public class DoiOwnerRequest
    {
        public Guid OrganizationId { get; set; }

        public Guid DoiHeaderId { get; set; }

        public Guid OwnerId { get; set; }

        public string OwnerName { get; set; }

        public string PayCode { get; set; }

        public string SuspenseReason { get; set; }

        public string InterestType { get; set; }

        public decimal NriDecimal { get; set; }

        public Guid BurdenGroupId { get; set; }

        public DateTime EffectiveFromDate { get; set; }

        public DateTime EffectiveToDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
