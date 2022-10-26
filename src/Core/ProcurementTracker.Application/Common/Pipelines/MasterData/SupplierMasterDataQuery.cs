﻿using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Pipelines.MasterData
{
    public record SupplierMasterDataQuery() : IRequest<List<DropDownDTO>>;

    public class SupplierMasterDataQueryHandler : IRequestHandler<SupplierMasterDataQuery, List<DropDownDTO>>
    {
        private readonly IMasterDataService _masterDataService;

        public SupplierMasterDataQueryHandler(IMasterDataService masterDataService)
        {
            this._masterDataService = masterDataService;
        }

        public async Task<List<DropDownDTO>> Handle(SupplierMasterDataQuery request, CancellationToken cancellationToken)
        {
            var response = await _masterDataService.GetSuppliersMasterData();

            return response;    
        }
    }
}
