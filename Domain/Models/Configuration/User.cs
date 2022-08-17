namespace Domain.Models.Configuration;

public record User
{
    public string Email { get; init; } = string.Empty;

    public string Login { get; init; } = string.Empty;
    
    public string Password { get; init; } = string.Empty;
    
    public string Token { get; init; } = string.Empty;
}
