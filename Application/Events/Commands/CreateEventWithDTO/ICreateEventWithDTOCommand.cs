using System.Threading.Tasks;

namespace Application.Events.Commands.CreateEventWithDTO
{
    public interface ICreateEventWithDTOCommand
    {
        Task ExecuteAsync(CreateEventDTO eventDTO);
    }
}