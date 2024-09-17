namespace SweetManagerWebService.SupplyManagement.Domain.Model.Commands;

public record UpdateSupplyCommand(int Id, string Name, decimal Price, int Stock, string State); 