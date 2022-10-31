using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Response.Common;

namespace ProcurementTracker.Application.Common.Pipelines.MasterData.Query
{
    public record ProductMasterDataQuery() : IRequest<List<DropDownDTO>>;
    public class ProductMasterDataQueryHandler : IRequestHandler<ProductMasterDataQuery, List<DropDownDTO>>
    {
        private readonly IMasterDataService _masterDataService;

        public ProductMasterDataQueryHandler(IMasterDataService masterDataService)
        {
            this._masterDataService = masterDataService;
        }

        public async Task<List<DropDownDTO>> Handle(ProductMasterDataQuery request, CancellationToken cancellationToken)
        {
            var productMasterData = await _masterDataService.GetProductMasterData();

            return productMasterData;
        }
    }
}
