using SweetManagerWebService.IAM.Domain.Model.Aggregates;

namespace SweetManagerWebService.IAM.Domain.Repositories.Users;

public interface IOwnerRepository
{
    Task<Owner?> FindByHotelId(int hotelId);

    Task<Owner?> FindById(int id);

    Task<Owner?> FindByEmail(string email);

    Task<int?> FindIdByEmail(string email);
    
}