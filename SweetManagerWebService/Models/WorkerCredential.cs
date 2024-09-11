namespace SweetManagerWebService.Models
{
    public partial class WorkerCredential
    {
        public int WorkersId { get; set; }
        public string Code { get; set; } = null!;

        public virtual Worker Worker { get; set; } = null!;
    }
}