using Microsoft.AspNetCore.Mvc;
using SweetManagerWebService.Monitoring.Domain.Model.Queries.TypeRoom;
using SweetManagerWebService.Monitoring.Domain.Services.TypeRoom;
using SweetManagerWebService.Monitoring.Interfaces.REST.Resources.TypeRoom;
using SweetManagerWebService.Monitoring.Interfaces.REST.Transform.TypeRoom;

namespace SweetManagerWebService.Monitoring.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesRoomsController
        (ITypeRoomCommandService typeRoomCommandService,
        ITypeRoomQueryService typeRoomQueryService) :
        ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTypeRoom
            ([FromBody] CreateTypeRoomResource resource)
        {
            var result = await typeRoomCommandService.Handle
                (CreateTypeCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> AllTypesRooms()
        {
            var typesRooms = await typeRoomQueryService
                .Handle(new GetAllTypesRoomsQuery());

            var typesRoomsResource = typesRooms.Select
                (TypeRoomResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(typesRoomsResource);
        }

        [HttpGet]
        public async Task<IActionResult> TypeRoomById
            ([FromQuery] int id)
        {
            var typeRoom = await typeRoomQueryService
                .Handle(new GetTypeRoomByIdQuery(id));

            if (typeRoom is null)
                return BadRequest();

            var typeRoomResource = TypeRoomResourceFromEntityAssembler
                .ToResourceFromEntity(typeRoom);

            return Ok(typeRoomResource);
        }
    }
}