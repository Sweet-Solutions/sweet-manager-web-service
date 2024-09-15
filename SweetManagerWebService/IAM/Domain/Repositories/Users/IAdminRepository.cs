using SweetManagerWebService.IAM.Domain.Model.Aggregates;

namespace SweetManagerWebService.IAM.Domain.Repositories.Users;

public interface IAdminRepository
{
    Task<IEnumerable<Admin>> FindAllByHotelId(int hotelId);

    Task<Admin?> FindById(int id);

    Task<Admin?> FindByEmail(string email);

    Task<int?> FindIdByEmail(string email);
    
}