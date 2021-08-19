using System;
using System.Threading.Tasks;

namespace Application.Events.Queries.GetEventDetailsById
{
    public interface IGetEventDetailsByIdQuery
    {
        Task<EventDetailDTO> ExecuteAsync(Guid id);
    }
}