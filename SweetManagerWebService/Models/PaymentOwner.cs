namespace SweetManagerWebService.Models
{
    public partial class PaymentOwner
    {
        public int Id { get; }
        public int OwnersId { get; set; }
        public string Description { get; set; } = null!;
        public decimal FinalAmount { get; set; }

        public virtual Owner Owner { get; } = null!;

        public virtual ICollection<SuppliesRequest> SuppliesRequests { get; } = [];
    }
}