using SweetManagerWebService.Communication.Domain.Model.Entities;
using SweetManagerWebService.Communication.Domain.Repositories;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.Communication.Infrastructure.Persistence.EFC.Repositories
{
    public class TypeNotificationRepository : BaseRepository<TypeNotification>, ITypeNotificationRepository
    {
        private readonly SweetManagerContext _context;

        public TypeNotificationRepository(SweetManagerContext context): base(context)
        {
            _context = context;
        }
    }
}