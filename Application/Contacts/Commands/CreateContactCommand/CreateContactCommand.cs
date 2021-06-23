using Application.Interfaces;
using Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommand : ICreateContactCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly INotificationsFactory _notificationsFactory;

        public CreateContactCommand(IDatabaseService databaseService, INotificationsFactory notificationsFactory)
        {
            _databaseService = databaseService;
            _notificationsFactory = notificationsFactory;
        }

        public void Execute(ContactModel model)
        {
            Contact contact = new Contact
            {
                CityId = model.CityId,
                ContactBy = model.ContactBy,
                EmailAddress = model.EmailAddress,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
            };

            contact.Id = Guid.NewGuid();

            _databaseService.Contacts.Add(contact);

            _databaseService.Save();

            string message = "Hola, bienvenido";

            INotifications notifications = _notificationsFactory.Build(contact);

            notifications.Notify(message);
        }
    }
}
