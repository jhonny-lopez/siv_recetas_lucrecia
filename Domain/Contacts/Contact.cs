using Domain.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contacts
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public ContactMethods ContactBy { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }

        public override string ToString()
        {
            return FullName + "(" + EmailAddress + ")";
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Contact contact = obj as Contact;

            if (contact == null)
            {
                return false;
            }

            return this.Id == contact.Id;
        }
    }
}
