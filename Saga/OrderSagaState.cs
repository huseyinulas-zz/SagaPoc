using System;

using Automatonymous;

using Messaging;

namespace Saga
{
    public class OrderSagaState : SagaStateMachineInstance
    {
        public State CurrentState { get; set; }

        public DateTime ReceivedDateTime { get; set; }

        public DateTime RegisteredDateTime { get; set; }

        public string OrderName { get; set; }

        public string DeliveryAdress { get; set; }

        public Guid CorrelationId { get; set; }
    }

    public class OrderSaga : MassTransitStateMachine<OrderSagaState>
    {
        public OrderSaga()
        {
            InstanceState(func => func.CurrentState);

            Event(() => RegisterOrder, cc =>
                                               cc.CorrelateBy(state => state.OrderName, context => context.Message.OrderName).SelectId(i => Guid.NewGuid())
                 );

            Event(() => OrderRegistered, cc =>
                                                 cc.CorrelateById(context => context.Message.CorrelationId)
                 );

            Initially(When(RegisterOrder).Then(context =>
                                               {
                                                   context.Instance.ReceivedDateTime = DateTime.Now;
                                                   context.Instance.OrderName = context.Data.OrderName;
                                               })
                                         .ThenAsync(context =>
                                                            Console.Out.WriteLineAsync($"Order for customer {context.Data.OrderName} received"))
                                         .TransitionTo(Received)
                                         .Publish(context =>
                                                          new OrderReceivedEvent(context.Instance))
                     );
        }

        public State Received { get; set; }

        public State Registered { get; set; }

        public Event<IRegisterOrderCommand> RegisterOrder { get; set; }

        public Event<IOrderRegisteredEvent> OrderRegistered { get; set; }
    }
}
