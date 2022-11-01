using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Orders.Command
{
    public record EditOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }

    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, Order>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IOrderQueryRepository _orderQueryRepository;

        public EditOrderCommandHandler
        (
            IOrderCommandRepository orderCommandRepository, 
            IOrderQueryRepository orderQueryRepository
        )
        {
            this._orderCommandRepository = orderCommandRepository;
            this._orderQueryRepository = orderQueryRepository;
        }
        public async Task<Order> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _orderCommandRepository.UpdateAsync(request.Order, cancellationToken);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

            var modifiedOrder = await _orderQueryRepository.GetById(request.Order.Id, cancellationToken);

            return modifiedOrder;
        }
    }
}
