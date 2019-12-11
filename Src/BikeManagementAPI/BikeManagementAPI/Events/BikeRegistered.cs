using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManagementAPI.Events
{
    public class BikeRegistered : Event
    {
        public BikeRegistered(Guid messageId) : base(messageId)
        {
        }
    }
}