﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public long RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? LastLoggedOn { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<User> CreatedUsers { get; set; }
        public virtual ICollection<User> UpdatedUsers { get; set; }
    }
}
