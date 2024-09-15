using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.IAM.Domain.Repositories.Roles;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.Roles;

public class WorkerAreaRepository(SweetManagerContext context) : BaseRepository<WorkerArea>(context), IWorkerAreaRepository
{
    public async Task<IEnumerable<WorkerArea>> FindAllAsync()
        => await Task.Run(() => (
            from wa in Context.Set<WorkerArea>().ToList()
            select wa
        ).ToList());

    public async Task<WorkerArea?> FindByNameAsync(string name)
        => await Task.Run(() => (
            from wa in Context.Set<WorkerArea>().ToList()
            where wa.Name.Equals(name)
            select wa
        ).FirstOrDefault());
    
    public async Task<int?> FindIdByNameAsync(string name)
        => await Task.Run(() => (
            from wa in Context.Set<Worker>().ToList()
            where wa.Name.Equals(name)
            select wa.Id
        ).FirstOrDefault());

}