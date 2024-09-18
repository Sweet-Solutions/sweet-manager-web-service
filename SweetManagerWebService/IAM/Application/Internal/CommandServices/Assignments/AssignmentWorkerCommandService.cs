using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.IAM.Domain.Model.Commands.Assignments;
using SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;
using SweetManagerWebService.IAM.Domain.Repositories.Assignments;
using SweetManagerWebService.IAM.Domain.Services.Assignments;

namespace SweetManagerWebService.IAM.Application.Internal.CommandServices.Assignments;

public class AssignmentWorkerCommandService(IAssignmentWorkerRepository assignmentWorkerRepository, 
    IUnitOfWork unitOfWork) : IAssignmentWorkerCommandService
{
    public async Task<bool> Handle(CreateAssignmentWorkerCommand command)
    {
        try
        {
            await assignmentWorkerRepository.AddAsync(new AssignmentWorker(command));

            await unitOfWork.CompleteAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}