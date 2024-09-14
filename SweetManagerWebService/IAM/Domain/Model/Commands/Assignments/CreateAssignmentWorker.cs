namespace SweetManagerWebService.IAM.Domain.Model.Commands.Assignments;

public record CreateAssignmentWorker(int WorkersAreasId, int WorkersId, int AdminsId,
    DateTime StartDate, DateTime FinalDate, string State);