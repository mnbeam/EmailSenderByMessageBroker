namespace Contracts;

public class SendEmailResponse
{
    public bool IsSucceed { get; init; }

    public string? ErrorMessage { get; init; }
}