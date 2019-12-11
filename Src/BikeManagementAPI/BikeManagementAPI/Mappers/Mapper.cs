using BikeManagementAPI.Command;
using BikeManagementAPI.Events;
using System;

namespace BikeManagementAPI.Mappers
{
    public static class Mapper
    {
        public static BikeRegistered MapToBikeRegistered(this RegisterBikeJob command)
        {
            return new BikeRegistered(Guid.NewGuid());
        }
    }
}