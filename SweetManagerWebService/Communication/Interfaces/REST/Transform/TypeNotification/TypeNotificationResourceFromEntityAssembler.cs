using SweetManagerWebService.Communication.Interfaces.REST.Transform.Resources.TypeNotification;

namespace SweetManagerWebService.Communication.Interfaces.REST.Transform.TypeNotification
{
    public class TypeNotificationResourceFromEntityAssembler
    {
        public static TypeNotificationResource ToResourceFromEntity(Domain.Model.Entities.TypeNotification entity) =>
            new(entity.Id, entity.Name);
    }
}