using SweetManagerWebService.SupplyManagement.Domain.Model.Commands;

namespace SweetManagerWebService.SupplyManagement.Interfaces.REST.Transform;

public class UpdateSupplyCommandFromResource
{
    public static UpdateSupplyCommand FromResource(UpdateSupplyResource resource)
    {
        return new UpdateSupplyCommand(resource.Id, resource.Name, resource.Price, resource.Stock, resource.State);
    }
}