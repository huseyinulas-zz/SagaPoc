using System;
using System.Threading.Tasks;

using MassTransit;

using Messaging;

namespace Finance
{
    public class OrderRegisteredConsumer : IConsumer<IOrderRegisteredEvent>
    {
        public async Task Consume(ConsumeContext<IOrderRegisteredEvent> context)
        {
            IOrderRegisteredEvent message = context.Message;

            await Console.Out.WriteLineAsync($"Finance Proccess with order {message.OrderId}");
        }
    }
}