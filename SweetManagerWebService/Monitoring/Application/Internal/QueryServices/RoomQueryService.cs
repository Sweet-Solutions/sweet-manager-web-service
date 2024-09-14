using SweetManagerWebService.Monitoring.Domain.Model.Aggregates;
using SweetManagerWebService.Monitoring.Domain.Model.Queries.Room;
using SweetManagerWebService.Monitoring.Domain.Repositories;
using SweetManagerWebService.Monitoring.Domain.Services.Room;

namespace SweetManagerWebService.Monitoring.Application.Internal.QueryServices
{
    public class RoomQueryService
        (IRoomRepository roomRepository) :
        IRoomQueryService
    {
        public async Task<IEnumerable<Room>> Handle
            (GetAllRoomsQuery query) =>
            await roomRepository.ListAsync();

        public async Task<Room?> Handle
            (GetRoomByIdQuery query) =>
            await roomRepository
            .FindByIdAsync(query.Id);
    }
}