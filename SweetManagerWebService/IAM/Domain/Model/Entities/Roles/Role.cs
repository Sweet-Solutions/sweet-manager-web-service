﻿using SweetManagerWebService.IAM.Domain.Model.Aggregates;

namespace SweetManagerWebService.IAM.Domain.Model.Entities.Roles
{
    public partial class Role
    {
        public int Id { get; }
        public int OwnersId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Owner Owner { get; } = null!;

        public virtual ICollection<Admin> Admins { get; } = [];
        public virtual ICollection<Worker> Workers { get; } = [];
    }
}