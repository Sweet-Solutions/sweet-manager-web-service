using SweetManagerWebService.Commerce.Domain.Model.Entities.Contracts;
using SweetManagerWebService.Commerce.Domain.Model.Entities.Payments;
using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.Profiles.Domain.Model.Entities;

namespace SweetManagerWebService.IAM.Domain.Model.Aggregates
{
    public partial class Owner(int id, string username, string name, string surname,
        int phone, string email, string state)
    {
        public int Id { get; private set; } = id;
        public string Username { get; private set; } = username;
        public string Name { get; private set; } = name;
        public string Surname { get; private set; } = surname;
        public int Phone { get; private set; } = phone;
        public string Email { get; private set; } = email;
        public string State { get; private set; } = state;

        public virtual OwnerCredential? OwnerCredential { get; }

        public virtual ICollection<ContractOwner> ContractsOwners { get; } = [];
        public virtual ICollection<Hotel> Hotels { get; } = [];
        public virtual ICollection<Notification> Notifications { get; } = [];
        public virtual ICollection<PaymentOwner> PaymentsOwners { get; } = [];
        public virtual ICollection<Role> Roles { get; } = [];
    }
}