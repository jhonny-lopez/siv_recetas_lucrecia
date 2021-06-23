using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class EventType
    {
        public EventType()
        {
            this.Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
