using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Entities;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Model.Entities;
using SweetManagerWebService.SupplyManagement.Domain.Repositories;

namespace SweetManagerWebService.SupplyManagement.Infrastructure.Persistence.Repositories;

public class SupplyRepository : BaseRepository<Supply>, ISupplyRepository
{
    public SupplyRepository(SweetManagerContext context) : base(context)
    {
    }


    public async Task<IEnumerable<Supply>> FindByProvidersId(int providersId)
    {
        return await Context.Set<Supply>().Where(s => s.ProvidersId == providersId).ToListAsync();
    }
    
    public async Task<IEnumerable<Supply>> FindSuppliesByHotelIdAsync(int hotelId)
    {
        return await Task.Run(() => (
            from supply in Context.Set<Supply>().ToList()
            join provider in Context.Set<Provider>().ToList()
                on supply.ProvidersId equals provider.Id
            join owner in Context.Set<Owner>().ToList()
                on provider.Id equals owner.Id
            join hotel in Context.Set<Hotel>().ToList()
                on owner.Id equals hotel.OwnersId
            where hotel.Id == hotelId
            select supply
        ).ToList());
    }
    
   
}
