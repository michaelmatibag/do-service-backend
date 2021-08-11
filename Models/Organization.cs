using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOService.Models
{
    [Table("organizations")]
    public class Organization
    {
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; set; }

        public List<DoiHeader> DoiHeaders { get; set; } = new List<DoiHeader>();
    }
}
