using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events.Queries.GetEventDetailsById
{
    public class GetEventDetailsByIdQuery : IGetEventDetailsByIdQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetEventDetailsByIdQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<EventDetailDTO> ExecuteAsync(Guid id)
        {
            var eventDTO = await _databaseService.Events
                .Where(e => e.Id == id)
                .Select(e => new EventDetailDTO()
                {
                    CityId = e.CityId,
                    CityName = e.City.Name,
                    Date = e.Date,
                    Description = e.Description,
                    Duration = e.Duration.ToString(),
                    EventCategoryId = e.EventCategoryId,
                    EventCategoryName = e.EventCategory.Name,
                    EventTypeId = e.EventTypeId,
                    EventTypeName = e.EventType.Name,
                    Id = e.Id,
                    Latitude = e.Latitude,
                    LocationName = e.LocationName,
                    Longitude = e.Longitude,
                    Name = e.Name
                })
                .SingleOrDefaultAsync();

            return eventDTO;
        }
    }
}
