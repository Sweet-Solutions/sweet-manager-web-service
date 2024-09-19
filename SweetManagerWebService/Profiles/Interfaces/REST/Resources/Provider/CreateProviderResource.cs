namespace SweetManagerWebService.Profiles.Interfaces.REST.Resources.Provider;

public record CreateProviderResource(string Name, string Address, string Email, int Phone, string State);

