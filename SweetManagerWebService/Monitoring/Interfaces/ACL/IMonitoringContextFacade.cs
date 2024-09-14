namespace SweetManagerWebService.Monitoring.Interfaces.ACL
{
    public interface IMonitoringContextFacade
    {
        Task<bool> ExistsBookingById(int id);

        Task<bool> ExistsRoomById(int id);
    }
}