using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManagementAPI.Domain.Core
{
    public class Entity<TId>
    {
        public TId Id { get; private set; }

        public Entity(TId id)
        {
            Id = id;
        }
    }
}