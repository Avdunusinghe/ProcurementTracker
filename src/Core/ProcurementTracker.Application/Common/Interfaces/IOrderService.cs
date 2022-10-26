using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
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
    }
}
