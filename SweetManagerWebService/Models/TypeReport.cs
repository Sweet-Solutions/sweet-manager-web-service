namespace SweetManagerWebService.Models
{
    public partial class TypeReport
    {
        public int Id { get; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Report> Reports { get; } = [];
    }
}