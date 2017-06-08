using System;
using System.Threading.Tasks;
using System.Web.Mvc;

using MassTransit;

using Messaging;

namespace EventSourcing.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View(new PurchaseViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(PurchaseViewModel pvm)
        {
            IBusControl bus = BusConfigurator.ConfigureBus();

            ISendEndpoint endPoint = await bus.GetSendEndpoint(new Uri(RabbitMqConstants.HOSTNAME + RabbitMqConstants.SAGA_QUEUE));

            await endPoint.Send<IRegisterOrderCommand>(new
                                                       {
                                                           Username = pvm.Username,
                                                           DeliveryAdress = pvm.DeliveryAdress,
                                                           UserMail = pvm.UserMail,
                                                           OrderName = pvm.OrderName
                                                       });



            return View(pvm);
        }
    }

    public class MyMessage
    {
        public string Value { get; set; }
    }
}
