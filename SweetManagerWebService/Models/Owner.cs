namespace SweetManagerWebService.Models
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