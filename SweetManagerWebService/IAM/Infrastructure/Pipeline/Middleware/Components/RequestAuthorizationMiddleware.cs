using Microsoft.AspNetCore.Authorization;
using SweetManagerWebService.IAM.Application.Internal.OutboundServices;

namespace SweetManagerWebService.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next, ILogger<RequestAuthorizationMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, ITokenService tokenService)
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
        
        await next(context);
    }
}