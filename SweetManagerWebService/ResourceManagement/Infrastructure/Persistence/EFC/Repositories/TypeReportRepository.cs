using SweetManagerWebService.ResourceManagement.Domain.Model.Entities;
using SweetManagerWebService.ResourceManagement.Domain.Repositories;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.ResourceManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class TypeReportRepository : BaseRepository<TypeReport>, ITypeReportRepository
    {
        private readonly SweetManagerContext _context;

        public TypeReportRepository(SweetManagerContext context):base(context)
        {
            _context = context;
        }
        
    }
}