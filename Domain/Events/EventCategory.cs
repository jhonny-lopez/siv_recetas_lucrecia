using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class EventCategory
    {
        public EventCategory()
        {
            this.Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }

        public override bool Equals(object obj)
        {
            EventCategory otherEventCategory = obj as EventCategory;

            if (otherEventCategory == null)
            {
                return false;
            }

            return this.Id == otherEventCategory.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
