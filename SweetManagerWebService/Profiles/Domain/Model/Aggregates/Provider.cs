using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;

namespace SweetManagerWebService.Profiles.Domain.Model.Aggregates
{
    public partial class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string State { get; set; } = null!;

        public virtual ICollection<Supply> Supplies { get; } = [];
    }
}