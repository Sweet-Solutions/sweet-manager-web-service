using Microsoft.EntityFrameworkCore;
using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.Communication.Domain.Repositories;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Entities;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.Communication.Infrastructure.Persistence.EFC.Repositories
{
    public class NotificationRepository(SweetManagerContext context) : BaseRepository<Notification>(context), INotificationRepository
    {
        public async Task<IEnumerable<Notification>> FindByTypeNotificationIdAsync(int typeNotificationId)
            => await Task.Run(() => (
                from ntf in Context.Set<Notification>().ToList()
                join own in Context.Set<Owner>().ToList()
                    on ntf.OwnersId equals own.Id
                join htl in Context.Set<Hotel>().ToList()
                    on own.Id equals htl.OwnersId
                where ntf.TypesNotificationsId.Equals(typeNotificationId) 
                select ntf
            ).ToList());

        public async Task<IEnumerable<Notification>> FindAllByHotelIdAsync(int hotelId)
        {
            Task<IEnumerable<Notification>> queryAsync = new(() => (
                from ntf in Context.Set<Notification>().ToList()
                join ow in Context.Set<Owner>().ToList() on ntf.OwnersId equals ow.Id
                join ho in Context.Set<Hotel>().ToList() on ow.Id equals ho.OwnersId
                where ho.Id.Equals(hotelId)
                select ntf
            ).ToList());
            
            queryAsync.Start();

            var result = await queryAsync;

            return result;
        }
    }
}