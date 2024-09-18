namespace SweetManagerWebService.Commerce.Domain.Model.Commands.Contracts;

public record CreateContractOwnerCommand(int SubscriptionId, int OwnersId, DateTime StartDate, DateTime FinalDate, string State);