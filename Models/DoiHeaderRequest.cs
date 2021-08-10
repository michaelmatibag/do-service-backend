using System;

namespace DOService.Models
{
    public class DoiHeaderRequest
    {
        public Guid OrganizationId { get; set; }
        public string Description { get; set; }
        public bool ApprovedFlag { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedUserId { get; set; }
    }
}
