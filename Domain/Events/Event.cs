using Domain.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class Event
    {
        public Guid Id { get; set; }
        public int EventTypeId { get; set; }
        public int EventCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int CityId { get; set; }
        public string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool IsActive { get; set; }

        public EventType EventType { get; set; }
        public EventCategory EventCategory { get; set; }
        public City City { get; set; }

        public override bool Equals(object obj)
        {
            Event otherEvent = obj as Event;

            if (otherEvent == null)
            {
                return false;
            }

            return this.Id == otherEvent.Id;
        }
    }
}
