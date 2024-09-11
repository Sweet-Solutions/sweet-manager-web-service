namespace SweetManagerWebService.Models
{
    public partial class OwnerCredential
    {
        public int OwnersId { get; set; }
        public string Code { get; set; } = null!;

        public virtual Owner Owner { get; } = null!;
    }
}