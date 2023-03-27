namespace Contracts;

public record SendEmailRequest
{
    public string Email { get; init; } = null!;

    public string Message { get; init; } = null!;
}