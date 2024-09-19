namespace SweetManagerWebService.Monitoring.Interfaces.REST.Resources.Booking
{
    public record CreateBookingResource
        (int PaymentCustomerId, int RoomId,
        string Description, DateTime StartDate,
        DateTime FinalDate, decimal PriceRoom,
        int NightCount);
}