using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Pipelines.MasterData.Query
{
    public record OrderStatusMasterDataQuery():IRequest<List<DropDownDTO>>;

    public class OrderStatusMasterDataQueryHandler : IRequestHandler<OrderStatusMasterDataQuery, List<DropDownDTO>>
    {
        private readonly IMasterDataService _masterDataService;

        public OrderStatusMasterDataQueryHandler(IMasterDataService masterDataService)
        {
            this._masterDataService = masterDataService;
        }

        public async Task<List<DropDownDTO>> Handle(OrderStatusMasterDataQuery request, CancellationToken cancellationToken)
        {
            var orderStatusMasterData = await _masterDataService.GetOrderStatusMasterData();

            return orderStatusMasterData;
        }
    }
}
