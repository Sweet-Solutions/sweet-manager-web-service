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
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationCommandService _notificationCommandService;
        private readonly INotificationQueryService _notificationQueryService;

        public NotificationsController(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService)
        {
            _notificationCommandService = notificationCommandService;
            _notificationQueryService = notificationQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _notificationCommandService.Handle(CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> AllNotifications()
        {
            var notifications = await _notificationQueryService.Handle(new GetAllNotificationsQuery());

            var notificationsResource = notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(notificationsResource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> NotificationById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            try
            {
                var notification = await _notificationQueryService.Handle(new GetNotificationByIdQuery(id));

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