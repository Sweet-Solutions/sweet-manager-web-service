using SweetManagerWebService.IAM.Domain.Model.Entities.Credentials;

namespace SweetManagerWebService.IAM.Domain.Repositories.Credential;

public interface IOwnerCredentialRepository
{
    Task<OwnerCredential?> FindByOwnersIdAsync(int ownersId);
}