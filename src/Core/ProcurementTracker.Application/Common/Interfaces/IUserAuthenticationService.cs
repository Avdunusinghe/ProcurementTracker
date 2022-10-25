using ProcurementTracker.Application.Common.Response.AuthenticationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<UserAuthenticationResponseDTO> Login(AuthenticationDTO request, CancellationToken cancellationToken);
    }
}
