using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Products.Query
{
    public record GetAllProductQuery() : IRequest<List<Product>>;


    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IProductQueryRepository _orderProductQueryRepository;
        public GetAllProductQueryHandler(IProductQueryRepository orderProductQueryRepository)
        {
            this._orderProductQueryRepository = orderProductQueryRepository;
        }
        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _orderProductQueryRepository.GetAll(cancellationToken);

            return products;
        }
    }
}
