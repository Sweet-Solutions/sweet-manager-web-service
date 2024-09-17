namespace SweetManagerWebService.SupplyManagement.Interfaces.REST;

public record UpdateSupplyResource(int Id, string Name, decimal Price, int Stock, string State);