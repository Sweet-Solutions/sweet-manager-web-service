using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerWebService.Profiles.Application.Internal.CommandService;
using SweetManagerWebService.Profiles.Domain.Model.Queries.Provider;
using SweetManagerWebService.Profiles.Domain.Services.Provider;
using SweetManagerWebService.Profiles.Interfaces.REST.Resources.Provider;
using SweetManagerWebService.Profiles.Interfaces.REST.Transform.Provider;

namespace SweetManagerWebService.Profiles.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderCommandService _providerCommandService;
        private readonly IProviderQueryService _providerQueryService;

        public ProviderController(
            IProviderCommandService providerCommandService,
            IProviderQueryService providerQueryService)
        {
            _providerCommandService = providerCommandService;
            _providerQueryService = providerQueryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProvider([FromBody] CreateProviderResource resource)
        {
            var result = await _providerCommandService
                .Handle(CreateProviderCommandFromResourceAssembler
                    .ToCommandFromResource(resource));
            if (result is false)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider([FromBody] UpdateProviderResource resource)
        {
            var result = await _providerCommandService
                .Handle(UpdateProviderCommandFromResourceAssembler
                    .ToCommandFromResource(resource));
            if (result is false)
                return BadRequest();
            return Ok(result);
        }
        
        [HttpGet("all")]
        public async Task<IActionResult> AllProviders()
        {
            var providers = await _providerQueryService
                .Handle(new GetAllProvidersQuery());

            var providerResource = providers.Select
                (ProviderResourceFromEntityAssembler
                    .ToResourceFromEntity);

            return Ok(providerResource);
        }
    }
}
