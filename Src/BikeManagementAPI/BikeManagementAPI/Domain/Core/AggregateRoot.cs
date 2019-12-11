using Events;
using System.Collections.Generic;

namespace BikeManagementAPI.Domain.Core
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        /// <summary>
        /// The list of events that occur while handling commands.
        /// </summary>
        private List<Event> _events;

        /// <summary>
        /// The original version of the aggregate after replaying all events in the event-store.
        /// </summary>
        public int Version { get; private set; }

        public AggregateRoot(TId id) : base(id)
        {
        }

        /// <summary>
        /// Get the list of events that occured while handling commands.
        /// </summary>
        public IEnumerable<Event> GetEvents()
        {
            return _events;
        }

        /// <summary>
        /// Let the aggregate handle an event and save it in the list of events
        /// so it can be used outside the aggregate (persisted, published on a bus, ...).
        /// </summary>
        /// <param name="event">The event to handle.</param>
        /// <remarks>Use GetEvents to retrieve the list of events.</remarks>
        protected void RaiseEvent(Event @event)
        {
            // let the derived aggregate handle the event
            When(@event);

            // save the event so it can be published outside the aggregate
            _events.Add(@event);
            Version += 1;
        }

        /// <summary>
        /// Handle a specific event. Derived classes should overide this method and implement
        /// the handling of different types of events.
        /// </summary>
        /// <param name="@event">The event to handle.</param>
        protected abstract void When(dynamic @event);
    }
}