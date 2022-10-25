using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response.AuthenticationDTOs
{
    public class UserAuthenticationDTO
    {
        public long ApplicationFormId { get; set; }
        public long UserId { get; set; }
        public string VerificationCode { get; set; }
    }
}
