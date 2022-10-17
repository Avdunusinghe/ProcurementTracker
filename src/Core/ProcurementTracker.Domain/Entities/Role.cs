using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
   
}
