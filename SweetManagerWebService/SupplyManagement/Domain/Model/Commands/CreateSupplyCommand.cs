namespace SweetManagerWebService.SupplyManagement.Domain.Model.Commands;

public record CreateSupplyCommand(string Name, decimal Price, int Stock, string State);