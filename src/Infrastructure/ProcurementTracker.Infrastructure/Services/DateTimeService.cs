using ProcurementTracker.Application.Common.Interfaces;

namespace ProcurementTracker.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
