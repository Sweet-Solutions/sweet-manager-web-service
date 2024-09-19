using SweetManagerWebService.Monitoring.Domain.Model.Entities;
using SweetManagerWebService.Monitoring.Domain.Repositories;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    public class TypeRoomRepository
        (SweetManagerContext context) :
        BaseRepository<TypeRoom>(context),
        ITypeRoomRepository
    { }
}