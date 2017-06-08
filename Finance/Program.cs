using MassTransit;

using Messaging;

namespace Finance
{
    class Program
    {
        static void Main(string[] args)
        {
            IBusControl bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.FINANCE_QUEUE, e =>
                {
                    e.Consumer<OrderRegisteredConsumer>();
                });
            });

            bus.Start();
        }
    }
}
