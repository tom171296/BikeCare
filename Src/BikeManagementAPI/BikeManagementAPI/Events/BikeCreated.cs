using BikeManagementAPI.Command;
using Events;
using System;

namespace BikeManagementAPI.Events
{
    public class BikeCreated : Event
    {
        public BikeCreated(Guid messageId) : base(messageId)
        {
        }
    }
}