using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Entities;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Repositories;

namespace SweetManagerWebService.SupplyManagement.Infrastructure.Persistence.Repositories;

public class SupplyRepository : BaseRepository<Supply>, ISupplyRepository
{
    public SupplyRepository(SweetManagerContext context) : base(context)
    {
    }

}
