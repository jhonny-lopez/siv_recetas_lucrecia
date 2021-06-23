using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Notifications
{
    public class SMSNotificationsStrategy : INotifications
    {
        public string To { get; set; }

        public void Notify(string message)
        {
            //TODO: Implementar código para enviar SMS
            Console.WriteLine("SMS enviado exitosamente a: " + To);
        }
    }
}
