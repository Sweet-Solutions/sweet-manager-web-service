using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;
using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.ResourceManagement.Domain.Model.Aggregates;
using SweetManagerWebService.Shared.Domain.Model.Entities;

namespace SweetManagerWebService.IAM.Domain.Model.Aggregates
{
    public partial class Admin(int id, string username, string email, int rolesId, 
        string name, string surname, int phone, string state)
    {
        public int Id { get; private set; } = id;

        public int RolesId { get; private set; } = rolesId;
        
        public string Username { get; private set; } = username;
        
        public string Name { get; private set; } = name;
        
        public string Surname { get; private set; } = surname;

        public string Email { get; private set; } = email;

        public int Phone { get; private set; } = phone;
        
        public string State { get; private set; } = state;

        public virtual AdminCredential? AdminCredential { get; }
        public virtual Role Role { get; } = null!;

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; } = [];
        public virtual ICollection<Notification> Notifications { get; } = [];
        public virtual ICollection<Report> Reports { get; } = [];
    }
}