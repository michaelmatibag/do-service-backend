using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOService.Models
{
    [Table("doi_owners")]
    public class DoiOwner
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("organization_id")]
        public Guid OrganizationId { get; set; }

        [Column("doi_header_id")]
        public Guid DoiHeaderId { get; set; }

        [Column("owner_id")]
        public Guid OwnerId { get; set; }

        [Column("owner_name")]
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
