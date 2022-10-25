using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Users.Query
{
    public record GetUserByEmailQuery(string email) :  IRequest<User>;

    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public GetUserByEmailQueryHandler(IUserQueryRepository userQueryRepository)
        {
            this._userQueryRepository = userQueryRepository;
        }
        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var selectedUser = _userQueryRepository.GetUserByEmail(request.email);

            return selectedUser;
        }
    }
}
