using SweetManagerWebService.ResourceManagement.Domain.Model.Entities;

namespace SweetManagerWebService.ResourceManagement.Domain.Repositories
{
    public interface ITypeReportRepository
    {
        Task<IEnumerable<TypeReport>> GetAllAsync();
        Task<TypeReport?> GetByIdAsync(int id);
    }
}