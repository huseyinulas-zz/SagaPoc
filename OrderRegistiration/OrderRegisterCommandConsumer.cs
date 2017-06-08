using System;
using System.Threading.Tasks;

using MassTransit;

using Messaging;

namespace OrderRegistiration
{
    public class OrderRegisterCommandConsumer : IConsumer<IRegisterOrderCommand>
    {
        public async Task Consume(ConsumeContext<IRegisterOrderCommand> context)
        {
            var rnd = new Random();
            IRegisterOrderCommand command = context.Message;
            int id = rnd.Next(1000);

            await Console.Out.WriteLineAsync($"Order with id {id} registered!");

            //notify subscribers that a order is registered
            //var orderRegisteredEvent = new OrderRegisteredEvent(command, id);
            //await context.Publish<IOrderRegisteredEvent>(orderRegisteredEvent);
        }
    }
}
