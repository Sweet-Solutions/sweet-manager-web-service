using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SweetManagerWebService.IAM.Application.Internal.OutboundServices;
using SweetManagerWebService.IAM.Infrastructure.Tokens.JWT.Configuration;

namespace SweetManagerWebService.IAM.Infrastructure.Tokens.JWT.Services;

public class TokenService(IOptions<TokenSettings> tokenSettings) : ITokenService
{
    private readonly TokenSettings _tokenSettings = tokenSettings.Value;
    
    public string GenerateToken(dynamic user)
    {
        SymmetricSecurityKey securityKey = new(Encoding.ASCII.GetBytes(_tokenSettings.SecretKey));

        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        string validationHotel = user.Hotel.ToString();
        
        if (string.IsNullOrEmpty(user.Hotel.ToString()))
        {
            validationHotel = string.Empty;
        }
        
        Claim[]? claims =
        [
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim(ClaimTypes.Hash, user.PasswordHash),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Locality, validationHotel)
        ];

        JwtSecurityToken token = new(
            issuer: _tokenSettings.Issuer,
            audience: _tokenSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_tokenSettings.ExpirationInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public dynamic? ValidateToken(string? token)
    {
        if (string.IsNullOrEmpty(token))
            return null;

        try
        {
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_tokenSettings.SecretKey));
            
            JwtSecurityTokenHandler tokenHandler = new();

            TokenValidationParameters validationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _tokenSettings.Issuer,
                ValidAudience = _tokenSettings.Audience,
                IssuerSigningKey = securityKey,
                LifetimeValidator = LifetimeValidator,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);

            if (securityToken is JwtSecurityToken jwtToken)
                if (!jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase))
                    return null;

            var result = (JwtSecurityToken)securityToken;

            var id = Convert.ToInt32(result.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);

            var code = Convert.ToString(result.Claims.First(claim => claim.Type == ClaimTypes.Hash).Value);

            var role = Convert.ToString(result.Claims.First(claim =>claim.Type ==  ClaimTypes.Role).Value);

            var hotel = Convert.ToString(result.Claims.First(claim => claim.Type == ClaimTypes.Locality).Value);
            
            return new { Id = id, Code = code , Role = role , Hotel = hotel };
        }
        catch (Exception)
        {
            return null;
        }
    }
    
    private static bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, 
        TokenValidationParameters validationParameters)
    {
        if (expires is null) return false;
        
        return DateTime.Now < expires;
    }
}