using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerWebService.SupplyManagement.Domain.Model.Queries;
using SweetManagerWebService.SupplyManagement.Domain.Services;
using SweetManagerWebService.SupplyManagement.Interfaces.REST.Resources;
using SweetManagerWebService.SupplyManagement.Interfaces.REST.Transform;

namespace SweetManagerWebService.SupplyManagement.Interfaces.REST;


[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class SupplyController : ControllerBase
{
    ISupplyQueryService _queryService;
    ISupplyCommandService _commandService;

    public SupplyController(ISupplyQueryService queryService, ISupplyCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSupply([FromBody] CreateSupplyResource resource)
    {
        var result =
            await _commandService.Handle(CreateSupplyCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSupply(int id, [FromBody] UpdateSupplyResource resource)
    {
        // Validate that the provided resource is valid
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // The `id` is passed via the route, so we don't pass it in the body
        var result = await _commandService.Handle(UpdateSupplyCommandFromResource.FromResource(id, resource));

        if (!result)
        {
            return BadRequest("Failed to update supply.");
        }

        return Ok(result);
    }

    
    [HttpDelete]
    public async Task<IActionResult> DeleteSupply([FromBody] DeleteSupplyResource resource)
    {
        var result =
            await _commandService.Handle(DeleteSupplyCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplyById([FromRoute] int id)
    {
        var result = await _queryService.Handle(new GetSupplyByIdQuery(id));
        if (result is null)
        {
            return BadRequest();
        }
    
        var supplyResource = SupplyResourceFromEntityAssembler.ToResourceFromEntity(result);

        return Ok(supplyResource);
    }

    
    [HttpGet]
    
    public async Task<IActionResult> GetAllSupplies()
    {
        var result = await _queryService.Handle(new GetAllSuppliesQuery());
        
        var supplyResource = result.Select(SupplyResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(supplyResource);
    }
}
