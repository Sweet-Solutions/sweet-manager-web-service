using SweetManagerWebService.IAM.Domain.Model.Aggregates;

namespace SweetManagerWebService.IAM.Domain.Model.Entities.Credentials
{
    public partial class WorkerCredential
    {
        public int WorkersId { get; set; }
        public string Code { get; set; } = null!;

        public virtual Worker Worker { get; set; } = null!;
    }
}