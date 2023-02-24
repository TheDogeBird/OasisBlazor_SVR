using Microsoft.IdentityModel.Tokens;

public class JwtIssuerOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public int ValidFor { get; set; }
    public DateTime IssuedAt => DateTime.UtcNow;
    public DateTime ExpiresAt => IssuedAt.Add(TimeSpan.FromMinutes(ValidFor));
    public SigningCredentials SigningCredentials { get; set; }
}
