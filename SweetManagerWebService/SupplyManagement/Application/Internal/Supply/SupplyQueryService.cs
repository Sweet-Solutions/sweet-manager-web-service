using SweetManagerWebService.SupplyManagement.Domain.Model.Queries;
using SweetManagerWebService.SupplyManagement.Domain.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Services;

namespace SweetManagerWebService.SupplyManagement.Application.Internal.Supply;

public class SupplyQueryService(ISupplyRepository supplyRepository) : ISupplyQueryService
{
    ISupplyRepository _supplyRepository = supplyRepository;

    public async Task<Domain.Model.Aggregates.Supply?> Handle(GetSupplyByIdQuery query)
    {
        return await _supplyRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Supply>> Handle(GetAllSuppliesQuery query)
    {
        return await _supplyRepository.ListAsync();
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Supply>> Handle(GetSupplyByProviderIdQuery query)
    {
        return await _supplyRepository.FindByProvidersId(query.ProviderId);
    }
}