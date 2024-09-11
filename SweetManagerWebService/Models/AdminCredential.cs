namespace SweetManagerWebService.Models
{

    public partial class AdminCredential
    {
        public int AdminsId { get; set; }
        public string Code { get; set; } = null!;

        public virtual Admin Admin { get; } = null!;
    }
}