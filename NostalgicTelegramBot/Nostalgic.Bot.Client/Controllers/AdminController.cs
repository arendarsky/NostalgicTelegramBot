using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nostalgic.Bot.Telegram;

namespace Nostalgic.Bot.Client.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITelegramComponent _telegramComponent;

        public AdminController(ITelegramComponent telegramComponent)
        {
            _telegramComponent = telegramComponent;
        }

        [Route("set_webhook")]
        [HttpGet]
        public async Task SetWebHook(string url = null)
        {
            url = string.IsNullOrWhiteSpace(url) ? AppHttpContext.AppBaseUrl : url;
            var webHook = $"{url}/messageksdhnd21sd/updatekjjwnjji1213dk";
            await _telegramComponent.SetWebHookAsync(webHook);
        }
    }
}