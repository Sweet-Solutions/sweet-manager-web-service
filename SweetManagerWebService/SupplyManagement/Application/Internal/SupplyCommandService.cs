using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Model.Commands;
using SweetManagerWebService.SupplyManagement.Domain.Services;

namespace SweetManagerWebService.SupplyManagement.Application.Internal;

public class SupplyCommandService  : ISupplyCommandService
{
    public Task<bool> Handle(CreateSupplyCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Handle(UpdateSupplyCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Handle(DeleteSupplyCommand command)
    {
        throw new NotImplementedException();
    }
}