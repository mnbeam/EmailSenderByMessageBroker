using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IRequestClient<SendEmailRequest> _client;

    public EmailController(IRequestClient<SendEmailRequest> client)
    {
        _client = client;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] SendEmailRequest request)
    {
        var response = await _client.GetResponse<SendEmailResponse>(new SendEmailRequest
        {
            Email = request.Email,
            Message = request.Message
        });

        return response.Message.IsSucceed ? Ok() : BadRequest(response.Message.ErrorMessage);
    }
}