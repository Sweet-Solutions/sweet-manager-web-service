﻿using SweetManagerWebService.Commerce.Domain.Model.Entities.Payments;
using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;

namespace SweetManagerWebService.SupplyManagement.Domain.Model.Entities
{
    public partial class SuppliesRequest
    {
        public int Id { get; }
        public int PaymentsOwnersId { get; set; }
        public int SuppliesId { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }

        public virtual PaymentOwner PaymentOwner { get; } = null!;
        public virtual Supply Supply { get; } = null!;
    }
}