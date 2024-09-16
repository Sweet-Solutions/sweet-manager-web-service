using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;
using SweetManagerWebService.IAM.Domain.Model.Queries;
using SweetManagerWebService.IAM.Domain.Services.Credential.Worker;

namespace SweetManagerWebService.IAM.Application.Internal.QueryServices.Credential;

public class WorkerCredentialQueryService : IWorkerCredentialQueryService
{
    public Task<WorkerCredential?> Handle(GetUserCredentialByIdQuery query)
    {
        throw new NotImplementedException();
    }
}