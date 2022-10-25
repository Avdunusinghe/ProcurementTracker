using AutoMapper;
using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Users.Commands
{
    public record CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserCommandRepository userCommandRepository, IMapper mapper)
        {
           this._userCommandRepository = userCommandRepository;
           this._mapper = mapper;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = await _userCommandRepository.AddAsync(request.User, cancellationToken);

            return newUser;
        }
    }
}
