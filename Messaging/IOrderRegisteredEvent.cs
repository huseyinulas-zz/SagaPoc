using System;

namespace Messaging
{
    public interface IOrderRegisteredEvent : IOrderCaptureCommand
    {
        int OrderId { get; set; }

        string Username { get; set; }

        string UserMail { get; set; }

        string OrderName { get; set; }

        string DeliveryAdress { get; set; }

        Guid CorrelationId { get; set; }
    }
}