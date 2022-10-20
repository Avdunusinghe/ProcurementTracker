using System.ComponentModel;

namespace ProcurementTracker.Domain.Enums
{
    public enum PurchaseRequestStatus
    {
        [Description("Waiting For Approval")]
        WaitingForApproval = 1,
        [Description("Approved")]
        Approved = 2,
        [Description("Declined")]
        Declined = 3,
        [Description("Partially Approved")]
        PartiallyApproved = 4,
        [Description("Referred")]
        Referred = 5,
    }
}
