using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;
using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.ResourceManagement.Domain.Model.Aggregates;

namespace SweetManagerWebService.IAM.Domain.Model.Aggregates
{
    public partial class Admin
    {
        public int Id { get; set; }
        public int RolesId { get; set; }
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
        public string State { get; set; } = null!;

        public virtual AdminCredential? AdminCredential { get; }
        public virtual Role Role { get; } = null!;

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; } = [];
        public virtual ICollection<Notification> Notifications { get; } = [];
        public virtual ICollection<Report> Reports { get; } = [];
    }
}