using ProcurementTracker.Application.Common.Interfaces;
using System.Security.Claims;

namespace ProcurementTracker.WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public long? UserId
        {
            get
            {
                if (_httpContextAccessor.HttpContext == null)
                    return (long?)null;

                try
                {
                    return long.Parse(_httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier));
                }
                catch (Exception ex)
                {
                    return (long?)null;
                }


            }
        }
    }
}
