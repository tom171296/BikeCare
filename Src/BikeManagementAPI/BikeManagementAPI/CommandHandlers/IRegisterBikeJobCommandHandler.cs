using BikeManagementAPI.Command;
using BikeManagementAPI.Domain;
using System.Threading.Tasks;

namespace BikeManagementAPI.CommandHandlers
{
    public interface IRegisterBikeJobCommandHandler
    {
        Task<Bike> HandleCommandAsync(RegisterBikeJob registerBikeJob);
    }
}