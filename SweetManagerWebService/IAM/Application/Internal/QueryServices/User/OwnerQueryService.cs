using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Queries;
using SweetManagerWebService.IAM.Domain.Repositories.Users;
using SweetManagerWebService.IAM.Domain.Services.Users.Owner;

namespace SweetManagerWebService.IAM.Application.Internal.QueryServices.User;

public class OwnerQueryService(IOwnerRepository ownerRepository) : IOwnerQueryService
{
    public async Task<Owner?> Handle(GetAllUsersQuery query)
    {
        return await ownerRepository.FindByHotelId(query.HotelId);
    }

    public async Task<Owner?> Handle(GetUserByIdQuery query)
    {
        return await ownerRepository.FindById(query.Id);
    }

    public async Task<Owner?> Handle(GetUserByEmailQuery query)
    {
        return await ownerRepository.FindByEmail(query.Email);
    }

    public async Task<int?> Handle(GetUserIdByEmailQuery query)
    {
        return await ownerRepository.FindIdByEmail(query.Email);
    }
}