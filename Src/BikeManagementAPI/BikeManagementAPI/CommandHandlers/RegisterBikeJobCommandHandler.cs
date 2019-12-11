using BikeManagementAPI.Command;
using BikeManagementAPI.Domain;
using System.Threading.Tasks;

namespace BikeManagementAPI.CommandHandlers
{
    public class RegisterBikeJobCommandHandler : IRegisterBikeJobCommandHandler
    {
        public RegisterBikeJobCommandHandler()
        {
        }

        public Task<Bike> HandleCommandAsync(RegisterBikeJob command)
        {
            var bike = Bike.Create();

            //Handle command
            bike.RegisterBikeJob(command);

            // persist
            var events = bike.GetEvents();

            // save bike

            // publish events
            foreach (var @event in events)
            {
                // publish message
            }

            return bike;
        }
    }
}