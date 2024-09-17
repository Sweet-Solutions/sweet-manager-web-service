using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Model.Queries;
using SweetManagerWebService.SupplyManagement.Domain.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Services;


namespace SweetManagerWebService.SupplyManagement.Application.Internal;

public class SupplyQueryService(ISupplyRepository supplyRepository) : ISupplyQueryService
{
    ISupplyRepository _supplyRepository = supplyRepository;

    public async Task<Supply?> Handle(GetSupplyByIdQuery query)
    {
        return await _supplyRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Supply>> Handle(GetAllSuppliesQuery query)
    {
        return await _supplyRepository.ListAsync();
    }
}