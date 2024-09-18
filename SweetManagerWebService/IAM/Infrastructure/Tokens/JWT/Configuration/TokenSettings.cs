namespace SweetManagerWebService.IAM.Infrastructure.Tokens.JWT.Configuration;

public class TokenSettings
{
    public string SecretKey { get; set; }
    
    public string Audience { get; set; }
    
    public string Issuer { get; set;  }
    
    public int ExpirationInMinutes { get; set; }

    public TokenSettings()
    {
        SecretKey = string.Empty;
        Audience = string.Empty;
        Issuer = string.Empty;
        ExpirationInMinutes = 0;
    }
}