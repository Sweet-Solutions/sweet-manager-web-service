namespace SweetManagerWebService.Models
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