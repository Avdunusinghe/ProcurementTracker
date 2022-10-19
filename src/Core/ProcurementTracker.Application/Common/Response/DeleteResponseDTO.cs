using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Response.Common
{
    public class DeleteResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static implicit operator string(DeleteResponseDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
