using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOService.Models
{
    [Table("organizations")]
    public class Organization
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<DoiHeader> DoiHeaders { get; set; } = new List<DoiHeader>();
        public virtual ICollection<DoiOwner> DoiOwners { get; set; } = new List<DoiOwner>();
    }

    public class OrganizationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<DoiHeaderResponse> DoiHeaders { get; set; }

        public virtual IEnumerable<DoiOwnerResponse> ActiveOwners { get; set; }
    }

    public class OrganizationRequest
    {
        public string Name { get; set; }
    }
}
