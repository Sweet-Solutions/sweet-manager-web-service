using Microsoft.EntityFrameworkCore;
using SweetManagerWebService.Communication.Domain.Model.Entities;
using SweetManagerWebService.Communication.Domain.Repositories;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SweetManagerWebService.Communication.Infrastructure.Persistence.EFC.Repositories
{
    public class TypeNotificationRepository : ITypeNotificationRepository
    {
        private readonly SweetManagerContext _context;

        public TypeNotificationRepository(SweetManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeNotification>> GetAllAsync()
        {
            return await _context.Set<TypeNotification>()
                .ToListAsync();
        }

        public async Task<TypeNotification?> GetByIdAsync(int id)
        {
            return await _context.Set<TypeNotification>()
                .FirstOrDefaultAsync(tn => tn.Id == id);
        }
    }
}