using System.Collections.Generic;
using System.Linq;
using System.Text;

using MassTransit;

using Messaging;

namespace UserNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            IBusControl bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.NOTIFICATION_QUEUE, e =>
                {
                    e.Consumer<OrderRegisteredConsumer>();
                });
            });

            bus.Start();
        }
    }
}
