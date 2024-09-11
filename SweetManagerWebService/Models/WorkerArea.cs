namespace SweetManagerWebService.Models
{
    public partial class WorkerArea
    {
        public int Id { get; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; } = [];
    }
}