using Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contacts.Commands.CreateContactCommand
{
    public class ContactModel
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public ContactMethods ContactBy { get; set; }
        public int CityId { get; set; }
    }
}
