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
public class SuppliesRequestController : ControllerBase
{

    ISuppliesRequestQueryService _queryService;
    ISuppliesRequestCommandService _commandService;

    public SuppliesRequestController(ISuppliesRequestQueryService queryService,
        ISuppliesRequestCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSuppliesRequest([FromBody] CreateSuppliesRequestResource resource)
    {
        var result =
            await _commandService.Handle(
                CreateSuppliesRequestCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSupplies()
    {
        var result = await _queryService.Handle(new GetAllSuppliesRequestQuery());
        
        var supplyResource = result.Select(SuppliesRequestResourceFromEntityAssembler.ToResourceFromEntity).ToList();

        return Ok(supplyResource);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSuppliesRequestById([FromRoute] int id)
    {
        var result = await _queryService.Handle(new GetSuppliesRequestByIdQuery(id));
        if (result is null)
        {
            return BadRequest();
        }
        
        var suppliesRequestResource = SuppliesRequestResourceFromEntityAssembler.ToResourceFromEntity(result);

        return Ok(suppliesRequestResource);

    }
    
    [HttpGet("{paymentOwnerId}")]
    public async Task<IActionResult> GetSuppliesRequestByPaymentOwnerId([FromRoute] int paymentOwnerId)
    {
        var result = await _queryService.Handle(new GetSuppliesRequestByPaymentOwnerIdQuery(paymentOwnerId));
        if (result is null)
        {
            return BadRequest();
        }
        
        var suppliesRequestResource = SuppliesRequestResourceFromEntityAssembler.ToResourceFromEntity(result);

        return Ok(suppliesRequestResource);

    }
    
    [HttpGet("{supplyId}")]
    public async Task<IActionResult> GetSuppliesRequestBySupplyId([FromRoute] int supplyId)
    {
        var result = await _queryService.Handle(new GetSuppliesRequestBySupplyIdQuery(supplyId));
        if (result is null)
        {
            return BadRequest();
        }
        
        var suppliesRequestResource = SuppliesRequestResourceFromEntityAssembler.ToResourceFromEntity(result);

        return Ok(suppliesRequestResource);

    }
} 
    
    
