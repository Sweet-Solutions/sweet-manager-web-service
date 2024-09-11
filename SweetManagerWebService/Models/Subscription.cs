namespace SweetManagerWebService.Models
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