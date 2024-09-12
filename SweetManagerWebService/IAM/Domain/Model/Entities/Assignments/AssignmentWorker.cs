using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;

namespace SweetManagerWebService.IAM.Domain.Model.Entities.Assignments
{
    public partial class AssignmentWorker
    {
        public int Id { get; }
        public int WorkersAreasId { get; set; }
        public int WorkersId { get; set; }
        public int AdminsId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string State { get; set; } = null!;

        public virtual Admin Admin { get; } = null!;
        public virtual Worker Worker { get; } = null!;
        public virtual WorkerArea WorkerArea { get; } = null!;
    }
}