using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;

namespace ProcurementTracker.Application.Suppliers.Query
{
    public record GetAllSupplierQuery() : IRequest<List<Supplier>>;

    public class GetAllSupplierQueryHandler : IRequestHandler<GetAllSupplierQuery, List<Supplier>>
    {
        private readonly ISupplierQueryRepository _supplierQueryRepository;
        public GetAllSupplierQueryHandler(ISupplierQueryRepository _supplierQueryRepository)
        {
            this._supplierQueryRepository = _supplierQueryRepository;
        }
        public async Task<List<Supplier>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierQueryRepository.GetAll(cancellationToken);

            return suppliers;   
        }
    }

}
