﻿using System;
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
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<DoiHeader> DoiHeaders { get; set; }
    }
}
