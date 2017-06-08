using System;

using GreenPipes;

using MassTransit;

using Messaging;

namespace OrderCapture
{
    class Program
    {
        static void Main(string[] args)
        {
            IBusControl bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.ORDER_CAPTURE, e =>
                {
                    e.UseRetry(Retry.Except<ArgumentException>().Immediate(5));
                    e.Consumer<OrderCaptureCommandConsumer>();
                });
            });
            
            bus.Start();
        }
    }
}
