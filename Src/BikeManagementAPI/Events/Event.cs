using System;

namespace Events
{
    public class Event : Message
    {
        public Event(Guid messageId) : base(messageId)
        {
        }
    }
}