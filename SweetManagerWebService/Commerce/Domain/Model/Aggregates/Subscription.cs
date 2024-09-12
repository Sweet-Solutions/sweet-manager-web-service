using SweetManagerWebService.Commerce.Domain.Model.Entities.Contracts;

namespace SweetManagerWebService.Commerce.Domain.Model.Aggregates
{
    public partial class Subscription
    {
        public int Id { get; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string State { get; set; } = null!;

        public virtual ICollection<ContractOwner> ContractsOwners { get; } = [];
    }
}