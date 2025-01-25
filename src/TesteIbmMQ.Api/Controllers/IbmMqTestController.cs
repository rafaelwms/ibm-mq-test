using Microsoft.AspNetCore.Mvc;
using TesteIbmMQ.Domain.Enums;
using TesteIbmMQ.Domain.Services;

namespace TesteIbmMQ.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IbmMqTestController(ILogger<IbmMqTestController> logger, IQueueService queueService) : ControllerBase
    {


        /// <summary>
        /// Envia uma mensagem para a fila
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPut("put-message/{queue}/{message}")]
        public async Task<IActionResult> Put(int queue, string message)
        {
            try
            {

                var queueName = string.Empty;

                switch (queue)
                {
                    case 1:
                        queueName = QueueTypeEnum.Standard.ToString();
                        break;
                    case 2:
                        queueName = QueueTypeEnum.Retry.ToString();
                        break;
                    case 3:
                        queueName = QueueTypeEnum.DeadLetter.ToString();
                        break;
                    default:
                        return BadRequest("Fila não encontrada");
                }

                await queueService.SendMessageToQueue(queueName, message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao enviar mensagem para a fila");
                return StatusCode(500, $"Erro ao enviar mensagem para a fila. Erro: {ex}");
            }


            return Ok("Teste IBM MQ OK");
        }

        /// <summary>
        /// Envia uma mensagem para a fila
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="message"></param>
        /// <param name="retries"></param>
        /// <returns></returns>
        [HttpPut("put-message-header/{queue}/{message}/{retries}")]
        public async Task<IActionResult> PutHeader(int queue, string message, int retries)
        {
            try
            {

                var queueName = string.Empty;

                switch (queue)
                {
                    case 1:
                        queueName = QueueTypeEnum.Standard.ToString();
                        break;
                    case 2:
                        queueName = QueueTypeEnum.Retry.ToString();
                        break;
                    case 3:
                        queueName = QueueTypeEnum.DeadLetter.ToString();
                        break;
                    default:
                        return BadRequest("Fila não encontrada");
                }

                await queueService.SendMessageToQueue(queueName, message, retries, DateTime.Now.AddMinutes(5));
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
