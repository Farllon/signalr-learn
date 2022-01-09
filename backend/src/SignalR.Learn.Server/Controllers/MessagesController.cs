using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Learn.Server.InputModels;

namespace SignalR.Learn.Server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hub;

        public MessagesController(IHubContext<SignalHub> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> SendPublicMessage(SendMessageInputModel model)
        {
            await _hub.Clients.All.SendAsync("publicMessage", model.Message);

            return Ok();
        }

        [HttpPost("{connectionId}")]
        public async Task<IActionResult> SendPrivateMessage(string connectionId, SendMessageInputModel model)
        {
            await _hub.Clients.Client(connectionId).SendAsync("privateMessage", model.Message);

            return Ok();
        }
    }
}
