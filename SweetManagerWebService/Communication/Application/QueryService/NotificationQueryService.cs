using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.Communication.Domain.Model.Queries.Notificacion;
using SweetManagerWebService.Communication.Domain.Repositories;
using SweetManagerWebService.Communication.Domain.Services.Notification;

namespace SweetManagerWebService.Communication.Application.QueryService;

public class NotificationQueryService(INotificationRepository notificationRepository) : INotificationQueryService
{
    public async Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query)
    {
        return await notificationRepository.ListAsync();
    }

    public async Task<Notification?> Handle(GetNotificationByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.Id);
    }
}