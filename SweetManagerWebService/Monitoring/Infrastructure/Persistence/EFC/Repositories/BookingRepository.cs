using Microsoft.EntityFrameworkCore;
using SweetManagerWebService.Monitoring.Domain.Model.Aggregates;
using SweetManagerWebService.Monitoring.Domain.Model.ValueObjects.Booking;
using SweetManagerWebService.Monitoring.Domain.Repositories;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    public class BookingRepository
        (SweetManagerContext context) :
        BaseRepository<Booking>(context),
        IBookingRepository
    {
        public async Task<bool> UpdateBookingStateAsync
            (int id, EBookingState bookingState) =>
            await Context.Set<Booking>().Where(b => b.Id == id)
            .ExecuteUpdateAsync(b => b
            .SetProperty(u => u.State, bookingState.ToString())) > 0;
    }
}