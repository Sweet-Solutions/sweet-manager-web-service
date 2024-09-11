namespace SweetManagerWebService.Models
{
    public partial class Worker
    {
        public int Id { get; set; }
        public int RolesId { get; set; }
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
        public string State { get; set; } = null!;

        public virtual Role Role { get; } = null!;
        public virtual WorkerCredential? WorkerCredential { get; }

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; } = [];
        public virtual ICollection<Notification> Notifications { get; } = [];
        public virtual ICollection<Report> Reports { get; } = [];
    }
}