using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MiniHub.MessagePusher
{
    public class NullPusher : IMessagePusher
    {
        public void Initialise()
        {
        }

        public void PushMessage(object o)
        {
            Debug.WriteLine($"Pushing {o}");
        }
    }
}
