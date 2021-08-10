using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOService.Models
{
    [Table("organization")]
    public class Organization
    {
        public Organization() : base()
        {
            // populate GUID id by default if one is not provided
            if (Id == Guid.Empty) { Id = new Guid(); }

            // default to empty for now
            DoiHeaders = new List<DoiHeader>();

            _OriginalOrganization = this;
        }

        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        // Child Properties
        public List<DoiHeader> DoiHeaders { get; set; }

        // State Properties
        private Organization _OriginalOrganization;

        public Organization OriginalOrganization { get { return _OriginalOrganization; } }

        public bool HasChanges { get { return this != _OriginalOrganization; } }
    }
}
