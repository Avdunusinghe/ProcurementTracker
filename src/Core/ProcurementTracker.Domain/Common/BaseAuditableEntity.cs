namespace ProcurementTracker.Domain.Common
{
    public class BaseAuditableEntity : BaseEntity
    {
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }

        public long? CreatedById { get; set; }

        public DateTime? LastModified { get; set; }

        public long? LastUpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User LastUpdatedBy { get; set; }
    }
}
