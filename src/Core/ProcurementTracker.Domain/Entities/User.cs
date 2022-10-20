using System;
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

        #region Navigation Property Product
        public virtual ICollection<Product> CreatedProducts { get; set; }
        public virtual ICollection<Product> UpdatedProducts { get; set; }
        #endregion

        #region Navigation Property Orders
        public virtual ICollection<Order> CreatedOrders { get; set; }
        public virtual ICollection<Order> UpdatedOrders { get; set; }
        public virtual ICollection<Order> PlaceOders { get; set; }
        #endregion

        #region Navigation Property PurchaseRequest
        public virtual ICollection<PurchaseRequest> CreatedPurchaseRequests { get; set; }
        public virtual ICollection<PurchaseRequest> UpdatedPurchaseRequests { get; set; }
        public virtual ICollection<PurchaseRequest> StatusChangedPurchaseRequests { get; set; }
        #endregion

        #region Navigation Property  Supplier
        public virtual ICollection<Supplier> CreatedSuppliers { get; set; }
        public virtual ICollection<Supplier> UpdatedSuppliers { get; set; }
        #endregion
    }
}
