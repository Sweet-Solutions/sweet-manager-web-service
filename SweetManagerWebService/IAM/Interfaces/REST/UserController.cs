using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerWebService.IAM.Domain.Services.Users.Admin;
using SweetManagerWebService.IAM.Domain.Services.Users.Owner;
using SweetManagerWebService.IAM.Domain.Services.Users.Worker;
using SweetManagerWebService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using SweetManagerWebService.IAM.Interfaces.REST.Resource.Authentication.User;
using SweetManagerWebService.IAM.Interfaces.REST.Transform.Authentication.User;

namespace SweetManagerWebService.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController(IWorkerCommandService workerCommandService,
    IAdminCommandService adminCommandService, 
    IOwnerCommandService ownerCommandService) : ControllerBase
{
    [HttpPut("update-admin")]
    [Authorize]
    public async Task<IActionResult> UpdateAdmin([FromBody]UpdateUserResource resource)
    {
        try
        {
            var updateUserCommand = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await adminCommandService.Handle(updateUserCommand);
            
            return Ok("User updated correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update-owner")]
    [Authorize]
    public async Task<IActionResult> UpdateOwner([FromBody] UpdateUserResource resource)
    {
        try
        {
            var updateUserCommand = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await ownerCommandService.Handle(updateUserCommand);

            return Ok("User updated correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update-worker")]
    [Authorize]
    public async Task<IActionResult> UpdateWorker([FromBody] UpdateUserResource resource)
    {
        try
        {
            var updateUserCommand = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await workerCommandService.Handle(updateUserCommand);

            return Ok("User updated correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}