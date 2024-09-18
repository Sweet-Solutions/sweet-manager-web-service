namespace SweetManagerWebService.Commerce.Interfaces.REST.Resources.Contracts;

public record CreateContractOwnerResource(int SubscriptionId, int OwnersId, string StartDate, string FinalDate, string State);