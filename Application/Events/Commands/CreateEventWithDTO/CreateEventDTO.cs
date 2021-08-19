using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Events.Commands.CreateEventWithDTO
{
    public class CreateEventDTO
    {
        public int EventTypeId { get; set; }
        public int EventCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int CityId { get; set; }
        public string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Event GetEvent()
        {
            Event evnt = new Event
            {
                CityId = this.CityId,
                Date = this.Date,
                Description = this.Description,
                Duration = new TimeSpan(0, this.Duration, 0, 0, 0),
                EventCategoryId = this.EventCategoryId,
                EventTypeId = this.EventTypeId,
                Id = Guid.NewGuid(),
                IsActive = true,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                LocationName = this.LocationName,
                Name = this.Name
            };

            return evnt;
        }
    }

    
}
