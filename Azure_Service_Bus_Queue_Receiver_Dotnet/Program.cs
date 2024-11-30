using Microsoft.Azure.ServiceBus;

namespace Azure_Service_Bus_Queue_Receiver_Dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serviceBusConnectionString = "ConnectionString";
            const string queueName = "your-queue-name";
            var queueClient = new QueueClient(serviceBusConnectionString, queueName);
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };
            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
            Console.WriteLine("Listening for messages...");
            Console.ReadLine();
            queueClient.CloseAsync();
        }
        static Task ProcessMessagesAsync(Message message, CancellationToken cancellationToken)
        {
            Console.WriteLine("Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} " +
                "Body:{Encoding.UTF8.GetString(message.Body)}");
            return Task.CompletedTask;
        }
        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine("Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            return Task.CompletedTask;
        }
    }
}