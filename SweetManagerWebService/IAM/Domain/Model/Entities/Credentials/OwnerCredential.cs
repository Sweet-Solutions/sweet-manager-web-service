using SweetManagerWebService.IAM.Domain.Model.Aggregates;

namespace SweetManagerWebService.IAM.Domain.Model.Entities.Credentials
{
    public partial class OwnerCredential
    {
        public int OwnersId { get; set; }
        public string Code { get; set; } = null!;

        public virtual Owner Owner { get; } = null!;
    }
}