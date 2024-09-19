using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;
using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;
using SweetManagerWebService.IAM.Domain.Repositories.Roles;
using SweetManagerWebService.Profiles.Domain.Model.Entities;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.Roles;

public class WorkerAreaRepository(SweetManagerContext context) : BaseRepository<WorkerArea>(context), IWorkerAreaRepository
{
    public async Task<IEnumerable<WorkerArea>> FindAllAsync(int hotelId)
        => await Task.Run(() => (
            from wa in Context.Set<WorkerArea>().ToList()
            join aw in Context.Set<AssignmentWorker>().ToList()
                on wa.Id equals aw.WorkersAreasId
            join ad in Context.Set<Admin>().ToList()
                on aw.AdminsId equals ad.Id
            join nt in Context.Set<Notification>().ToList()
                on ad.Id equals nt.AdminsId
            join ow in Context.Set<Owner>().ToList()
                on nt.OwnersId equals ow.Id
            join ho in Context.Set<Hotel>().ToList()
                on ow.Id equals ho.OwnersId
            where ho.Id.Equals(hotelId)
            select wa
        ).ToList());

    public async Task<WorkerArea?> FindByNameAsync(string name, int hotelId)
        => await Task.Run(() => (
            from wa in Context.Set<WorkerArea>().ToList()
            join aw in Context.Set<AssignmentWorker>().ToList()
                on wa.Id equals aw.WorkersAreasId
            join ad in Context.Set<Admin>().ToList()
                on wa.Id equals ad.Id
            join nt in Context.Set<Notification>().ToList()
                on ad.Id equals nt.AdminsId
            join ow in Context.Set<Owner>().ToList()
                on nt.OwnersId equals ow.Id
            join ho in Context.Set<Hotel>().ToList()
                on ow.Id equals ho.OwnersId
            where wa.Name == name && ho.Id == hotelId
            select wa
        ).FirstOrDefault());

    public async Task<int?> FindIdByNameAsync(string name, int hotelId)
        => await Task.Run(() => (
            from wa in Context.Set<WorkerArea>().ToList()
            join aw in Context.Set<AssignmentWorker>().ToList()
                on wa.Id equals aw.WorkersAreasId
            join ad in Context.Set<Admin>().ToList()
                on wa.Id equals ad.Id
            join nt in Context.Set<Notification>().ToList()
                on ad.Id equals nt.AdminsId
            join ow in Context.Set<Owner>().ToList()
                on nt.OwnersId equals ow.Id
            join ho in Context.Set<Hotel>().ToList()
                on ow.Id equals ho.OwnersId
            where wa.Name == name && ho.Id == hotelId
            select wa.Id
        ).FirstOrDefault());
    
}