using System;

using Messaging;

namespace OrderRegistiration
{
    public class OrderRegisteredEvent : IOrderRegisteredEvent
    {
        private IOrderReceivedEvent command;
        private int orderId;
        public OrderRegisteredEvent(IOrderReceivedEvent command, int orderId)
        {
            this.command = command;
            this.orderId = orderId;
        }

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public string Username
        {
            get { return command.Username; }
            set { Username = value; }
        }

        public string UserMail
        {
            get { return command.UserMail; }
            set { UserMail = value; }
        }

        public string OrderName
        {
            get { return command.OrderName; }
            set { OrderName = value; }
        }

        public string DeliveryAdress
        {
            get { return command.DeliveryAdress; }
            set { DeliveryAdress = value; }
        }

        public Guid CorrelationId
        {
            get { return command.CorrelationId; }
            set { CorrelationId = value; }
        }

        public string OrderCapturedIp
        {
            get { return "127.0.0.1"; }
            set { value = "127.0.0.1"; }
        }
    }
}