using Application.Interfaces;
using Domain.Contacts;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Events.Commands.RegisterContactInEventCommand
{
    public class RegisterContactInEventCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly INotificationsFactory _notificationsFactory;
        private readonly IStockService _stockService;

        public RegisterContactInEventCommand(IDatabaseService databaseService, INotificationsFactory notificationsFactory, IStockService stockService)
        {
            _databaseService = databaseService;
            _notificationsFactory = notificationsFactory;
            _stockService = stockService;
        }

        public void Execute(Guid eventId, Guid contactId)
        {
            EventRegisteredContact eventRegisteredContact = new EventRegisteredContact();

            eventRegisteredContact.ContactId = contactId;
            eventRegisteredContact.EventId = eventId;
            eventRegisteredContact.Id = Guid.NewGuid();
            eventRegisteredContact.RegisterDate = DateTime.Now;

            _databaseService.EventsRegisteredContacts.Add(eventRegisteredContact);
            _databaseService.Save();


            Contact contact = _databaseService.Contacts.Find(contactId);

            string message = "Usted se registró exitosamente en nuestro evento.";

            INotifications notifications = _notificationsFactory.Build(contact);

            notifications.Notify(message);

            _stockService.RequestEventShirt();
        }
    }
}
