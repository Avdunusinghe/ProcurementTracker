using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.UserDTOs;

namespace ProcurementTracker.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<ResultDTO> SaveUser(UserDTO userDto, CancellationToken cancellationToken);
    }
}
