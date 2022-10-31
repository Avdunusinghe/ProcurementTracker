using ProcurementTracker.Application.Response.Common;

namespace ProcurementTracker.Application.Common.Interfaces
{
    public interface IMasterDataService
    {
        Task<List<DropDownDTO>> GetSuppliersMasterData();
        Task<List<DropDownDTO>> GetProductMasterData();
        Task<List<DropDownDTO>> GetOrderStatusMasterData();
    }
}
