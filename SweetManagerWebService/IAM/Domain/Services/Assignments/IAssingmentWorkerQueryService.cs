using SweetManagerWebService.IAM.Domain.Model.Commands.Assignments;
using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;
using SweetManagerWebService.IAM.Domain.Model.Queries;

namespace SweetManagerWebService.IAM.Domain.Services.Assignments;

public interface IAssignmentWorkerQueryService
{
    Task<AssignmentWorker?> Handle(GetAssignmentWorkerByIdQuery query);

    Task<AssignmentWorker?> Handle(GetAssignmentWorkerByAdminIdQuery query);

    Task<AssignmentWorker?> Handle(GetAssignmentWorkerByWorkerIdQuery query);

    Task<AssignmentWorker?> Handle(GetAssignmentWorkerByWorkerAreaIdQuery query);

}