using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
using ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Interfaces
{
    public interface IOrderService 
    {
        Task<ResultDTO> SaveOrder(OrderDTO orderDTO, CancellationToken cancellationToken);
        Task<List<OrderContainerDTO>> GetAllOrders(OrderFilterDTO filter, CancellationToken cancellationToken);
        Task<ResultDTO> SavePurchaseRequest(PurchaseRequestDTO purchaseRequestDTO, CancellationToken cancellationToken);
        Task<List<PurchaseRequestContainerDTO>> GetAllPurchaseRequest(PurchaseRequestFilterDTO filter, CancellationToken cancellationToken);

    }
}
