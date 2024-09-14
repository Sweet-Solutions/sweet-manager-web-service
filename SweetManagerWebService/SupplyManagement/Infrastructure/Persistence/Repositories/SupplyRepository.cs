using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Repositories;

namespace SweetManagerWebService.SupplyManagement.Infrastructure.Persistence.Repositories;

public class SupplyRepository(SweetManagerContext context) : BaseRepository<Supply>(context), ISupplyRepository
{
    public async Task<bool> GetSupplyById(int id)
    {
        return await Context.Set<Supply>().AnyAsync(x => x.Id == id);
    }
}