namespace SweetManagerWebService.IAM.Domain.Model.Commands.Authentication.User;

public record SignUpUserCommand(int Id, int RolesId, string Username, string Name, string Surname, string Email, int Phone, string State);