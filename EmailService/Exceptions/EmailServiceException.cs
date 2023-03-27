namespace EmailService.Exceptions;

public class EmailServiceException : Exception
{
    public EmailServiceException(string message) : base(message)
    {
    }
}