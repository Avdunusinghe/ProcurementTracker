using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response.AuthenticationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Pipelines.User
{
    public record AuthenticationCommand() : IRequest<UserAuthenticationResponseDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
     
    public record AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, UserAuthenticationResponseDTO>
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public AuthenticationCommandHandler(IUserAuthenticationService userAuthenticationService)
        {
            this._userAuthenticationService = userAuthenticationService;
        }

        public Task<UserAuthenticationResponseDTO> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            var authenticationDto = new AuthenticationDTO()
            {
                UserName = request.UserName,
                Password = request.Password,
            };

            //throw new NotImplementedException("Sentry Error");

            return _userAuthenticationService.Login(authenticationDto, cancellationToken);
        }
    }
}
