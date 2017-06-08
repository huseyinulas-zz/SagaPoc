using System;

using Automatonymous;

using MassTransit;
using MassTransit.Saga;

using Messaging;

namespace Saga
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.Title = "Saga";
            //var saga = new OrderSaga();
            //var repo = new InMemorySagaRepository<OrderSagaState>();

            //IBusControl bus = BusConfigurator.ConfigureBus((cfg, host) => { cfg.ReceiveEndpoint(host, RabbitMqConstants.SAGA_QUEUE, e => { e.StateMachineSaga(saga, repo); }); });
            //bus.Start();
            //Console.WriteLine("Saga active.. Press enter to exit");
            //Console.ReadLine();
            //bus.Stop();
        }
    }
}
