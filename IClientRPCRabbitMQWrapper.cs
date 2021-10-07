using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ_Test
{
    public interface IClientRPCRabbitMQWrapper
    {
        public Task<object> CallAsync<T>(RPCRequest request, CancellationToken cancellationToken = default);
        public void Close();
    }
}