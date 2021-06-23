using Application.Interfaces;
using Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Notifications
{
    public class NotificationsFactory : INotificationsFactory
    {
        public INotifications Build(Contact contact)
        {
            INotifications notificationsStrategy;

            switch (contact.ContactBy)
            {
                case ContactMethods.SMS:
                    notificationsStrategy = new SMSNotificationsStrategy();
                    notificationsStrategy.To = contact.PhoneNumber;
                    break;
                case ContactMethods.Email:
                    notificationsStrategy = new EmailNotificationsStrategy();
                    notificationsStrategy.To = contact.EmailAddress;
                    break;
                case ContactMethods.PushNotification:
                    notificationsStrategy = new PushNotificationsStrategy();
                    notificationsStrategy.To = "";
                    break;

                case ContactMethods.TVApp:
                    notificationsStrategy = new TVAppNotificationsStrategy();
                    notificationsStrategy.To = "";
                    break;

                default:
                    notificationsStrategy = null;
                    break;
            }

            return notificationsStrategy;
        }
    }
}
