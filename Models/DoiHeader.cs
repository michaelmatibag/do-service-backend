using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOService.Models
{
    [Table("doi_headers")]
    public class DoiHeader
    {
        public DoiHeader()
        {
            if (Id == Guid.Empty)
            {
                Id = new Guid();
            }

            Organization = new Organization();
        }

        [Column("id")]
        public Guid Id { get; set; }

        [Column("organization_id")]
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

        public Organization Organization {get; set;}
    }
}
