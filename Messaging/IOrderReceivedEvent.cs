using System;

namespace Messaging
{
    public interface IOrderReceivedEvent
    {
        Guid CorrelationId { get; set; }

        string OrderName { get; set; }

        string DeliveryAdress { get; set; }

        int OrderId { get; set; }

        string Username { get; set; }

        string UserMail { get; set; }
    }
}