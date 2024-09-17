using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;

namespace SweetManagerWebService.IAM.Domain.Repositories.Assignments;

public interface IAssignmentWorkerRepository : IBaseRepository<AssignmentWorker>
{
    
    Task<AssignmentWorker?> FindByWorkerIdAsync(int workerId, int hotelId);

    Task<IEnumerable<AssignmentWorker>> FindByAdminIdAsync(int adminId, int hotelId);

    Task<IEnumerable<AssignmentWorker>> FindByWorkerAreaIdAsync(int workerAreaId, int hotelId);
    
}