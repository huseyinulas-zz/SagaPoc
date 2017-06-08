using System;
using System.Threading.Tasks;

using MassTransit;

using Messaging;

namespace OrderRegistiration
{
    public class OrderReceivedConsumer : IConsumer<IOrderReceivedEvent>
    {
        public async Task Consume(ConsumeContext<IOrderReceivedEvent> context)
        {
            var id = 12;
            IOrderReceivedEvent command = context.Message;
            await Console.Out.WriteLineAsync($"Order with id {id} registered @ {DateTime.Now} / {command.CorrelationId}");


            var orderRegisteredEvent = new OrderRegisteredEvent(command, id);
            await context.Publish<IOrderRegisteredEvent>(orderRegisteredEvent);
        }
    }
}