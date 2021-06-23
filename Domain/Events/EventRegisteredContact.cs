using Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class EventRegisteredContact
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public Guid EventId { get; set; }
        public DateTime RegisterDate { get; set; }

        public Contact Contact { get; set; }
        public Event Event { get; set; }
    }
}
