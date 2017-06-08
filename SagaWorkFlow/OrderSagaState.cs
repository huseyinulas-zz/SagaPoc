using System;

using Automatonymous;

namespace SagaWorkFlow
{
    public class OrderSagaState : SagaStateMachineInstance
    {
        public State CurrentState { get; set; }

        public DateTime ReceivedDateTime { get; set; }

        public DateTime RegisteredDateTime { get; set; }

        public string OrderName { get; set; }

        public string DeliveryAdress { get; set; }

        public int OrderId { get; set; }

        public string Username { get; set; }

        public string UserMail { get; set; }

        public Guid CorrelationId { get; set; }
    }
}
