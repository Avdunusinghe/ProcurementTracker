using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response.AuthenticationDTOs
{
    public class UserAuthenticationResponseDTO
    {
        internal UserAuthenticationResponseDTO(bool isLoginSuccess, string token, string email, long userId, string message)
        {
            this.IsLoginSuccess = isLoginSuccess;
            this.Token = token;
            this.Email = email;
            this.UserId = userId;
            this.Message = message;
        }

        public bool IsLoginSuccess { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; }

        public static UserAuthenticationResponseDTO NotSuccess(string errorMessage)
        {
            return new UserAuthenticationResponseDTO(false, string.Empty, string.Empty, 0, errorMessage);
        }

        public static UserAuthenticationResponseDTO Success(string token, string email, long userId)
        {
            return new UserAuthenticationResponseDTO(true, token, email, userId, "User email verified successfully.");
        }
    }
}
