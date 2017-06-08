namespace Messaging
{
    public interface IRegisterOrderCommand
    {
        string Username { get; set; }

        string UserMail { get; set; }

        string OrderName { get; set; }

        string DeliveryAdress { get; set; }
    }
}
