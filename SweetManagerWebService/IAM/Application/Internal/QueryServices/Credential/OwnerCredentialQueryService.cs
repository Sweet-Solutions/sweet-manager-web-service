using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;
using SweetManagerWebService.IAM.Domain.Model.Queries;
using SweetManagerWebService.IAM.Domain.Services.Credential.Owner;

namespace SweetManagerWebService.IAM.Application.Internal.QueryServices.Credential;

public class OwnerCredentialQueryService : IOwnerCredentialQueryService
{
    public Task<OwnerCredential?> Handle(GetUserCredentialByIdQuery query)
    {
        throw new NotImplementedException();
    }
}