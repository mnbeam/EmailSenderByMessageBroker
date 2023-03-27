using Contracts;
using EmailService.Exceptions;
using EmailService.Interfaces;
using MassTransit;

namespace EmailService.Consumers;

public class SendEmailConsumer : IConsumer<SendEmailRequest>
{
    private readonly IEmailSender _emailSender;

    public SendEmailConsumer(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task Consume(ConsumeContext<SendEmailRequest> context)
    {
        try
        {
            await _emailSender.SendAsync(context.Message);

            await context.RespondAsync(new SendEmailResponse
            {
                IsSucceed = true,
                ErrorMessage = null
            });
        }
        catch (EmailServiceException exception)
        {
            await context.RespondAsync(new SendEmailResponse
            {
                IsSucceed = false,
                ErrorMessage = exception.Message
            });
        }
    }
}