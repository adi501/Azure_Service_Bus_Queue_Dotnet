using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure_Service_Bus_Queue_Trigger
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([ServiceBusTrigger("jdlearningqueue", Connection = "ServiceBusConnectionString")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
