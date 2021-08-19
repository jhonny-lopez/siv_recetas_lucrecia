using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Events.Queries.GetEventDetailsById
{
    public class EventDetailDTO
    {
        public Guid Id { get; set; }
        public int EventTypeId { get; set; }
        public int EventCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public int CityId { get; set; }
        public string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string CityName { get; set; }
        public string EventCategoryName { get; set; }
        public string EventTypeName { get; set; }
    }
}
