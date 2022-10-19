using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response
{
    public class ResultDTO
    {
        internal ResultDTO(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static ResultDTO Success()
        {
            return new ResultDTO(true, Array.Empty<string>());
        }

        public static ResultDTO Failure(IEnumerable<string> errors)
        {
            return new ResultDTO(false, errors);
        }
    }
}
