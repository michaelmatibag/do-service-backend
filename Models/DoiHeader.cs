using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOService.Models
{
    [Table("doi_headers")]
    public class DoiHeader
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("organization_id")]
        [ForeignKey("id")]
        public Guid OrganizationId { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("approved_flag")]
        public bool ApprovedFlag { get; set; }

        [Column("approved_date")]
        public DateTime ApprovedDate { get; set; }

        [Column("approved_user_id")]
        public string ApprovedUserId { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<DoiOwner> DoiOwners { get; set; }
    }
}
