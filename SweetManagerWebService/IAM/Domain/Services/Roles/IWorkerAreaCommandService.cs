
using SweetManagerWebService.IAM.Domain.Model.Commands.Assignments;

namespace SweetManagerWebService.IAM.Domain.Services.Roles;

public interface IWorkerAreaCommandService
{
    Task<bool> Handle(CreateAssignmentWorker command);

}