using SweetManagerWebService.IAM.Domain.Model.Commands.Authentication.User;

namespace SweetManagerWebService.IAM.Domain.Services.Users.Owner;

public interface IOwnerCommandService
{
    Task<bool> Handle(SignUpUserCommand command);

    Task<bool> Handle(UpdateUserCommand command);
}