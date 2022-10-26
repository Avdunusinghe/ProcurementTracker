using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Response.Common;
using ProcurementTracker.Application.Suppliers.Query;

namespace ProcurementTracker.Infrastructure.Services
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMediator _mediator;
        public MasterDataService(IMediator mediator)
        {
            this._mediator = mediator;
        }
        public async Task<List<DropDownDTO>> GetSuppliersMasterData()
        {
           var suppliers = new List<DropDownDTO>();

            var suppliersData = await _mediator.Send(new GetAllSupplierQuery());

            suppliersData = suppliersData.Where(x=>x.IsActive == true).ToList();

            suppliersData.ForEach(supplier =>
            {
                suppliers.Add(new DropDownDTO()
                {
                    Id = supplier.Id,
                    Name = supplier.SupplierName
                });

            });

            return suppliers;

        
        }
    }
}
