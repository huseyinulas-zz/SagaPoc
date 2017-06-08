using System;
using System.Threading.Tasks;

using MassTransit;

using Messaging;

namespace OrderCapture
{
    public class OrderCaptureCommandConsumer:IConsumer<IOrderCaptureCommand>
    {
        public async Task Consume(ConsumeContext<IOrderCaptureCommand> context)
        {
            IOrderCaptureCommand orderCaptureCommand = context.Message;
           
            await Console.Out.WriteLineAsync($"Order Captured From : {orderCaptureCommand.OrderCapturedIp}");
        }
    }
}