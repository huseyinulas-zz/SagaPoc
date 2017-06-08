using System;

using Automatonymous;

using Messaging;

namespace SagaWorkFlow
{
    public class OrderSagaStateMachine : MassTransitStateMachine<OrderSagaState>
    {
        public OrderSagaStateMachine()
        {
            InstanceState(func => func.CurrentState);

            Event(() => RegisterOrder, cc => cc.CorrelateBy(state => state.OrderName, context => context.Message.OrderName).SelectId(i => Guid.NewGuid()));
            Event(() => OrderRegistered, cc => cc.CorrelateById(context => context.Message.CorrelationId));

            Initially(When(RegisterOrder).Then(context =>
                                               {
                                                   context.Instance.ReceivedDateTime = DateTime.Now;
                                                   context.Instance.OrderName = context.Data.OrderName;
                                                   context.Instance.DeliveryAdress = context.Data.DeliveryAdress;
                                                   context.Instance.UserMail = context.Data.UserMail;
                                                   context.Instance.Username = context.Data.Username;
                                               })
                                         .ThenAsync(context => Console.Out.WriteLineAsync($"Order for customer {context.Instance.OrderName} received @ {DateTime.Now} / {context.Instance.CorrelationId}"))
                                         .TransitionTo(Received)
                                         .Publish(context => new OrderReceivedEvent(context.Instance))
                     );
            During(Received,
                   When(OrderRegistered)
                       .Then(context => context.Instance.RegisteredDateTime = DateTime.Now)
                       .ThenAsync(context => Console.Out.WriteLineAsync($"Order for customer {context.Instance.OrderName} registered @ {DateTime.Now} / {context.Instance.CorrelationId}"))
                       .Finalize()
                  );

            SetCompletedWhenFinalized();
        }

        public State Received { get; set; }

        public State Registered { get; set; }

        public Event<IRegisterOrderCommand> RegisterOrder { get; set; }

        public Event<IOrderRegisteredEvent> OrderRegistered { get; set; }
    }
}
