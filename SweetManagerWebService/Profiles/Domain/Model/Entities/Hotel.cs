using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.Monitoring.Domain.Model.Aggregates;

namespace SweetManagerWebService.Profiles.Domain.Model.Entities
{
    public partial class Hotel
    {
        public int Id { get; }
        public int OwnersId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;

        public virtual Owner Owner { get; } = null!;

        public virtual ICollection<Room> Rooms { get; } = [];
    }
}