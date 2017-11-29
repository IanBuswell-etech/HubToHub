namespace MiniHub.MessagePusher
{
    public interface IMessagePusher
    {
        void Initialise();

        void PushMessage(object o);
    }
}