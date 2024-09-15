using SweetManagerWebService.IAM.Domain.Model.Aggregates;

namespace SweetManagerWebService.IAM.Domain.Repositories.Users;

public interface IWorkerRepository
{
    Task<IEnumerable<Worker>> FindAllByHotelId(int hotelId);

    Task<Worker?> FindById(int id);

    Task<Worker?> FindByEmail(string email);

    Task<int?> FindIdByEmail(string email);
}