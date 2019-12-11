using System;

namespace Events
{
    public class Message
    {
        private Guid messageId;

        public Message(Guid messageId)
        {
            this.messageId = messageId;
        }
    }
}