using IBM.WMQ;
using IBM.WMQ.Nmqi;
using IBM.WMQ.PCF;
using Microsoft.Extensions.Logging;
using System.Collections;
using TesteIbmMQ.Domain.Entities;
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
                if (mqQueue == null)
                {
                    logger.LogInformation($"mqQueue está nulo, vamos obter para a fila {queue}");
                    mqQueue = mqQMgr.AccessQueue(settings.Queues[queue], MQC.MQOO_INPUT_SHARED | MQC.MQOO_FAIL_IF_QUIESCING | MQC.MQOO_BROWSE);
                }
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
            bool _continue = true;
            while (_continue && !stoppingToken.IsCancellationRequested)
            {
                try
                {

                    if (IsQueueEmpty())
                    {
                        logger.LogInformation($"Queue {queue} is empty.");
                        await Task.Delay(10000, stoppingToken); // Wait for some time before checking again
                        continue;
                    }

                    MQMessage mqMsg = new();
                    MQGetMessageOptions mqGetMsgOpts = new()
                    {
                        Options = MQC.MQGMO_LOCK + MQC.MQGMO_FAIL_IF_QUIESCING + MQC.MQGMO_WAIT + MQC.MQGMO_BROWSE_FIRST,
                        WaitInterval = 10000
                    };


                    mqQueue.Get(mqMsg, mqGetMsgOpts);
                    string stringMessage = mqMsg.ReadString(mqMsg.MessageLength);

                    var message = new Message(stringMessage);

                    if (!message.IsAllowedToRetry())
                    {
                        logger.LogInformation($"Message will be Readed at {message.GetTimeToRead()}");
                        continue;
                    }

                    await callBack(queue, stringMessage, stoppingToken);

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
                catch (Exception ex)
                {

                    _continue = false;
                    logger.LogError(ex, $"01-Erro ao tentar consumir item de fila! - Erro Genérico: {ex?.Message}");

                }
            }
        }

        public async Task SendMessageToQueue(string queue, string message)
        {

            InitQueueForPut(queue);
            try
            {

                MQMessage mqMsg = new();

                var msg = new Message(message);

                mqMsg.WriteString(msg.ToString());
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

        public async Task SendMessageToQueue(string queue, string message, int retryCount, DateTime readTime)
        {
            InitQueueForPut(queue);
            try
            {
                MQMessage mqMsg = new();

                var msg = new Message(message, retryCount, readTime);

                mqMsg.WriteString(msg.ToString());
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

        private bool IsQueueEmpty()
        {
            return mqQueue.CurrentDepth == 0;
        }

        private void InitQueueForPut(string queue)
        {
            if (mqQMgr != null)
            {
                if (mqQueue == null)
                {
                    logger.LogInformation($"mqQueue está nulo, vamos obter para a fila {queue}");
                    mqQueue = mqQMgr.AccessQueue(settings.Queues[queue], MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING);
                }
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
            mqQueue = mqQMgr.AccessQueue(settings.Queues[queue], MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING);
        }
    }
}
