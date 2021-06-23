using Domain.Contacts;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Regions
{
    public class City
    {
        public City()
        {
            this.Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public State State { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
