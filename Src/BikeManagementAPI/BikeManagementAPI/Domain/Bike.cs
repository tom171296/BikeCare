using BikeManagementAPI.Command;
using BikeManagementAPI.Domain.Core;
using BikeManagementAPI.Domain.ValueObjects;
using BikeManagementAPI.Events;
using BikeManagementAPI.Mappers;
using System;

namespace BikeManagementAPI.Domain
{
    public class Bike : AggregateRoot<BikeId>
    {
        public Bike() : base(new BikeId(Guid.NewGuid()))
        {
        }

        internal static Bike Create()
        {
            var bike = new Bike();
            BikeCreated bikeCreated = new BikeCreated(bike.Id.Value);
            bike.RaiseEvent(bikeCreated);
            return bike;
        }

        internal void RegisterBikeJob(RegisterBikeJob command)
        {
            //Check business rules

            // Handle event
            BikeRegistered _event = command.MapToBikeRegistered();
            RaiseEvent(_event);
        }

        protected override void When(dynamic @event)
        {
            When(@event);
        }
    }
}