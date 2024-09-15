using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;

namespace SweetManagerWebService.IAM.Domain.Repositories.Roles;

public interface IWorkerAreaRepository
{
    Task<IEnumerable<WorkerArea>> FindAllAsync();

    Task<WorkerArea?> FindByNameAsync(string name);

    Task<int?> FindIdByNameAsync(string name);
}