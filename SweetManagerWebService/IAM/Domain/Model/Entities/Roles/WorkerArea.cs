using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;

namespace SweetManagerWebService.IAM.Domain.Model.Entities.Roles
{
    public partial class WorkerArea
    {
        public int Id { get; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; } = [];
    }
}