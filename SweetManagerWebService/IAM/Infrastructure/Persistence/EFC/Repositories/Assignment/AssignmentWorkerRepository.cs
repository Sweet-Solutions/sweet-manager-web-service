using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.IAM.Domain.Repositories.Assignments;
using SweetManagerWebService.Profiles.Domain.Model.Entities;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.Assignment;

public class AssignmentWorkerRepository(SweetManagerContext context) : BaseRepository<AssignmentWorker>(context), IAssignmentWorkerRepository
{

    public async Task<AssignmentWorker?> FindByWorkerIdAsync(int workerId, int hotelId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            join wk in Context.Set<Worker>().ToList() on aw.WorkersId equals wk.Id
            join rl in Context.Set<Role>().ToList() on wk.RolesId equals rl.Id
            join ow in Context.Set<Owner>().ToList() on rl.Id equals ow.RolesId
            join ho in Context.Set<Hotel>().ToList() on ow.Id equals ho.OwnersId
            where ho.Id.Equals(hotelId) && wk.Id.Equals(workerId)
            select aw
        ).FirstOrDefault());

    public async Task<IEnumerable<AssignmentWorker>> FindByAdminIdAsync(int adminId, int hotelId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            join wk in Context.Set<Worker>().ToList() on aw.WorkersId equals wk.Id
            join rl in Context.Set<Role>().ToList() on wk.RolesId equals rl.Id
            join ow in Context.Set<Owner>().ToList() on rl.Id equals ow.RolesId
            join ho in Context.Set<Hotel>().ToList() on ow.Id equals ho.OwnersId
            where ho.Id.Equals(hotelId) && aw.AdminsId.Equals(adminId)
            select aw
        ).ToList());

    public async Task<IEnumerable<AssignmentWorker>> FindByWorkerAreaIdAsync(int workerAreaId, int hotelId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            join wk in Context.Set<Worker>().ToList() on aw.WorkersId equals wk.Id
            join rl in Context.Set<Role>().ToList() on wk.RolesId equals rl.Id
            join ow in Context.Set<Owner>().ToList() on rl.Id equals ow.RolesId
            join ho in Context.Set<Hotel>().ToList() on ow.Id equals ho.OwnersId
            where ho.Id.Equals(hotelId) && aw.WorkersAreasId.Equals(workerAreaId)
            select aw
        ).ToList());

}