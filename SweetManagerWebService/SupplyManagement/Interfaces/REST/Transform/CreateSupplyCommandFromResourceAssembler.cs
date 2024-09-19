using SweetManagerWebService.SupplyManagement.Domain.Model.Commands;

namespace SweetManagerWebService.SupplyManagement.Interfaces.REST.Transform;

public class CreateSupplyCommandFromResourceAssembler
{
    public static CreateSupplyCommand ToCommandFromResource(CreateSupplyResource resource)
    {
        return new CreateSupplyCommand(resource.ProvidersId, resource.Name, resource.Price, resource.Stock, resource.State);
    }
}