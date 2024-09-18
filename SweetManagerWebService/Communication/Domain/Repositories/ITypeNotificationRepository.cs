using SweetManagerWebService.Communication.Domain.Model.Entities;

namespace SweetManagerWebService.Communication.Domain.Repositories
{
    public interface ITypeNotificationRepository
    {
        Task<IEnumerable<TypeNotification>> GetAllAsync();
        Task<TypeNotification?> GetByIdAsync(int id);
    }
}