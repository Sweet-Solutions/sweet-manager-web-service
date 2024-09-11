namespace SweetManagerWebService.Models
{
    public partial class Booking
    {
        public int Id { get; }
        public int PaymentsCustomersId { get; set; }
        public int RoomsId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal PriceRoom { get; set; }
        public int NightCount { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; } = null!;

        public virtual PaymentCustomer PaymentCustomer { get; } = null!;
        public virtual Room Room { get; } = null!;
    }
}