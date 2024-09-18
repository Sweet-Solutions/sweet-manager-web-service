using SweetManagerWebService.IAM.Application.Internal.OutboundServices;
using SweetManagerWebService.IAM.Domain.Model.Queries;
using SweetManagerWebService.IAM.Domain.Services.Users.Admin;
using SweetManagerWebService.IAM.Domain.Services.Users.Owner;
using SweetManagerWebService.IAM.Domain.Services.Users.Worker;
using SweetManagerWebService.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace SweetManagerWebService.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next, ILogger<RequestAuthorizationMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, ITokenService tokenService, IAdminQueryService adminQueryService,
        IWorkerQueryService workerQueryService, IOwnerQueryService ownerQueryService)
    {
        var endpoint = context.Request.HttpContext.GetEndpoint();
        
        var allowAnonymous =
            context.Request.HttpContext.GetEndpoint()!.Metadata.Any(m =>
                m.GetType() == typeof(AllowAnonymousAttribute));
        
        logger.LogInformation($"Endpoint: {endpoint?.DisplayName}, AllowAnonymous: {allowAnonymous}");

        if (allowAnonymous)
        {
            await next(context);

            return;
        }
        
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var tokenResult = tokenService.ValidateToken(token) ?? throw new Exception("Invalid Token!");

        dynamic? validation = null;
        
        // Only if I have more than 1 Aggregate 
        if (tokenResult.Role == "ROLE_ADMIN")
            validation = await adminQueryService.Handle(new GetUserByIdQuery(tokenResult.Id));
        
        else if (tokenResult.Role == "ROLE_WORKER")
            validation = await workerQueryService.Handle(new GetUserByIdQuery(tokenResult.Id));
        
        else if (tokenResult.Role == "ROLE_OWNER")
            validation = await ownerQueryService.Handle(new GetUserByIdQuery(tokenResult.Id));
        
        if (validation is null)
            throw new Exception("Invalid credentials!");

        context.Items["Credentials"] = tokenResult;
        
        await next(context);
    }
}