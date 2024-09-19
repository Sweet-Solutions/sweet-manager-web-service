using Microsoft.EntityFrameworkCore;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Entities;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Model.Entities;
using SweetManagerWebService.SupplyManagement.Domain.Repositories;

namespace SweetManagerWebService.SupplyManagement.Infrastructure.Persistence.Repositories;

public class SuppliesRequestRepository(SweetManagerContext context) : BaseRepository<SuppliesRequest>(context), ISuppliesRequestRepository
{
    public async Task<SuppliesRequest?> FindBySupplyId(int supplyId)
    {
        return await Context.Set<SuppliesRequest>().FirstOrDefaultAsync(f => f.SuppliesId == supplyId);
    }

    public async Task<SuppliesRequest?> FindByPaymentOwnerId(int paymentOwnerId)
    {
        return await Context.Set<SuppliesRequest>().FirstOrDefaultAsync(f => f.PaymentsOwnersId == paymentOwnerId);
    }
    
    public async Task<IEnumerable<SuppliesRequest>> FindAllSuppliesRequestsAsync(int queryHotelId)
    {
        return await Task.Run(() => (
            from suppliesRequest in Context.Set<SuppliesRequest>().ToList()
            join supply in Context.Set<Supply>().ToList()
                on suppliesRequest.SuppliesId equals supply.Id
            join provider in Context.Set<Provider>().ToList()
                on supply.ProvidersId equals provider.Id
            join owner in Context.Set<Owner>().ToList()
                on provider.Id equals owner.Id
            join hotel in Context.Set<Hotel>().ToList()
                on owner.Id equals hotel.OwnersId
            select suppliesRequest
        ).ToList());
    }
}