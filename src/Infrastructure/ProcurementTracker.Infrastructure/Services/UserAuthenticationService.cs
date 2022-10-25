using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response.AuthenticationDTOs;
using ProcurementTracker.Application.Users.Query;
using ProcurementTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public UserAuthenticationService(IMediator mediator, IConfiguration configuration)
        {
            this._mediator = mediator;
            this._configuration = configuration;
        }
        public async Task<UserAuthenticationResponseDTO> Login(AuthenticationDTO request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByEmailQuery(request.UserName), cancellationToken);

                if (user == null)
                {
                    return UserAuthenticationResponseDTO.NotSuccess("User does not exist in the system");
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    return UserAuthenticationResponseDTO.NotSuccess("Password is incorrect");
                }

                var userAthunticationResponse = await ConfigureJwtToken(user,cancellationToken);

                return userAthunticationResponse;
            }
            catch (Exception ex)
            {
                return UserAuthenticationResponseDTO.NotSuccess("Error has been occurred please try again");
            }
        }

        private async Task<UserAuthenticationResponseDTO> ConfigureJwtToken(User user, CancellationToken cancellationToken)
        {
            var key = _configuration["Tokens:Key"];
            var issuer = _configuration["Tokens:Issuer"];

            string role = user.Role.Name;

            var now = DateTime.UtcNow;
            DateTime nowDate = DateTime.UtcNow;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim("firstName",string.IsNullOrEmpty(user.FirstName)? "": user.FirstName),
                        new Claim("lastName", string.IsNullOrEmpty(user.LastName) ? "" : user.LastName),
                        new Claim("role",role),
                        new Claim(JwtRegisteredClaimNames.Aud,"webapp"),
                        new Claim(JwtRegisteredClaimNames.Aud,"mobileapp"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken
            (
                issuer: issuer,
                claims: claims,
                expires: nowDate.AddHours(3),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return UserAuthenticationResponseDTO.Success(tokenString, user.Email, user.Id);
        }
    }
}
