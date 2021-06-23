using System;
using System.Threading;
using Common.Extensions;
using Domain.Contacts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=RecetasLucrecia;User id=sa;Password=m4l4l3ch3";
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            DatabaseService context = new DatabaseService(options);

            //CreateContact(context);
            //UpdateContacts(context);
            //DeleteContact(context);
            
            //Eager Loading y Lazy Loading

            var contactQuery = from contact in context.Contacts
                          where contact.Id == new Guid("EA64F1B0-2139-4588-A04B-22BAE81CEB7C")
                          select new
                          {
                              ContactName = contact.FullName,
                              CityName = contact.City.Name,
                              StateName = contact.City.State.Name
                          };

            var result = contactQuery.FirstOrDefault();

            Console.WriteLine($"{result.ContactName} vive en {result.CityName}, {result.StateName}");
        }

        private static void DeleteContact(DatabaseService context)
        {
            var contact = context.Contacts
                            .Find(new Guid("AB2F5582-20EC-49B1-8293-90F7CF35971E"));

            context.Contacts.Remove(contact);
            context.SaveChanges();
        }

        private static void UpdateContacts(DatabaseService context)
        {
            var contact = context.Contacts
                            .Find(new Guid("AD8D8C0E-4545-4A9E-85AD-0F871A5C7505"));

            contact.FullName = "Bob Saccamano";
            contact.EmailAddress = "bob@seinfeld.com";

            var contact2 = context.Contacts
                .FirstOrDefault(c => c.Id == new Guid("AB2F5582-20EC-49B1-8293-90F7CF35971E"));

            contact2.ContactBy = ContactMethods.PushNotification;

            var contactQuery = from contact4 in context.Contacts
                               where contact4.Id == new Guid("E2B40977-C6F6-45A5-A9D2-C2360EC4B9C0")
                               select contact4;

            var contact5 = contactQuery.FirstOrDefault();

            contact5.City = new Domain.Regions.City()
            {
                Name = "Popayán",
                StateId = 2
            };

            context.SaveChanges();
        }

        private static void CreateContact(DatabaseService context)
        {
            Contact newContact = new Contact();
            newContact.CityId = 1;
            newContact.ContactBy = ContactMethods.SMS;
            newContact.EmailAddress = "cosmokramer@gmail.com";
            newContact.FullName = "Cosmo Kramer";
            newContact.Id = Guid.NewGuid();
            newContact.PhoneNumber = "5540505";

            context.Contacts.Add(newContact);
            context.SaveChanges();

            var contactsQuery = from contact in context.Contacts
                                    //where contact.ContactBy == ContactMethods.Email
                                select contact;

            foreach (var contact in contactsQuery)
            {
                Console.WriteLine(contact.EmailAddress + " " + contact.PhoneNumber + " " + contact.FullName);
            }
        }
    }
}
