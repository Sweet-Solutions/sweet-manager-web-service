using SweetManagerWebService.Commerce.Domain.Model.Commands.Contracts;
using SweetManagerWebService.Commerce.Interfaces.REST.Resources.Contracts;

namespace SweetManagerWebService.Commerce.Interfaces.REST.Transform.Contracts;

public static class CreateContractOwnerCommandFromResourceAssembler
{
    public static CreateContractOwnerCommand ToCommandFromResource(CreateContractOwnerResource resource)
    {
        var startDate = DateTime.Parse(resource.StartDate);

        var finalDate = DateTime.Parse(resource.FinalDate);

        return new CreateContractOwnerCommand(resource.SubscriptionId, resource.OwnersId, startDate, finalDate,
            resource.State);
    }
}