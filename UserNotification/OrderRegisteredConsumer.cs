using System;
using System.Threading.Tasks;

using MassTransit;

using Messaging;

namespace UserNotification
{
    public class OrderRegisteredConsumer:IConsumer<IOrderRegisteredEvent>
    {
        public async Task Consume(ConsumeContext<IOrderRegisteredEvent> context)
        {
            IOrderRegisteredEvent message = context.Message;

            await Console.Out.WriteLineAsync($"Customer Notification Sent : {message.UserMail} with order {message.OrderId}");
        }
    }
}