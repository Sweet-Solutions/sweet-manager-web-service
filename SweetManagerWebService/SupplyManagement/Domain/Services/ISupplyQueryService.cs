using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;

namespace SweetManagerWebService.SupplyManagement.Domain.Services;

public interface ISupplyQueryService
{
    Task<bool> GetSupplyById(int id);
    
    Task<IEnumerable<Supply>> GetSupplies();
}