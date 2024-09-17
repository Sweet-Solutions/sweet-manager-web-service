﻿using SweetManagerWebService.SupplyManagement.Domain.Model.Queries;
using SweetManagerWebService.SupplyManagement.Domain.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Services;

namespace SweetManagerWebService.SupplyManagement.Application.Internal.SuppliesRequest;

public class SuppliesRequestQueryService(ISuppliesRequestRepository suppliesRequestRepository)
    : ISuppliesRequestQueryService
{
    private ISuppliesRequestRepository _suppliesRequestRepository = suppliesRequestRepository;


    public async Task<Domain.Model.Entities.SuppliesRequest?> Handle(GetSuppliesRequestByIdQuery query)
    {
        return await _suppliesRequestRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Domain.Model.Entities.SuppliesRequest>> Handle(GetAllSuppliesRequestQuery query)
    {
        return await _suppliesRequestRepository.ListAsync();
    }
}