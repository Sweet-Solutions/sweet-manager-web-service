using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Commands.Assignments;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;

namespace SweetManagerWebService.IAM.Domain.Model.Entities.Assignments
{
    public partial class AssignmentWorker(CreateAssignmentWorker command)
    {
        public int Id { get; }
        public int WorkersAreasId { get; private set; } = command.WorkersAreasId;
        public int WorkersId { get; private set; } = command.WorkersId;
        public int AdminsId { get; private set; } = command.AdminsId;
        public DateTime StartDate { get; private set; } = command.StartDate;
        public DateTime FinalDate { get; private set; } = command.FinalDate;
        public string State { get; private set; } = command.State;

        public virtual Admin Admin { get; } = null!;
        public virtual Worker Worker { get; } = null!;
        public virtual WorkerArea WorkerArea { get; } = null!;
    }
}