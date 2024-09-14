using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.Monitoring.Domain.Model.Aggregates;

namespace SweetManagerWebService.Monitoring.Domain.Repositories
{
    public interface IBookingRepository :
        IBaseRepository<Booking>
    { }
}