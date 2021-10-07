using System;

namespace RabbitMQ_Test
{
    [Serializable]
    public class RPCRequest
    {
        public string Class { get; set; }
        public object[] ParamsConstructor { get; set; }
        public string Method { get; set; }
        public object[] ParamsMethod { get; set; }
    }
}