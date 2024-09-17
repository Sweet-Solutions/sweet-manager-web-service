namespace SweetManagerWebService.SupplyManagement.Interfaces.REST;

public record SupplyResource(int Id, string Name, decimal Price, int Stock, string State);