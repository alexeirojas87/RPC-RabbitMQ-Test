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

            Console.WriteLine(" [x] Requesting TestMethod");
            var response = await rpcClient.CallAsync<string>(new RPCRequest() { Class = "RabbitMQ_Server.Test", Method = "TestMethod" });
            Console.WriteLine(" [.] Got '{0}'", response);

            Console.WriteLine(" [x] Requesting TestMethodObject");
            var responseObject = await rpcClient.CallAsync<RPCObjectReturn>(new RPCRequest() { Class = "RabbitMQ_Server.Test", Method = "TestMethodObject" });
            Console.WriteLine(" [.] Got '{0}'", (responseObject as RPCObjectReturn).MyProperty);

            Console.WriteLine(" [x] Requesting TestMethodObjectwithParam");
            var responseObjectWP = await rpcClient.CallAsync<RPCObjectReturn>(new RPCRequest() { Class = "RabbitMQ_Server.Test", Method = "TestMethodObjectwithParam", ParamsMethod = new object[] { 2 } });
            Console.WriteLine(" [.] Got '{0}'", (responseObjectWP as RPCObjectReturn).MyProperty);

            Console.WriteLine(" [x] Requesting TestMethodObjectwithParamAndConstructorParam");
            var responseObjectCWP = await rpcClient.CallAsync<RPCObjectReturn>(new RPCRequest() { Class = "RabbitMQ_Server.Test", Method = "TestMethodObjectwithParam", ParamsMethod = new object[] { 3 }, ParamsConstructor = new object[] { 3 } });
            Console.WriteLine(" [.] Got '{0}'", (responseObjectCWP as RPCObjectReturn).MyProperty);

            rpcClient.Close();
        }
    }
}
