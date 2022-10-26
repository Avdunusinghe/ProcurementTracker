using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.UserDTOs;

namespace ProcurementTracker.Application.Common.Pipelines.User
{
    public record SaveUserCommand() : IRequest<ResultDTO>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public long RoleId { get; set; }
        public string Password { get; set; }
    }

    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, ResultDTO>
    {
        private readonly IUserService _userService;

        public SaveUserCommandHandler(IUserService userService)
        {
            this._userService = userService;
        }
      
        public async Task<ResultDTO> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = new UserDTO()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                ContactNumber = request.ContactNumber,
                Address = request.Address,
                RoleId = request.RoleId,
                Password = request.Password

            };

            return await _userService.SaveUser(userDto, cancellationToken);
        }
    }
}
