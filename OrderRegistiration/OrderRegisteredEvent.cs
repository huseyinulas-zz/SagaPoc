using System;

using Messaging;

namespace OrderRegistiration
{
    public class OrderRegisteredEvent : IOrderRegisteredEvent
    {
        private IRegisterOrderCommand command;
        private int orderId;
        public OrderRegisteredEvent(IRegisterOrderCommand command, int orderId)
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
            set { command.Username = value; }
        }

        public string UserMail
        {
            get { return command.UserMail; }
            set { command.UserMail = value; }
        }

        public string OrderName
        {
            get { return command.OrderName; }
            set { command.OrderName = value; }
        }

        public string DeliveryAdress
        {
            get { return command.DeliveryAdress; }
            set { command.DeliveryAdress = value; }
        }

        public Guid CorrelationId { get; set; }

        public string OrderCapturedIp
        {
            get { return "127.0.0.1"; }
            set { value = "127.0.0.1"; }
        }
    }
}