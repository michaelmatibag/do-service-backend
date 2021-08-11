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
    }

    public class OrganziationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class OrganziationRequest
    {
        public string Name { get; set; }
    }
}
