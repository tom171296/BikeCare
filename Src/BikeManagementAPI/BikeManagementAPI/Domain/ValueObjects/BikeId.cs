using System;

namespace BikeManagementAPI.Domain.ValueObjects
{
    public class BikeId
    {
        private Guid id;

        public Guid Value => id;

        public BikeId(Guid guid)
        {
            id = guid;
        }
    }
}