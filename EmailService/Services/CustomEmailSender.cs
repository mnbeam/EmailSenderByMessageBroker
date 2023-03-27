using Contracts;
using EmailService.Exceptions;
using EmailService.Interfaces;

namespace EmailService.Services;

public class CustomEmailSender : IEmailSender
{
    public async Task SendAsync(SendEmailRequest sendEmailRequest)
    {
        await Task.Delay(1000);

        throw new EmailServiceException("Unfortunaly, the service is unavailable");
    }
}