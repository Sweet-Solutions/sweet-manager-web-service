using SweetManagerWebService.Commerce.Domain.Model.Entities.Payments;

namespace SweetManagerWebService.Profiles.Domain.Model.Aggregates
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string State { get; set; } = null!;

        public virtual ICollection<PaymentCustomer> PaymentsCustomers { get; } = [];
    }
}