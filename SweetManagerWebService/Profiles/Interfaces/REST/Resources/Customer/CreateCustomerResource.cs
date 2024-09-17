namespace SweetManagerWebService.Profiles.Interfaces.REST.Resources.Customer;

public record CreateCustomerResource(
    string Username, string Name, string Surname,string Email, int Phone, string State);

