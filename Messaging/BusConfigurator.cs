using System;

using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Messaging
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction=null )
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
                                                   {
                                                       IRabbitMqHost host = cfg.Host(new Uri(RabbitMqConstants.HOSTNAME), hst =>
                                                                                                                          {
                                                                                                                              hst.Username(RabbitMqConstants.USERNAME);
                                                                                                                              hst.Password(RabbitMqConstants.PASSWORD);
                                                                                                                          });
                                                       registrationAction?.Invoke(cfg,host);
                                                   });

         
        }
    }
}