using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.IAM.Domain.Model.Queries;

namespace SweetManagerWebService.IAM.Domain.Services.Roles;

public interface IWorkerAreaQueryService
{
    Task<IEnumerable<WorkerArea>> Handle(GetAllWorkerAreasQuery query);
    
    Task<WorkerArea> Handle(GetWorkerAreaByNameQuery query);

    Task<int> Handle(GetWorkerAreaIdByRoleNameQuery query);
}