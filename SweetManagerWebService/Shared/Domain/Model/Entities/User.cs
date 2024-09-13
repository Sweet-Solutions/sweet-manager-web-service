using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.Shared.Domain.Model.ValueObjects;

namespace SweetManagerWebService.Shared.Domain.Model.Entities;

public class User(string? username, string email, Role? role, string name, string surname, string phoneNumber)
{
    public int Id { get; set; }
    
    public string? Username { get; private set; } = username;

    public string Email { get; private set; } = email;

    public Role? Role { get; private set; } = role;

    public CompleteName Name { get; private set; } = new CompleteName(name, surname);

    public string PhoneNumber { get; private set; } = phoneNumber;

    public User() : this(string.Empty, string.Empty, new Role(), string.Empty, string.Empty, string.Empty){ }
    
}