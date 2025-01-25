using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using IBM.XMS;
using Microsoft.Extensions.Configuration;

namespace IbmMqConsoleApp
{
    class Program
    {
        private static IConfiguration _configuration;

        static async Task Main(string[] args)
        {
            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();

            Console.WriteLine("IBM MQ Console App");
            Console.WriteLine("1. Send Message");
            Console.WriteLine("2. Receive Message");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await SendMessageAsync("Hello, IBM MQ!");
                    break;
                case "2":
                    await ReceiveMessageAsync();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private static async Task SendMessageAsync(string message)
        {
            var queueSettings = _configuration.GetSection("QueueSettings");
            var factoryFactory = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
            var connectionFactory = factoryFactory.CreateConnectionFactory();

            connectionFactory.SetStringProperty(XMSC.WMQ_HOST_NAME, queueSettings["Host"]);
            connectionFactory.SetIntProperty(XMSC.WMQ_PORT, int.Parse(queueSettings["Port"]));
            connectionFactory.SetStringProperty(XMSC.WMQ_CHANNEL, queueSettings["Channel"]);
            connectionFactory.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
            connectionFactory.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, queueSettings["QueueManagerName"]);
            connectionFactory.SetStringProperty(XMSC.USERID, queueSettings["Username"]);
            connectionFactory.SetStringProperty(XMSC.PASSWORD, queueSettings["Password"]);

            using var connection = connectionFactory.CreateConnection();
            using var session = connection.CreateSession(false, AcknowledgeMode.AutoAcknowledge);
            var destination = session.CreateQueue(queueSettings.GetSection("Queues")["Standard"]);
            using var producer = session.CreateProducer(destination);

            var textMessage = session.CreateTextMessage(message);
            producer.Send(textMessage);

            Console.WriteLine("Message sent successfully.");
        }

        private static async Task ReceiveMessageAsync()
        {
            var queueSettings = _configuration.GetSection("QueueSettings");
            var factoryFactory = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
            var connectionFactory = factoryFactory.CreateConnectionFactory();

            connectionFactory.SetStringProperty(XMSC.WMQ_HOST_NAME, queueSettings["Host"]);
            connectionFactory.SetIntProperty(XMSC.WMQ_PORT, int.Parse(queueSettings["Port"]));
            connectionFactory.SetStringProperty(XMSC.WMQ_CHANNEL, queueSettings["Channel"]);
            connectionFactory.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
            connectionFactory.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, queueSettings["QueueManagerName"]);
            connectionFactory.SetStringProperty(XMSC.USERID, queueSettings["Username"]);
            connectionFactory.SetStringProperty(XMSC.PASSWORD, queueSettings["Password"]);

            using var connection = connectionFactory.CreateConnection();
            using var session = connection.CreateSession(false, AcknowledgeMode.AutoAcknowledge);
            var destination = session.CreateQueue(queueSettings.GetSection("Queues")["Standard"]);
            using var consumer = session.CreateConsumer(destination);

            connection.Start();
            var message = consumer.Receive(10000) as ITextMessage;

            if (message != null)
            {
                Console.WriteLine($"Received message: {message.Text}");
            }
            else
            {
                Console.WriteLine("No message received.");
            }
        }
    }
}
