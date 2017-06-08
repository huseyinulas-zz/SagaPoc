using MassTransit.RabbitMqTransport.Transport;

namespace Messaging
{
    public class RabbitMqConstants
    {
        public const string HOSTNAME = "rabbitmq://localhost/";

        public const string USERNAME = "guest";

        public const string PASSWORD = "guest";

        public const string REGISTER_ORDER_QUEUE = "registerorder.service";

        public const string FINANCE_QUEUE = "finance.service";

        public const string NOTIFICATION_QUEUE = "notification.service";

        public const string ORDER_CAPTURE = "order.capture";

        public const string SAGA_QUEUE = "saga.service";
    }
}
