using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Data
{
    public class ProcurementTrackerContextInitialiser
    {
        private readonly ILogger<ProcurementTrackerContextInitialiser> _logger;
        private readonly ProcurementTrackerContext _context;

        public ProcurementTrackerContextInitialiser(ILogger<ProcurementTrackerContextInitialiser> logger, ProcurementTrackerContext context)
        {
            this._logger = logger;
            this._context = context;
        }
    }
}
