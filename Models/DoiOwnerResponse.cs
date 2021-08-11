using System;

namespace DOService.Models
{
    public class DoiOwnerResponse
    {
        public Guid Id { get; set; }

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

        public OrganziationResponse Organziation { get; set; }

        public DoiHeaderResponse DoiHeader { get; set; }
    }
}
