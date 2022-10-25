using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.UserDTOs;
using ProcurementTracker.Application.Users.Commands;
using ProcurementTracker.Application.Users.Query;
using ProcurementTracker.Domain.Entities;

namespace ProcurementTracker.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        public UserService(IMediator mediator)
        {
            this._mediator = mediator;
        }
        public async  Task<ResultDTO> SaveUser(UserDTO userDto, CancellationToken cancellationToken)
        {
            var response = new ResultDTO();
            var user = await _mediator.Send(new GetUserByEmailQuery(userDto.Email), cancellationToken);
            
            if (user != null)
            {
                response.IsSuccess = false;
                response.Message = "User All Ready in the System Please try again.";
            }

            if(userDto.Id == 0)
            {
                user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    RoleId = userDto.RoleId,
                    ContactNumber = userDto.ContactNumber,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password)

                };

                await _mediator.Send(new CreateUserCommand()
                {
                    User = user
                });

                response.IsSuccess = true;
                response.Message = "User has been Saved Successfully";
            }

            return response;
        }
    }
}
