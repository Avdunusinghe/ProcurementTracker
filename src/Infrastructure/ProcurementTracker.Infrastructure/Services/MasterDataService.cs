using MediatR;
using ProcurementTracker.Application.Common.Helper;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Products.Query;
using ProcurementTracker.Application.Response.Common;
using ProcurementTracker.Application.Suppliers.Query;
using ProcurementTracker.Domain.Enums;

namespace ProcurementTracker.Infrastructure.Services
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMediator _mediator;
        public MasterDataService(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task<List<DropDownDTO>> GetOrderStatusMasterData()
        {
            var orderStatus = new List<DropDownDTO>();

            foreach (OrderStatus value in Enum.GetValues(typeof(OrderStatus)))
            {
                orderStatus.Add(new DropDownDTO()
                {
                    Id = (int)value,
                    Name = EnumHelper.GetEnumDescription(value)
                });
            }


            return orderStatus;
        }

        public async Task<List<DropDownDTO>> GetProductMasterData()
        {
            var products = new List<DropDownDTO>();

            var productData = await _mediator.Send(new GetAllProductQuery());

            productData = productData.Where(x => x.IsActive == true).ToList();

            productData.ForEach(product =>
            {
                products.Add(new DropDownDTO()
                {
                    Id = product.Id,
                    Name = product.Name
                });

            });

            return products;
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
