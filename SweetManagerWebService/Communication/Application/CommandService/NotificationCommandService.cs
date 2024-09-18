using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.Communication.Domain.Model.Commands;
using SweetManagerWebService.Communication.Domain.Repositories;
using SweetManagerWebService.Communication.Domain.Services.Notification;

namespace SweetManagerWebService.Communication.Application.CommandService;

public class NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork) : INotificationCommandService
{
    public async Task<bool> Handle(CreateNotificationCommand command)
    {
        try
        {
            await notificationRepository.AddAsync(new Notification
            {
                TypesNotificationsId = command.TypesNotificationsId,
                OwnersId = command.OwnersId,
                AdminsId = command.AdminsId,
                WorkersId = command.WorkersId,
                Title = command.Title,
                Description = command.Description
            });

            await unitOfWork.CompleteAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}