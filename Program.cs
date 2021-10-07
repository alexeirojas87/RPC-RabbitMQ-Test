using System;
using System.Threading.Tasks;

namespace RabbitMQ_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RPC Client");
            Task t = InvokeAsync();
            t.Wait();

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static async Task InvokeAsync()
        {
            var rpcClient = new ClientRPCRabbitMQWrapper("localhost");

            Console.WriteLine(" [x] Requesting");
            var response = await rpcClient.CallAsync<string>(new RPCRequest() { Class = "RabbitMQ_Server.Test", Method = "TestMethod" });
            Console.WriteLine(" [.] Got '{0}'", response);

            Console.WriteLine(" [x] Requesting");
            var responseObject = await rpcClient.CallAsync<RPCObjectReturn>(new RPCRequest() { Class = "RabbitMQ_Server.Test", Method = "TestMethodObject" });
            Console.WriteLine(" [.] Got '{0}'", (responseObject as RPCObjectReturn).MyProperty);

            rpcClient.Close();
        }
    }
}
