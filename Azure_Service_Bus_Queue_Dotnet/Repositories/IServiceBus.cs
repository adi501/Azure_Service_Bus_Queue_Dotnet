using Azure_Service_Bus_Queue_Dotnet.Models;

namespace Azure_Service_Bus_Queue_Dotnet.Repositories
{
    public interface IServiceBus
    {
        Task SendMessageAsync(CarDetails carDetails);
    }
}
