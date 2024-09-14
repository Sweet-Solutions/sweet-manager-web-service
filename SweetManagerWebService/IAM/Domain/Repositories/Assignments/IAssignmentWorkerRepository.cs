using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;

namespace SweetManagerWebService.IAM.Domain.Repositories.Assignments;

public interface IAssignmentWorkerRepository
{
    Task<AssignmentWorker> FindByIdAsync(int id);

    Task<AssignmentWorker> FindByWorkerIdAsync(int workerId);

    Task<AssignmentWorker> FindByAdminIdAsync(int adminId);

    Task<AssignmentWorker> FindByWorkerAreaIdAsync(int workerAreaId);
    
}