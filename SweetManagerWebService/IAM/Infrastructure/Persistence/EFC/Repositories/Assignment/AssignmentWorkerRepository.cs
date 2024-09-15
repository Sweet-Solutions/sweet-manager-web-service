using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;
using SweetManagerWebService.IAM.Domain.Repositories.Assignments;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.Assignment;

public class AssignmentWorkerRepository(SweetManagerContext context) : BaseRepository<AssignmentWorker>(context), IAssignmentWorkerRepository
{
    public async Task<AssignmentWorker?> FindByWorkerIdAsync(int workerId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            where aw.WorkersId.Equals(workerId)
            select aw
        ).FirstOrDefault());

    public async Task<AssignmentWorker?> FindByAdminIdAsync(int adminId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            where aw.AdminsId.Equals(adminId)
            select aw
        ).FirstOrDefault());
    
    public async Task<AssignmentWorker?> FindByWorkerAreaIdAsync(int workerAreaId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            where aw.WorkersAreasId.Equals(workerAreaId)
            select aw
        ).FirstOrDefault());
}