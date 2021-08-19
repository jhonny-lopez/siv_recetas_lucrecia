using Domain.Events;
using System.Threading.Tasks;

namespace Application.Events.Commands.CreateEventWithoutDTO
{
    public interface ICreateEventCommandWithoutDTO
    {
        Task ExecuteAsync(Event evnt);
    }
}