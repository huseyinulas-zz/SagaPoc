using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Automatonymous;

using MassTransit;
using MassTransit.Saga;

using Messaging;

namespace SagaWorkFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Saga";
            var saga = new OrderSagaStateMachine();
            var repo = new InMemorySagaRepository<OrderSagaState>();

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.SAGA_QUEUE, e =>
                {
                    e.StateMachineSaga(saga, repo);
                });
            });
            bus.Start();
            Console.WriteLine("Saga is active...");
            Console.ReadLine();
            bus.Stop();
        }
    }
}
