using SweetManagerWebService.Monitoring.Domain.Model.Aggregates;

namespace SweetManagerWebService.Monitoring.Domain.Model.Entities
{
    public partial class TypeRoom
    {
        public int Id { get; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Room> Rooms { get; } = [];
    }
}