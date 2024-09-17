using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerWebService.IAM.Domain.Model.Queries;
using SweetManagerWebService.IAM.Domain.Services.Assignments;
using SweetManagerWebService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using SweetManagerWebService.IAM.Interfaces.REST.Resource.Assignments;
using SweetManagerWebService.IAM.Interfaces.REST.Resource.Authentication.Role;
using SweetManagerWebService.IAM.Interfaces.REST.Transform.Assignments;

namespace SweetManagerWebService.IAM.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AssignmentWorkerController(IAssignmentWorkerCommandService assignmentWorkerCommandService,
    IAssignmentWorkerQueryService assignmentWorkerQueryService) : ControllerBase
{
    [HttpPost("create-assignment-worker")]
    [Authorize]
    public async Task<IActionResult> CreateAssignmentWorker([FromBody] CreateAssignmentWorkerResource resource)
    {
        try
        {
            var createAssignmentWorkerCommand =
                CreateAssignmentWorkerCommandFromResourceAssembler.ToCommandFromResource(resource);

            await assignmentWorkerCommandService.Handle(createAssignmentWorkerCommand);

            return Ok("Assignment worker created correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-assignment-worker")]
    [Authorize]
    public async Task<IActionResult> GetAssignmentWorkersByWorkerId([FromBody] SearchingQueriesForId resource)
    {
        try
        {
            var assignmentWorker =
                await assignmentWorkerQueryService.Handle(new GetAssignmentWorkerByWorkerIdQuery(resource.Id, resource.HotelId));

            if (assignmentWorker is null)
                return BadRequest($"There's no assignment worker for the id: {resource.Id}");
            
            var assignmentWorkerResource =
                AssignmentWorkerResourceFromEntityAssembler.ToResourceFromEntity(assignmentWorker);

            return Ok(assignmentWorkerResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-all-assignments-admin")]
    [Authorize]
    public async Task<IActionResult> GetAssignmentWorkersByAdminId([FromBody] SearchingQueriesForId resource)
    {
        try
        {
            var admins 
                = await assignmentWorkerQueryService.Handle(new GetAssignmentWorkerByAdminIdQuery(resource.Id, resource.HotelId));

            var adminsResource 
                = admins.Select(AssignmentWorkerResourceFromEntityAssembler.ToResourceFromEntity);
            
            return Ok(adminsResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-assignments-workers-area")]
    [Authorize]
    public async Task<IActionResult> GetAssignmentWorkersByWorkerAreaId([FromBody] SearchingQueriesForId resource)
    {
        try
        {
            var assignmentWorkers
                = await assignmentWorkerQueryService.Handle(
                    new GetAssignmentWorkerByWorkerAreaIdQuery(resource.Id, resource.HotelId));

            var assignmentWorkerResources =
                assignmentWorkers.Select(AssignmentWorkerResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(assignmentWorkerResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}