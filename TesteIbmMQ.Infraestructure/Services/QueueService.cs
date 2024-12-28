using IBM.WMQ;
using Microsoft.Extensions.Logging;
using System.Collections;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;

namespace TesteIbmMQ.Infraestructure.Services
{
    public class QueueService(QueueSettings settings, ILogger<QueueService> logger) : IQueueService
    {
        private MQQueueManager mqQMgr;
        private MQQueue mqQueue;

        private void InitQueue(string queue)
        {
            if (mqQMgr != null)
            {
                return;
            }
            Hashtable props = new()
                {
                    { MQC.HOST_NAME_PROPERTY, settings.Host },
                    { MQC.CHANNEL_PROPERTY, settings.Channel },
                    { MQC.PORT_PROPERTY, settings.Port },
                    { MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED },
                    { MQC.USER_ID_PROPERTY, settings.Username },
                { MQC.PASSWORD_PROPERTY, settings.Password }
                };
            logger.LogInformation("Connecting to " + settings.QueueManagerName);
            mqQMgr = new MQQueueManager(settings.QueueManagerName, props);
            mqQueue = mqQMgr.AccessQueue(settings.Queues[queue], MQC.MQOO_INPUT_SHARED | MQC.MQOO_FAIL_IF_QUIESCING | MQC.MQOO_BROWSE);
        }

        public async Task StartQueueProcessor(Func<string, string, CancellationToken, Task> callBack, string queue, CancellationToken stoppingToken)
        {
            InitQueue(queue);
            if (mqQueue == null)
            {
                logger.LogInformation($"mqQueue está nulo, vamos obter para a fila {queue}");
                mqQueue = mqQMgr.AccessQueue(settings.Queues[queue], MQC.MQOO_INPUT_SHARED | MQC.MQOO_FAIL_IF_QUIESCING | MQC.MQOO_BROWSE);
            }

            bool _continue = true;
            while (_continue && !stoppingToken.IsCancellationRequested)
            {
                try
                {
                    MQMessage mqMsg = new();
                    MQGetMessageOptions mqGetMsgOpts = new()
                    {
                        Options = MQC.MQGMO_LOCK + MQC.MQGMO_FAIL_IF_QUIESCING + MQC.MQGMO_WAIT + MQC.MQGMO_BROWSE_FIRST,
                        WaitInterval = 10000
                    };

                    mqQueue.Get(mqMsg, mqGetMsgOpts);
                    string message = mqMsg.ReadString(mqMsg.MessageLength);

                    await callBack(queue, message, stoppingToken);

                    mqGetMsgOpts.Options = MQC.MQGMO_MSG_UNDER_CURSOR;
                    mqQueue.Get(mqMsg, mqGetMsgOpts);
                }
                catch (MQException mqe)
                {
                    if (mqe?.Reason != MQC.MQRC_NO_MSG_AVAILABLE)
                    {
                        _continue = false;
                        logger.LogError(mqe, $"01-Erro ao tentar consumir item de fila! - Código de Erro IBMMQ: {mqe?.Reason}");
                    }
                }
            }
        }

        public async Task SendMessageToQueue(string queue, string message)
        {

            InitQueue(queue);
            try
            {

                MQMessage mqMsg = new();
                mqMsg.WriteString(message);
                mqMsg.Format = MQC.MQFMT_STRING;
                MQPutMessageOptions mqPutMsgOpts = new();
                mqQueue.Put(mqMsg, mqPutMsgOpts);
                Console.WriteLine(message + " enviada");

                mqQueue?.Close();
                mqQMgr?.Disconnect();
            }
            catch (MQException e)
            {
                Console.Write(e);
                Console.Write(e.Message);
                Console.Write(e.Reason);
                Console.Write(e.StackTrace);
            }
        }
    }
}
