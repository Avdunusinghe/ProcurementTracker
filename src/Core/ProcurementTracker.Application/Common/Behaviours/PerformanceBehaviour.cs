using MediatR;
using Microsoft.Extensions.Logging;
using ProcurementTracker.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;

        public PerformanceBehaviour(
            ILogger<TRequest> logger,
            ICurrentUserService currentUserService
         )
        {
            _timer = new Stopwatch();

            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds <= 500) return response;
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? 0;


            _logger.LogWarning("Demo Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                requestName, elapsedMilliseconds, userId, request);

            return response;
        }
    }
}
