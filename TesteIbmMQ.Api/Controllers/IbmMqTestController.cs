using Microsoft.AspNetCore.Mvc;
using TesteIbmMQ.Domain.Services;

namespace TesteIbmMQ.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IbmMqTestController(ILogger<IbmMqTestController> logger, IQueueService queueService) : ControllerBase
    {

        [HttpPut("put-message/{queue}/{message}")]
        public async Task<IActionResult> Put(string queue, string message)
        {
            try
            {
                await queueService.SendMessageToQueue(queue, message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao enviar mensagem para a fila");
                return StatusCode(500, $"Erro ao enviar mensagem para a fila. Erro: {ex}");
            }


            return Ok("Teste IBM MQ OK");
        }
    }
}
