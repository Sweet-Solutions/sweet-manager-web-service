using SweetManagerWebService.Monitoring.Interfaces.ACL;

namespace SweetManagerWebService.IAM.Application.Internal.OutboundServices;

public class ExternalRoomService(IMonitoringContextFacade monitoringContextFacade)
{
    public async Task<int> FetchRoomCount(int hotelId)
    {
        return await monitoringContextFacade.GetRoomsCount(hotelId);
    }
}