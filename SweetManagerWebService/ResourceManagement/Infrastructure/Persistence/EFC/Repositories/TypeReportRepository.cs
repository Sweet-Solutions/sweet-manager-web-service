using Microsoft.EntityFrameworkCore;
using SweetManagerWebService.ResourceManagement.Domain.Model.Entities;
using SweetManagerWebService.ResourceManagement.Domain.Repositories;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SweetManagerWebService.ResourceManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class TypeReportRepository : ITypeReportRepository
    {
        private readonly SweetManagerContext _context;

        public TypeReportRepository(SweetManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeReport>> GetAllAsync()
        {
            return await _context.Set<TypeReport>()
                .ToListAsync();
        }

        public async Task<TypeReport?> GetByIdAsync(int id)
        {
            return await _context.Set<TypeReport>()
                .FirstOrDefaultAsync(tr => tr.Id == id);
        }
    }
}