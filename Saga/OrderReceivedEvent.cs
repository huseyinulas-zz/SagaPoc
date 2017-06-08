using System;

using Messaging;

namespace Saga
{
    public class OrderReceivedEvent : IOrderReceivedEvent
    {
        private readonly OrderSagaState _orderSagaState;

        public OrderReceivedEvent(OrderSagaState orderSagaState)
        {
            _orderSagaState = orderSagaState;
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

        public Guid CorrelationId
        {
            get { return _orderSagaState.CorrelationId; }
            set { CorrelationId = value; }
        }
    }
}