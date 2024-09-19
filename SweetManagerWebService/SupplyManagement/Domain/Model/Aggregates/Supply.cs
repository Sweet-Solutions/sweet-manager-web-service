using SweetManagerWebService.Profiles.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Model.Commands;
using SweetManagerWebService.SupplyManagement.Domain.Model.Entities;

namespace SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates
{
    public partial class Supply
    {
        public int Id { get; }
        public int ProvidersId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string State { get; set; } = null!;

        public virtual Provider Provider { get; } = null!;

        public virtual ICollection<SuppliesRequest> SuppliesRequests { get; } = [];
        
        
        public Supply(int id, int providersId, string name, decimal price, int stock, string state)
        {
            Id = id;
            ProvidersId = providersId;
            Name = name;
            Price = price;
            Stock = stock;
            State = state;
        }

        public Supply(CreateSupplyCommand command)
        {
            ProvidersId = command.ProvidersId; 
            Name = command.Name;
            Price = command.Price;
            Stock = command.Stock;
            State = command.State;
        }
        
        public void Update(UpdateSupplyCommand command)
        {
            ProvidersId = command.ProvidersId;
            Name = command.Name;
            Price = command.Price;
            Stock = command.Stock;
            State = command.State;
        }
        
        public void Delete()
        {
            
        }
    }
}