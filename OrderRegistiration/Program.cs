using System;

using MassTransit;

using Messaging;

namespace OrderRegistiration
{
    class Program
    {
        static  void Main(string[] args)
        {
            IBusControl bus = BusConfigurator.ConfigureBus((cfg, host) =>
                                                           {
                                                               cfg.ReceiveEndpoint(host, RabbitMqConstants.REGISTER_ORDER_QUEUE, e =>
                                                                                                                                 {
                                                                                                                                     e.Consumer<OrderReceivedConsumer>();
                                                                                                                                 });
                                                           });

            bus.Start();
            
        }
    }
}
