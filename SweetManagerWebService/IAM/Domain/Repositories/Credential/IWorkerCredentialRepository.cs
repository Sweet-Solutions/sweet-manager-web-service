using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;

namespace SweetManagerWebService.IAM.Domain.Repositories.Credential;

public interface IWorkerCredentialRepository
{
    Task<WorkerCredential> FindByIdAsync(int id);
    
}