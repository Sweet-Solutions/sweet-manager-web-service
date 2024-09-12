using SweetManagerWebService.Monitoring.Domain.Model.Aggregates;
using SweetManagerWebService.Profiles.Domain.Model.Aggregates;

namespace SweetManagerWebService.Commerce.Domain.Model.Entities.Payments
{
    public partial class PaymentCustomer
    {
        public int Id { get; }
        public int CustomersId { get; set; }
        public decimal FinalAmount { get; set; }

        public virtual Customer Customer { get; } = null!;

        public virtual ICollection<Booking> Bookings { get; } = [];
    }
}