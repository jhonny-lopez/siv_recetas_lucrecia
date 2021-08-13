using Domain.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Events.Queries.GetEventsCategoriesList
{
    public interface IGetEventsCategoriesListQuery
    {
        Task<ICollection<EventCategory>> ExecuteAsync();
    }
}