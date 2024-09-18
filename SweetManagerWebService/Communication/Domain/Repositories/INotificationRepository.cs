using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.Communication.Domain.Model.Aggregates;

namespace SweetManagerWebService.Communication.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<IEnumerable<Notification>> FindByTypeNotificationIdAsync(int typeNotificationId, int HotelId);
}