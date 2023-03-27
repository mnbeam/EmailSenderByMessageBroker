using Contracts;

namespace EmailService.Interfaces;

public interface IEmailSender
{
    Task SendAsync(SendEmailRequest sendEmailRequest);
}