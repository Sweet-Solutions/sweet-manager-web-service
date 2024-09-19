using Microsoft.EntityFrameworkCore;
using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.Communication.Domain.Repositories;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Entities;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.Communication.Infrastructure.Persistence.EFC.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(SweetManagerContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> FindByTypeNotificationIdAsync(int typeNotificationId, int hotelId)
            => await Task.Run(() => (
                from ntf in Context.Set<Notification>().ToList()
                join own in Context.Set<Owner>().ToList()
                    on ntf.OwnersId equals own.Id
                join htl in Context.Set<Hotel>().ToList()
                    on own.Id equals htl.OwnersId
                where ntf.TypesNotificationsId == typeNotificationId && htl.Id == hotelId
                select ntf
            ).ToList());
    }
}