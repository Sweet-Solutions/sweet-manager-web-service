using SweetManagerWebService.Commerce.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;

namespace SweetManagerWebService.Commerce.Domain.Model.Entities.Contracts
{
    public partial class ContractOwner
    {
        public int Id { get; }
        public int SubscriptionsId { get; set; }
        public int OwnersId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string State { get; set; } = null!;

        public virtual Owner Owner { get; } = null!;
        public virtual Subscription Subscription { get; } = null!;
    }
}