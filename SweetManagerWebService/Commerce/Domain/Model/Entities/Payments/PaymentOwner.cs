using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Model.Entities;

namespace SweetManagerWebService.Commerce.Domain.Model.Entities.Payments
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