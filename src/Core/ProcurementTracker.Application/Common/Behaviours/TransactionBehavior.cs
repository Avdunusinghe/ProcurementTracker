using MediatR;
using Microsoft.Extensions.Logging;
using ProcurementTracker.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Behaviours
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly IProcurementTrackerContext _procurementTrackerContext;

        public TransactionBehavior(ILogger<TransactionBehavior<TRequest, TResponse>> logger, IProcurementTrackerContext procurementTrackerContext)
        {
            _logger = logger;
            _procurementTrackerContext = procurementTrackerContext;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response = default;

            try
            {
                await _procurementTrackerContext.RetryOnExceptionAsync(async () =>
                {
                    _logger.LogInformation($"Begin Transaction : {typeof(TRequest).Name}");
                    await _procurementTrackerContext.BeginTransactionAsync(cancellationToken);

                    response = await next();

                    await _procurementTrackerContext.CommitTransactionAsync(cancellationToken);
                    _logger.LogInformation($"End transaction : {typeof(TRequest).Name}");
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Rollback transaction executed {typeof(TRequest).Name}");
                await _procurementTrackerContext.RollbackTransactionAsync(cancellationToken);
                _logger.LogError(ex.Message, ex.StackTrace);

                throw;
            }

            return response;
        }
    }
}
