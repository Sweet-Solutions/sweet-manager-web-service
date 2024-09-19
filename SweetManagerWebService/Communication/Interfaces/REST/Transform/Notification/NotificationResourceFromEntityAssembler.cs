using SweetManagerWebService.Communication.Interfaces.REST.Resources.Notification;

namespace SweetManagerWebService.Communication.Interfaces.REST.Transform.Notification
{
    public class NotificationResourceFromEntityAssembler
    {
        public static CreateNotificationResource ToResourceFromEntity(Domain.Model.Aggregates.Notification entity) =>
            new(entity.TypesNotificationsId, entity.OwnersId ?? 0, entity.AdminsId ?? 0, entity.WorkersId ?? 0, entity.Title, entity.Description);
    }
}