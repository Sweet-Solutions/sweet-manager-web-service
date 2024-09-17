namespace SweetManagerWebService.SupplyManagement.Interfaces.REST;

public record CreateSupplyResource(string Name, decimal Price, int Stock, string State);