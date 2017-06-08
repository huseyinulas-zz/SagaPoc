using System;

using Messaging;

namespace SagaWorkFlow
{
    public class OrderReceivedEvent : IOrderReceivedEvent
    {
        private readonly OrderSagaState _orderSagaState;

        public OrderReceivedEvent(OrderSagaState orderSagaState)
        {
            _orderSagaState = orderSagaState;
        }

        public Guid CorrelationId
        {
            get { return _orderSagaState.CorrelationId; }
            set { CorrelationId = value; }
        }

        public string OrderName
        {
            get { return _orderSagaState.OrderName; }
            set { OrderName = value; }
        }

        public string DeliveryAdress
        {
            get { return _orderSagaState.DeliveryAdress; }
            set { DeliveryAdress = value; }
        }

        public int OrderId
        {
            get { return _orderSagaState.OrderId; }
            set { OrderId = value; }
        }

        public string Username
        {
            get { return _orderSagaState.Username; }
            set { Username = value; }
        }

        public string UserMail
        {
            get { return _orderSagaState.UserMail; }
            set { UserMail = value; }
        }

       
    }
}