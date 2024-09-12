using SweetManagerWebService.Commerce.Domain.Model.Entities.Contracts;
using SweetManagerWebService.Commerce.Domain.Model.Entities.Payments;
using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.Profiles.Domain.Model.Entities;

namespace SweetManagerWebService.IAM.Domain.Model.Aggregates
{
    public partial class Owner
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
        public string State { get; set; } = null!;

        public virtual OwnerCredential? OwnerCredential { get; }

        public virtual ICollection<ContractOwner> ContractsOwners { get; } = [];
        public virtual ICollection<Hotel> Hotels { get; } = [];
        public virtual ICollection<Notification> Notifications { get; } = [];
        public virtual ICollection<PaymentOwner> PaymentsOwners { get; } = [];
        public virtual ICollection<Role> Roles { get; } = [];
    }
}