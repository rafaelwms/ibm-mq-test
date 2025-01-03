using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesteIbmMQ.CrossCutting.Extensions;

namespace TesteIbmMQ.Worker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables()
                                .Build();
            return Host.CreateDefaultBuilder(args)
                 .ConfigureWorkerHealthCheck(configuration)
                 .ConfigureServices((hostingContext, services) =>
                 {
                     services.AddLogging();
                     services.AddHealthChecks();
                     services.AddCustomSettings(configuration);
                     services.AddCustomServices(configuration);
                     services.AddRepository(configuration);
                     services.AddFilaTesteMediator();
                     services.AddHttpContextAccessor();
                     services.AddHostedService<ConsumerService>();
                 });
        }
    }
}

/*

// ===========================================================================
// Licensed Materials - Property of IBM
// 5724-H72
// (c) Copyright IBM Corp. 2003, 2024
// ===========================================================================
using System;
using System.Collections;

using IBM.WMQ;

class MQSample
{
    // The type of connection to use, this can be:-
    // MQC.TRANSPORT_MQSERIES_BINDINGS for a server connection.
    // MQC.TRANSPORT_MQSERIES_CLIENT for a non-XA client connection
    // MQC.TRANSPORT_MQSERIES_XACLIENT for an XA client connection
    // MQC.TRANSPORT_MQSERIES_MANAGED for a managed client connection
    const String connectionType = MQC.TRANSPORT_MQSERIES_MANAGED;

    // Define the name of the queue manager to use (applies to all connections)
    const String qManager = "QM1";

    // Define the name of your host connection (applies to client connections only)
    const String hostName = "localhost";

    // Define the name of the channel to use (applies to client connections only)
    const String channel = "DEV.APP.SVRCONN";
    const String user = "app";
    const String port = "1414";
    const String password = "passw0rd";



    /// <summary>
    /// Initialise the connection properties for the connection type requested
    /// </summary>
    /// <param name="connectionType">One of the MQC.TRANSPORT_MQSERIES_ values</param>
    static Hashtable init(String connectionType)
    {
        Hashtable connectionProperties = new Hashtable();

        // Add the connection type
        connectionProperties.Add(MQC.TRANSPORT_PROPERTY, connectionType);

        // Set up the rest of the connection properties, based on the
        // connection type requested
        switch (connectionType)
        {
            case MQC.TRANSPORT_MQSERIES_BINDINGS:
                break;
            case MQC.TRANSPORT_MQSERIES_CLIENT:
            case MQC.TRANSPORT_MQSERIES_XACLIENT:
            case MQC.TRANSPORT_MQSERIES_MANAGED:
                connectionProperties.Add(MQC.HOST_NAME_PROPERTY, hostName);
                connectionProperties.Add(MQC.CHANNEL_PROPERTY, channel);

                connectionProperties.Add(MQC.PORT_PROPERTY, port);
                connectionProperties.Add(MQC.USER_ID_PROPERTY, user);
                connectionProperties.Add(MQC.PASSWORD_PROPERTY, password);
                break;
        }

        return connectionProperties;
    }
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static int Main(string[] args)
    {
        try
        {
            Hashtable connectionProperties = init(connectionType);

            // Create a connection to the queue manager using the connection
            // properties just defined
            MQQueueManager qMgr = new MQQueueManager(qManager, connectionProperties);

            // Set up the options on the queue we want to open
            int openOptions = MQC.MQOO_INPUT_AS_Q_DEF | MQC.MQOO_OUTPUT;

            // Now specify the queue that we want to open,and the open options
            MQQueue system_default_local_queue =
              qMgr.AccessQueue("QL.EXAMPLE", openOptions);

            // Define an IBM MQ message, writing some text in UTF format
            MQMessage hello_world = new MQMessage();
            hello_world.WriteUTF("Hello World!");

            // Specify the message options
            MQPutMessageOptions pmo = new MQPutMessageOptions(); // accept the defaults,
                                                                 // same as MQPMO_DEFAULT

            // Put the message on the queue
            system_default_local_queue.Put(hello_world, pmo);



            // Get the message back again

            // First define an IBM MQ message buffer to receive the message
            MQMessage retrievedMessage = new MQMessage();
            retrievedMessage.MessageId = hello_world.MessageId;

            // Set the get message options
            MQGetMessageOptions gmo = new MQGetMessageOptions(); //accept the defaults
                                                                 //same as MQGMO_DEFAULT

            // Get the message off the queue
            system_default_local_queue.Get(retrievedMessage, gmo);

            // Prove we have the message by displaying the UTF message text
            String msgText = retrievedMessage.ReadUTF();
            Console.WriteLine("The message is: {0}", msgText);

            // Close the queue
            system_default_local_queue.Close();

            // Disconnect from the queue manager
            qMgr.Disconnect();
        }

        //If an error has occurred,try to identify what went wrong.

        //Was it an IBM MQ error?
        catch (MQException ex)
        {
            Console.WriteLine("An IBM MQ error occurred: {0}", ex.ToString());
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("A System error occurred: {0}", ex.ToString());
        }

        return 0;
    }//end of start
}//end of sample

*/