using SweetManagerWebService.Monitoring.Domain.Model.Entities;
using SweetManagerWebService.Profiles.Domain.Model.Entities;

namespace SweetManagerWebService.Monitoring.Domain.Model.Aggregates
{
    public partial class Room
    {
        public int Id { get; }
        public int TypesRoomsId { get; set; }
        public int HotelsId { get; set; }
        public string State { get; set; } = null!;

        public virtual Hotel Hotel { get; } = null!;
        public virtual TypeRoom TypeRoom { get; } = null!;

        public virtual ICollection<Booking> Bookings { get; } = [];
    }
}