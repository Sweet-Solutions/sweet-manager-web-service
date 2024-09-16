using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;
using SweetManagerWebService.IAM.Domain.Model.Queries;
using SweetManagerWebService.IAM.Domain.Services.Credential.Admin;

namespace SweetManagerWebService.IAM.Application.Internal.QueryServices.Credential;

public class AdminCredentialQueryService: IAdminCredentialQueryService
{
    public Task<AdminCredential?> Handle(GetUserCredentialByIdQuery query)
    {
        throw new NotImplementedException();
    }
}