namespace SweetManagerWebService.Models
{
    public partial class TypeRoom
    {
        public int Id { get; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Room> Rooms { get; } = [];
    }
}