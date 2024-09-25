using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using SweetManagerWebService.Communication.Domain.Model.Queries.Notificacion;
using SweetManagerWebService.Communication.Domain.Services.Notification;
using SweetManagerWebService.Communication.Interfaces.REST.Resources.Notification;
using SweetManagerWebService.Communication.Interfaces.REST.Transform.Notification;

namespace SweetManagerWebService.Communication.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class NotificationsController(
        INotificationCommandService notificationCommandService, 
        INotificationQueryService notificationQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await notificationCommandService.Handle(CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }
        
        [HttpGet("get-all-notifications")]
        public async Task<IActionResult> AllNotifications([FromQuery] int hotelId)
        {
            var notifications = await notificationQueryService.Handle(new GetAllNotificationsQuery(hotelId));

            var notificationsResource = notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(notificationsResource);
        }

        [HttpGet("get-notification-by-id")]
        public async Task<IActionResult> NotificationById([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            try
            {
                var notification = await notificationQueryService.Handle(new GetNotificationByIdQuery(id));

                if (notification is null)
                {
                    throw new Exception("Notification not found");
                }

                var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);

                return Ok(notificationResource);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}