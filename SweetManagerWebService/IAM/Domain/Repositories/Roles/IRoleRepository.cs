using SweetManagerWebService.IAM.Domain.Model.Entities.Roles;

namespace SweetManagerWebService.IAM.Domain.Repositories.Roles;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> FindAllAsync();

    Task<Role> FindByName(int name);

    Task<int> FindIdByName(int name);
}