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
        [ForeignKey("id")]
        public Guid OrganizationId { get; set; }

        [Column("doi_header_id")]
        [ForeignKey("id")]
        public Guid DoiHeaderId { get; set; }

        [Column("owner_id")]
        public Guid OwnerId { get; set; }

        [Column("owner_name")]
        public string OwnerName { get; set; }

        [Column("pay_code")]
        public string PayCode { get; set; }

        [Column("suspense_reason")]
        public string SuspenseReason { get; set; }

        [Column("interest_type")]
        public string InterestType { get; set; }

        [Column("nri_decimal")]
        public decimal NriDecimal { get; set; }

        [Column("burden_group_id")]
        public Guid BurdenGroupId { get; set; }

        [Column("effective_from_date")]
        public DateTime EffectiveFromDate { get; set; }

        [Column("effective_to_date")]
        public DateTime EffectiveToDate { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual DoiHeader DoiHeader { get; set; }
    }
}
