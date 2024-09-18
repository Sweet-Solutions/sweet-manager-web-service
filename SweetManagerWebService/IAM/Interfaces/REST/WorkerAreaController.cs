﻿using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerWebService.IAM.Domain.Model.Queries;
using SweetManagerWebService.IAM.Domain.Services.Roles;
using SweetManagerWebService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using SweetManagerWebService.IAM.Interfaces.REST.Resource.Authentication.Role;
using SweetManagerWebService.IAM.Interfaces.REST.Transform.Authentication.Role;

namespace SweetManagerWebService.IAM.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class WorkerAreaController(IWorkerAreaCommandService workerAreaCommandService, 
    IWorkerAreaQueryService workerAreaQueryService) : ControllerBase
{
    [HttpPost("create-worker-area")]
    [Authorize]
    public async Task<IActionResult> CreateWorkerArea([FromBody] CreateWorkAreaResource resource)
    {
        try
        {
            var createWorkAreaCommand =
                CreateWorkAreaCommandFromResourceAssembler.ToCommandFromResource(resource);

            await workerAreaCommandService.Handle(createWorkAreaCommand);

            return Ok("Worker Area created correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-all-worker-areas")]
    [Authorize]
    public async Task<IActionResult> GetAllWorkerAreas([FromQuery] int hotelId)
    {
        try
        {
            var workerAreas = await workerAreaQueryService.Handle(new GetAllWorkerAreasByHotelIdQuery(hotelId));

            var workerAreasResource = workerAreas.Select(WorkAreaResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(workerAreasResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-worker-area-name")]
    [Authorize]
    public async Task<IActionResult> GetWorkerAreaByName([FromBody] SearchingQueriesForName resource)
    {
        try
        {
            var workerArea =
                await workerAreaQueryService.Handle(
                    new GetWorkerAreaByNameAndHotelIdQuery(resource.Name, resource.HotelId));

            if (workerArea is null)
                return BadRequest("Any work area has the given name");
            
            var workerAreaResource = WorkAreaResourceFromEntityAssembler.ToResourceFromEntity(workerArea);

            return Ok(workerAreaResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}