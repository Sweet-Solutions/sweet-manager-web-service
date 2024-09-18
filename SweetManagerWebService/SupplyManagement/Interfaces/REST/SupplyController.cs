using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerWebService.SupplyManagement.Domain.Model.Queries;
using SweetManagerWebService.SupplyManagement.Domain.Services;
using SweetManagerWebService.SupplyManagement.Interfaces.REST.Resources;
using SweetManagerWebService.SupplyManagement.Interfaces.REST.Transform;

namespace SweetManagerWebService.SupplyManagement.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class SupplyController : ControllerBase
    {
        private readonly ISupplyQueryService _queryService;
        private readonly ISupplyCommandService _commandService;

        public SupplyController(ISupplyQueryService queryService, ISupplyCommandService commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupply([FromBody] CreateSupplyResource resource)
        {
            try
            {
                var result = await _commandService.Handle(CreateSupplyCommandFromResourceAssembler.ToCommandFromResource(resource));
                if (!result)
                {
                    return BadRequest("Failed to create supply.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupply(int id, [FromBody] UpdateSupplyResource resource)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSupply([FromBody] DeleteSupplyResource resource)
        {
            try
            {
                var result = await _commandService.Handle(DeleteSupplyCommandFromResourceAssembler.ToCommandFromResource(resource));
                if (!result)
                {
                    return BadRequest("Failed to delete supply.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplyById([FromRoute] int id)
        {
            try
            {
                var result = await _queryService.Handle(new GetSupplyByIdQuery(id));
                if (result == null)
                {
                    return NotFound($"Supply with ID {id} not found.");
                }

                var supplyResource = SupplyResourceFromEntityAssembler.ToResourceFromEntity(result);

                return Ok(supplyResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSupplies()
        {
            try
            {
                var result = await _queryService.Handle(new GetAllSuppliesQuery());

                var supplyResource = result.Select(SupplyResourceFromEntityAssembler.ToResourceFromEntity);

                return Ok(supplyResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("provider/{providerId}")]

        public async Task<IActionResult> GetSupplyByProviderId([FromRoute] int providerId)
        {
            try
            {
                var result = await _queryService.Handle(new GetSupplyByProviderIdQuery(providerId));
                if (result == null)
                {
                    return NotFound($"Supply with Provider ID {providerId} not found.");
                }

                var supplyResource = result.Select(SupplyResourceFromEntityAssembler.ToResourceFromEntity);

                return Ok(supplyResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
