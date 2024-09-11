namespace SweetManagerWebService.Models
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